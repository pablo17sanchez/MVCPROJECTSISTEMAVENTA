using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVC2.Models
{
  
    public class SupplierProduct
    {
        [Key]
        public int SupliedProductID { get; set; }
        public int SupplierID { get; set; }

        public int ProductID { get; set; }


        public virtual Supplier Supplier { get; set; }
        public  virtual Products Products { get; set; }
    }
}