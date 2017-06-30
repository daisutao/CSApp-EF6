using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CSApp.Logic.Repository
{
    public abstract class AbstractRepository<TC, T> : IDisposable
    where TC : DbContext, new()
    where T : class
    {
        private TC _entities = new TC();
        private bool _disposed;
        protected TC Context
        {
            get
            {
                return _entities;
            }
            set
            {
                _entities = value;
            }
        }
        public virtual IQueryable<T> All
        {
            get
            {
                return GetAll();
            }
        }
        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _entities.Set<T>();
            return includeProperties.Aggregate(queryable, (current, expression) => current.Include(expression));
        }
        public virtual IQueryable<T> GetAll()
        {
            return _entities.Set<T>();
        }
        public virtual T Find(params object[] keyValues)
        {
            return _entities.Set<T>().Find(keyValues);
        }
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _entities.Set<T>().Where(predicate);
        }
        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }
        public virtual void BulkInsert(List<T> list)
        {
            var tblName = typeof(T).Name;
            BulkInsert(_entities.Database.Connection.ConnectionString, tblName, list);
        }
        public static void BulkInsert(string connection, string tableName, IList<T> list)
        {
            using (var bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.BatchSize = list.Count;
                bulkCopy.DestinationTableName = tableName;
                var table = new DataTable();
                var props = TypeDescriptor.GetProperties(typeof(T))
               //Dirty hack to make sure we only have system data types 
               //i.e. filter out the relationships/collections
                                                          .Cast<PropertyDescriptor>()
                .Where(propertyInfo => propertyInfo.PropertyType.Namespace != null
                && propertyInfo.PropertyType.Namespace.Equals("System"))
                .ToArray();
                foreach (var propertyInfo in props)
                {
                    bulkCopy.ColumnMappings.Add(propertyInfo.Name, propertyInfo.Name);
                    table.Columns.Add(propertyInfo.Name, Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType);
                }
                var values = new object[props.Length];
                foreach (var item in list)
                {
                    for (var i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                    }
                    table.Rows.Add(values);
                }
                bulkCopy.WriteToServer(table);
            }
        }
        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }
        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = (EntityState.Modified);
        }
        public virtual void Upsert(T entity, Func<T, bool> insertExpression)
        {
            if (insertExpression(entity))
            {
                Add(entity);
            }
            else
            {
                Edit(entity);
            }
        }
        public virtual void Save()
        {
            _entities.SaveChanges();
        }
        public virtual DataTable PageQuery(int page, int pageSize,
        string sort, string where, out int total)
        {
            var viewName = typeof(T).Name;
            var paras = new List<SqlParameter>
            {
                new SqlParameter("tblName", "dbo."+viewName),
                new SqlParameter("fldName", "*"),
                new SqlParameter("pageSize", pageSize),
                new SqlParameter("page", page),
                new SqlParameter("fldSort", sort),
                new SqlParameter("strCondition", where),
                new SqlParameter("pageCount", SqlDbType.Int){Direction = ParameterDirection.Output},
            };
            var countParameter = new SqlParameter
            {
                ParameterName = "counts",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            var strParameter = new SqlParameter("strSql", SqlDbType.NVarChar, 4000) { Direction = ParameterDirection.Output };
            paras.Add(countParameter);
            paras.Add(strParameter);
            var conn = _entities.Database.Connection.ConnectionString;
            var ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure,
            "dbo.PagedQuery", paras.ToArray());
            total = countParameter.Value == DBNull.Value ? 0 : Convert.ToInt32(countParameter.Value);
            return ds.Tables[0];
        }
        public virtual List<T> PageQueryList(int page, int pageSize,
        string sort, string where, out int total)
        {
            var viewName = typeof(T).Name;
            var paras = new List<SqlParameter>
            {
                new SqlParameter("tblName", "dbo."+viewName),
                new SqlParameter("fldName", "*"),
                new SqlParameter("pageSize", pageSize),
                new SqlParameter("page", page),
                new SqlParameter("fldSort", sort),
                new SqlParameter("strCondition", where),
                new SqlParameter("pageCount", SqlDbType.Int){Direction = ParameterDirection.Output},
            };
            var countParameter = new SqlParameter
            {
                ParameterName = "counts",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            var strParameter = new SqlParameter("strSql", SqlDbType.NVarChar, 4000) { Direction = ParameterDirection.Output };
            paras.Add(countParameter);
            paras.Add(strParameter);
            //var conn = _entities.Database.Connection.ConnectionString;
            //var ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure,
            //                                  "dbo.PagedQuery", paras.ToArray());
            //total = countParameter.Value == DBNull.Value ? 0 : Convert.ToInt32(countParameter.Value);
            var ret = _entities.Database.SqlQuery<T>(
 "dbo.PagedQuery @tblName,@fldName,@pageSize,@page,@fldSort,@strCondition,@pageCount out,@counts out,@strSql out",
 paras.ToArray()).ToList();
            total = countParameter.Value == DBNull.Value ? 0 : Convert.ToInt32(countParameter.Value);
            return ret;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _entities.Dispose();
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

// 2. 具体类继承泛型类
namespace Crm.Data.Logic.Logic
{
    public class CrmDispatchLogic : AbstractRepository<LifeEntities, Crm_Dispatch>
    {

    }
}

// 3. 使用具体类
/*
    var dispatchSvc = new CrmDispatchLogic();
    var dispatchModel = dispatchSvc.GetAll().FirstOrDefault(m => m.Handler == opId && m.IsUse == 1);
    if (dispatchModel != null)
    {}
*/