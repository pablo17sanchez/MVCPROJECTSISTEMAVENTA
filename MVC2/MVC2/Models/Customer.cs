using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(30, ErrorMessage = "E l campo {0} debe ser de tamano {1} a {2}", MinimumLength = 3)] 
       [Required(ErrorMessage="El campo {0} es requerido")]
        public String Firtsname { get; set; }
    
        
        [Display(Name = "Apellido")]
        [StringLength(30, ErrorMessage = "E l campo {0} debe ser de tamano {1} a {2}", MinimumLength = 3)]
        public String LastName { get; set; }
        [Display(Name = "Numero de telefono")]
        [Required(ErrorMessage="El campo {0} es requerido")]
        [DataType(DataType.PhoneNumber)]
        public String Phone { get; set; }
        [Display(Name = "Direccion")]
        [StringLength(30, ErrorMessage = "El campo {0} debe ser de tamano {1} a {2}", MinimumLength = 3)]
        public String Address { get; set; }
        [Display(Name = "Correo Electronico")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [Display(Name = "Direccion")]
        [StringLength(30, ErrorMessage = "El campo {0} debe ser de tamano {1} a {2}", MinimumLength = 5)]
       [Required(ErrorMessage="El campo {0} es requerido ")]

        public string Document { get; set; }
        [Range(0.0, Int32.MaxValue)]
        public int DocumentypeID { get; set;   }
        [NotMapped]
        public String Fullname { get { return String.Format("{0} {1}", Firtsname, LastName); } }  
        public virtual DocumentType DocumentType { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}