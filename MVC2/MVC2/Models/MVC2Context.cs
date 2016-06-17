using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace MVC2.Models
{
    public class MVC2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MVC2Context() : base("name=MVC2Context")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();  
        }

        public System.Data.Entity.DbSet<MVC2.Models.Products> Products { get; set; }

        public System.Data.Entity.DbSet<MVC2.Models.DocumentType> DocumentTypes { get; set; }

        public System.Data.Entity.DbSet<MVC2.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<MVC2.Models.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<MVC2.Models.Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<MVC2.Models.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<MVC2.Models.OrderDetail> OrderDetails { get; set; }
    
    }
}
