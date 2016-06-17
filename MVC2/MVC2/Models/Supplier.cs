using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC2.Models
{
 
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        [Required]
        [StringLength(30,ErrorMessage="El campo {0} debe ser de tamano {1} a {2}",MinimumLength=3)]
        [Display(Name="Nombre")]
        public String Name { get; set; }
        [Display(Name = "Nombre del contacto")]
        [StringLength(30, ErrorMessage = "El campo {0} debe ser de tamano {1} a {2}", MinimumLength = 3)]

        public String ContactFirtsName { get; set; }
        [Display(Name = "Apellido del contacto")]
        [StringLength(30, ErrorMessage = "E l campo {0} debe ser de tamano {1} a {2}", MinimumLength = 3)]
        public String ContactLastName { get; set; }
        [Display(Name = "Numero de telefono")]
        [DataType(DataType.PhoneNumber)]
        public String Phone { get; set; }
        [Display(Name = "Direccion")]
        [StringLength(30, ErrorMessage = "El campo {0} debe ser de tamano {1} a {2}", MinimumLength = 3)]
        public String Address { get; set; }
        [Display(Name = "Correo Electronico")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        public virtual ICollection<SupplierProduct> SupplierProduct { get; set; }
    }
}