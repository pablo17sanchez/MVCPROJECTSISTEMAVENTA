using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC2.Models
{
    public class ProductOrder: Products
    {
     


   
        [DisplayFormat(DataFormatString = "{0:C2}",ApplyFormatInEditMode=false)]
        [Required]
        [Range(1, float.MaxValue, ErrorMessage = "El campo tiene que ser mayor a 0")]
        public float Quantity { get; set; }

        public decimal Value { get{return price*(decimal)Quantity;} }
    }
}