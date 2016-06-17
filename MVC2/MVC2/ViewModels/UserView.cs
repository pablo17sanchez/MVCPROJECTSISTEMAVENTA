using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVC2.ViewModels;
namespace MVC2.Models
{
    public class UserView
    {

        public String UserID { get; set; }
        public String Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
       public Rollview Rol { get; set; }
       public List<Rollview> Roles { get; set; }
    
    }
}