using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading;

namespace CSApp
{
    public class Product
    {
        public int ID { get; set; }
        [MaxLength(15)]
        public string Category { get; set; }
        [MaxLength(5)]
        public string PlantCode { get; set; }
        [MaxLength(10)]
        public string Engineer { get; set; }
        [MaxLength(5)]
        public string Revision { get; set; }
        [MaxLength(5)]
        public string Configure { get; set; }
        public string LabelFile { get; set; }
        public int HorzOffset { get; set; }
        public int VertOffset { get; set; }
        public int PageLinage { get; set; }
    }

    public class Printed
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        // 根据样式，保存日、周等时间信息
        [MaxLength(10)]
        public string DateFlag { get; set; }
        [ConcurrencyCheck]
        public int TotalNum { get; set; }
        public virtual Product Product { get; set; }
        //public virtual ICollection<Barcode> Barcodes { get; set; }
    }

    public class Barcode
    {
        public int ID { get; set; }
        public int PrintedID { get; set; }
        [MaxLength(25)]
        public string Contents { get; set; }
        [MaxLength(5)]
        public string QCSymbol { get; set; }
        public virtual Printed Printed { get; set; }
    }

    public class DataModelContext : DbContext
    {
        public DataModelContext() : base("name = DataModelContext") // app.config中connectionString的名字
        { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Printed> Printed { get; set; }
        public DbSet<Barcode> Barcode { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 创建索引--Product
            modelBuilder.Entity<Product>().Property(t => t.Category).HasColumnAnnotation(
                "Index", new IndexAnnotation(new IndexAttribute("IX_Category") { IsUnique = true }));
            // 创建索引--Printed
            modelBuilder.Entity<Printed>().Property(t => t.ProductID).HasColumnAnnotation(
                "Index", new IndexAnnotation(new IndexAttribute("IX_ProductDatetime", 1) { IsUnique = true }));
            modelBuilder.Entity<Printed>().Property(t => t.DateFlag).HasColumnAnnotation(
                "Index", new IndexAnnotation(new IndexAttribute("IX_ProductDatetime", 2) { IsUnique = true }));
            // 创建索引--Barcode
            modelBuilder.Entity<Barcode>().Property(t => t.Contents).HasColumnAnnotation(
                "Index", new IndexAnnotation(new IndexAttribute("IX_Contents") { IsUnique = true }));

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class DataModelInitializer : CreateDatabaseIfNotExists<DataModelContext>
    //public class DataModelInitializer : DropCreateDatabaseIfModelChanges<DataModelContext>
    {
        protected override void Seed(DataModelContext context)
        {
            var proudct = new List<Product>
            {
                new Product { Category = "PRC6875-55L1", PlantCode = "C47", Engineer = "J5XP", Revision = "7", Configure = "+L", LabelFile = "PRC6905-70L.lab", },
                new Product { Category = "PRC6875-55L2", PlantCode = "C47", Engineer = "J5XP", Revision = "7", Configure = "+M", LabelFile = "PRC6905-70L.lab", },
                new Product { Category = "PRC6905-70L1", PlantCode = "C47", Engineer = "J5XQ", Revision = "6", Configure = "+L", LabelFile = "PRC6905-70L.lab", },
                new Product { Category = "PRC6905-70L2", PlantCode = "C47", Engineer = "J5XQ", Revision = "6", Configure = "+M", LabelFile = "PRC6905-70L.lab", },
                new Product { Category = "PRC6968-56C1", PlantCode = "C47", Engineer = "J5XR", Revision = "5", Configure = "+L", LabelFile = "PRC6905-70L.lab", },
                new Product { Category = "PRC6968-56C2", PlantCode = "C47", Engineer = "J5XR", Revision = "5", Configure = "+M", LabelFile = "PRC6905-70L.lab", },   
            };
            context.Product.AddRange(proudct);
            context.SaveChanges();//可以分次提交，也可以最后一次性提交给数据库
        }
    }

    public static class Business
    {
        private static DataModelContext _dbContext;
        public static DataModelContext context
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
        public static Printed GetPrinted(int ID, string dateFlag)
        {
            var printed = context.Printed
                .Where(p => p.ProductID == ID && p.DateFlag == dateFlag).FirstOrDefault();
            if (printed == null)
            {
                printed = new Printed { ProductID = ID, DateFlag = dateFlag, TotalNum = 0 };
                context.Printed.Add(printed);
                context.SaveChanges();
            }
            return printed;
        }

        public static bool SetPrinted(Printed printed, int max, int add)
        {
            if (printed.TotalNum + add > max)
                return false;

            retry:
            try
            {
                printed.TotalNum += add;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                Thread.Sleep(200);
                goto retry;
            }
        }
    }
}