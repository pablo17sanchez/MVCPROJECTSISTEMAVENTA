using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC2.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        [StringLength(30,ErrorMessage="El campo {0} debe estar entre {1} a {2} caracteres",MinimumLength=3)]
        [Required(ErrorMessage="EL campo {0} es requerido")]
        public String Descripcion { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "EL campo {0} es requerido")]
        public decimal price { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
         [DataType(DataType.DateTime)]
          public DateTime lastbuy { get; set; } 
            public float Stock { get; set; }
           [Required(ErrorMessage = "EL campo {0} es requerido")]
             public String Remarks { get; set; }
          
               
            

        public virtual ICollection<SupplierProduct> SupplierProduct { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }

    }
}