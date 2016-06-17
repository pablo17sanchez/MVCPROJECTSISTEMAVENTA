using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC2.Models
{

    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Display(Name="Nombre")]
        [Column("Nombre")]
        [Required(ErrorMessage="Tiene que entrear el {0}")]
        [StringLength(30,ErrorMessage="El campo {0} debe estar entre {1} a {2} caracteres",MinimumLength=3)]
        public String FirtsName { get; set; }
         [Display(Name = "Apellido")]
        
        [Required(ErrorMessage = "Tiene que entrear el {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {1} a {2} caracteres", MinimumLength = 3)]
        public String LastName { get; set; }
    
         [Display(Name = "Salario")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString="{0:C2}", ApplyFormatInEditMode=false)]
        public decimal Salary { get; set; }
          [Display(Name = "Bono")]
          [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public float BonusPercent { get; set; }
          [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
           [Display(Name = "Hora de inicio")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Startiem { get; set; }
           [Display(Name = "Correo Electronico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
           [Display(Name = "Direccion de pagina web")]
           [DataType(DataType.Url)]
        public String Url { get; set; }
             [NotMapped]
           public int Age { get { return DateTime.Now.Year - DateOfBirth.Year; } }
         [Required(ErrorMessage = "Tiene que entrear el {0}")]
         [Display(Name = "Documento")]
        public int DocumentypeID { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        
    }
}