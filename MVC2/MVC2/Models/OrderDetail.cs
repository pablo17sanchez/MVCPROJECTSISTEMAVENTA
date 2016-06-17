using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC2.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {1} a {2} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "EL campo {0} es requerido")]
        public String Descripcion { get; set; }
        [Required(ErrorMessage = "EL campo {0} es requerido")]
        public decimal price { get; set; }
           [Required(ErrorMessage = "EL campo {0} es requerido")]
        [DataType(DataType.Currency)]

        [DisplayFormat(DataFormatString="{0:N2}")]
        public float Quantity { get; set; }
        public virtual Order Order { get; set; }
        public virtual Products  Products{ get; set; }

    }
}