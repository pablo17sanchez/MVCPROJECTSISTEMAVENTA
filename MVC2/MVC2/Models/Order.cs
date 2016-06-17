using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace MVC2.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime DateOrder { get; set; }
        public int CustomerID { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int ProductID { get; set; }
       
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}