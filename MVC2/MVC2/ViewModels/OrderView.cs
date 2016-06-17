using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC2.Models;

namespace MVC2.ViewModels
{
    public class OrderView
    {
        public Customer Customer { get; set; }
        public List<ProductOrder> Products { get; set; }
        public ProductOrder Productorders { get; set; }


    }
}