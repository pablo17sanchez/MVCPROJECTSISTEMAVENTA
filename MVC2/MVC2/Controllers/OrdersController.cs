using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC2.Models;
using MVC2.ViewModels;

namespace MVC2.Controllers
{
    public class OrdersController : Controller
    {
        MVC2Context DATABASE = new MVC2Context();
        [HttpGet]
        public ActionResult NewOrder()
        {
            var orderview = new OrderView();
            orderview.Customer = new Customer();
            orderview.Products = new List<ProductOrder>();
            Session["orderview"] = orderview;

            var lista = DATABASE.Customers.ToList();
            lista.Add(new Customer { CustomerID = 0, Firtsname = "[Seleccione un cliente...]" });
            lista.OrderBy(x => x.Fullname).ToList();
            ViewBag.CustomerID = new SelectList(lista, "CustomerID", "Fullname");

            return View(orderview);
        }

        /*******************************************************************/
        //   [HttpPost]
        //public ActionResult NewOrder(OrderView orderview)
            [HttpPost]
        public ActionResult NewOrder(OrderView orderview)
        {
            orderview = Session["orderview"] as OrderView;
            var customerid = int.Parse( Request["CustomerID"]);
            if (customerid == 0)
            {
                var lista = DATABASE.Customers.ToList();
                lista.Add(new Customer { CustomerID = 0, Firtsname = "[Seleccione un cliente...]" });
                lista.OrderBy(x => x.Fullname).ToList();
                ViewBag.CustomerID = new SelectList(lista, "CustomerID", "Fullname");
                ViewBag.Error = "Debe seleccionar un cliente";
                return View(orderview);

            }

            var customer = DATABASE.Customers.Find(customerid);
            if (customer==null)
            {
                var list = DATABASE.Customers.ToList();
            list.Add(new Customer { CustomerID = 0, Firtsname = "[Seleccione un cliente...]" });
            list.OrderBy(x => x.Fullname).ToList();
            ViewBag.CustomerID = new SelectList(list, "CustomerID", "Fullname");

            ViewBag.Error = "Cliente no existe";
            return View(orderview);
                
            }

            if (orderview.Products.Count==0)
            {

                var list = DATABASE.Customers.ToList();
                list.Add(new Customer { CustomerID = 0, Firtsname = "[Seleccione un cliente...]" });
                list.OrderBy(x => x.Fullname).ToList();
                ViewBag.CustomerID = new SelectList(list, "CustomerID", "Fullname");

                ViewBag.Error = "Debe ingresar el detalle";
                
                return View(orderview);
            }
            int orderid = 0;
            using (var transation = DATABASE.Database.BeginTransaction())
            {

                try
                {
                    var order = new Order
                    {
                        CustomerID = customerid,
                        DateOrder = DateTime.Now,
                        OrderStatus = OrderStatus.Created,




                    };

                    DATABASE.Orders.Add(order);
                    DATABASE.SaveChanges();
                    orderid = DATABASE.Orders.ToList().Select(x => x.OrderID).Max();
                    foreach (var item in orderview.Products)
                    {
                        var OrderDetails = new OrderDetail
                        {

                            Descripcion = item.Descripcion,

                            price = item.price,
                            Quantity = item.Quantity,
                            OrderID = orderid,

                            ProductID = item.ProductID


                        };

                        DATABASE.OrderDetails.Add(OrderDetails);
                        DATABASE.SaveChanges();
                    }
                    transation.Commit();


                }
                catch (Exception ex)
                {
                    transation.Rollback();
                    ViewBag.Error = "Error" + ex.ToString();
                    return View(orderview); 
                    
                }

         
            }

            var cs = DATABASE.Customers.ToList();
            cs.Add(new Customer { CustomerID = 0, Firtsname = "[Seleccione un cliente...]" });
            cs.OrderBy(x => x.Fullname).ToList();
            ViewBag.CustomerID = new SelectList(cs, "CustomerID", "Fullname");
           
            ViewBag.Message = String.Format("La ordern:{0}, grabada ok", orderid);
            orderview = new OrderView();
            orderview.Customer = new Customer();
            orderview.Products = new List<ProductOrder>();
            Session["orderview"] = orderview;
            return View(orderview);

        }


        [HttpPost]
        public ActionResult AddProduct(ProductOrder productorder)
        {
            var resultadorequest = Request["ProductID"];
            var orderview = Session["orderview"] as OrderView;
            if (resultadorequest==null)
            {
                resultadorequest = "0";
            }
            var ProductID = int.Parse(resultadorequest);
            
            if (ProductID==0)
            {
                var lista = DATABASE.Products.ToList();
            lista.Add(new ProductOrder { ProductID = 0, Descripcion = "[Seleccione un producto...]" });
            lista.OrderBy(x => x.Descripcion).ToList();
            ViewBag.ProductID = new SelectList(lista, "ProductID", "Descripcion");
            ViewBag.Error = "Debe seleccionar un producto";
            return View(productorder);
                
            }
            var product = DATABASE.Products.Find(ProductID);
            if (product==null)
            {
                var lista = DATABASE.Products.ToList();
            lista.Add(new ProductOrder { ProductID = 0, Descripcion = "[Seleccione un producto...]" });
            lista.OrderBy(x => x.Descripcion).ToList();
            ViewBag.ProductID = new SelectList(lista, "ProductID", "Descripcion");

            ViewBag.Error = "Producto no existe";
            return View(productorder);
            }
            var cantidad = Request["Quantity"] as String;
            productorder = orderview.Products.Find(x => x.ProductID == ProductID);

            if (productorder==null)
            {
                productorder = new ProductOrder
                {

                    Descripcion = product.Descripcion,
                    price = product.price,
                    ProductID = product.ProductID,
                    Quantity = float.Parse(cantidad)

                };
                orderview.Products.Add(productorder);

            }
            else
            {
                productorder.Quantity += float.Parse(cantidad);  
            }


            var listaCust = DATABASE.Customers.ToList();
            listaCust.Add(new Customer { CustomerID = 0, Firtsname = "[Seleccione un cliente...]" });
            listaCust.OrderBy(x => x.Firtsname).ToList();
            ViewBag.CustomerID = new SelectList(listaCust, "CustomerID", "Fullname");

            return View("NewOrder", orderview);
        }




        public ActionResult AddProduct()
        {

            //if (ModelState.IsValid)
            //            {

            //}

            var lista = DATABASE.Products.ToList();
            lista.Add(new ProductOrder { ProductID = 0, Descripcion = "[Seleccione un producto...]" });
            lista.OrderBy(x => x.Descripcion).ToList();
            ViewBag.ProductID = new SelectList(lista, "ProductID", "Descripcion");
            return View();

        }

   
   


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DATABASE.Dispose(); 
            }   
            base.Dispose(disposing);
        }
    }

}