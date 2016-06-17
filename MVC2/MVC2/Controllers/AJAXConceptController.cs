using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC2.Controllers
{
    public class AJAXConceptController : Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult JsonFactorial(int n) {

            if (!Request.IsAjaxRequest())
            {
                return null;
            }

            var resul = new JsonResult
            {
                Data = new { 
                
                Factorial =Factorial(n)
                }
            };
            return resul;
        }

        private double Factorial(int n)
        {
            double fact = 1;
            for (int i = 0; i <= n; i++)
            {
                fact *= i;
            }

            return fact;
        }
    }
}