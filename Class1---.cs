using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
namespace CSApp.Business
{
    public class BaseDA
    {
        #region 通用
        private DbContext _dbContext;
        public DbContext CurrentContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new DataModelContext();
                }
                return _dbContext;
            }
        }
        /// <summary>
        /// 执行Sql查询
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="strSql"></param>
        /// <param name="paramObjects"></param>
        /// <returns></returns>
        public List<TEntity> SqlQuery<TEntity>(string strSql, params Object[] paramObjects) where TEntity : class
        {
            if (paramObjects == null)
            {
                paramObjects = new object[0];
            }
            return this.CurrentContext.Database.SqlQuery<TEntity>(strSql, paramObjects).ToList();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<TEntity> Search<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return CurrentContext.Set<TEntity>().Where(predicate);
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> FindAll<TEntity>() where TEntity : class
        {
            return CurrentContext.Set<TEntity>();
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        public void Insert<TEntity>(TEntity entity, bool isSave = true) where TEntity : class
        {
            CurrentContext.Set<TEntity>().Add(entity);
            if (isSave)
            {
                CurrentContext.SaveChanges();
            }
        }
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="isSave"></param>
        public void Insert<TEntity>(List<TEntity> entitys, bool isSave = true) where TEntity : class
        {
            foreach (var entity in entitys)
            {
                CurrentContext.Set<TEntity>().Add(entity);
            }
            if (isSave)
            {
                CurrentContext.SaveChanges();
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        public void Update<TEntity>(TEntity entity, bool isSave = true) where TEntity : class
        {
            var local = FindLocal(CurrentContext, entity);
            if (local == null)
            {
                throw new Exception("要更新的实体不存在");
            }
            //ObjectMapper.CopyProperties(entity, local);
            if (isSave)
            {
                CurrentContext.SaveChanges();
            }
        }
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="isSave"></param>
        public void Update<TEntity>(List<TEntity> entities, bool isSave = true) where TEntity : class
        {
            foreach (var entity in entities)
            {
                var local = FindLocal(CurrentContext, entity);
                if (local == null)
                {
                    throw new Exception("要更新的实体不存在");
                }
                //ObjectMapper.CopyProperties(entity, local);
            }
            if (isSave)
            {
                CurrentContext.SaveChanges();
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        public void Delete<TEntity>(TEntity entity, bool isSave = true) where TEntity : class
        {
            var local = FindLocal(CurrentContext, entity);
            if (local == null)
            {
                throw new Exception("要删除的实体不存在");
            }
            CurrentContext.Entry<TEntity>(local).State = EntityState.Deleted;
            if (isSave)
            {
                CurrentContext.SaveChanges();
            }
        }
        #endregion
        #region private

        private static void DetachOther<T>(DbContext db, T obj) where T : class
        {
            var local = FindLocal(db, obj);
            if (local != null)
            {
                Detach(db, local);
            }
        }
        private static void Detach<T>(DbContext db, T obj) where T : class
        {
            ObjectContext oc = ((IObjectContextAdapter)db).ObjectContext;
            oc.Detach(obj);
        }
        private static IEnumerable<string> GetEntityKeys<T>(DbContext db) where T : class
        {
            ObjectContext oc = ((IObjectContextAdapter)db).ObjectContext;
            var keys = oc.CreateObjectSet<T>().EntitySet.ElementType.KeyProperties.Select(x => x.Name);
            return keys;
        }
        private static Expression<Func<T, bool>> GetFindExp<T>(T obj, IEnumerable<string> keys) where T : class
        {
            var p = Expression.Parameter(typeof(T), "x");
            var keyexps = keys.Select(x =>
            {
                var member = Expression.PropertyOrField(p, x);
                var objV = typeof(T).GetProperty(x).GetValue(obj, null);
                var eq = Expression.Equal(member, Expression.Constant(objV));
                return eq;
            }).ToList();
            if (keys.Count() == 1)
            {
                return Expression.Lambda<Func<T, bool>>(keyexps[0], new[] { p });
            }
            var and = Expression.AndAlso(keyexps[0], keyexps[1]);
            for (var i = 2; i < keyexps.Count; i++)
            {
                and = Expression.AndAlso(and, keyexps[i]);
            }
            return Expression.Lambda<Func<T, bool>>(and, new[] { p });
        }
        private static T FindLocal<T>(DbContext db, T obj) where T : class
        {
            var keys = GetEntityKeys<T>(db);
            var func = GetFindExp<T>(obj, keys);
            var local = db.Set<T>().Local.FirstOrDefault(func.Compile());
            if (local == null)
            {
                return db.Set<T>().Where(func).FirstOrDefault();
            }
            else
            {
                return local;
            }
        }
        #endregion
    }
}