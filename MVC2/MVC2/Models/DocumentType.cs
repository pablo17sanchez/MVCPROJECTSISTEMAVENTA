using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC2.Models
{
    public class DocumentType
    {
        [Key]
        [Display(Name = "Documentype")]
        public int DocumentypeID { get; set; }
           [Display(Name = "Documento Nombre")]
        public string Description { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }

    }
}