using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NotebookWebApp.Models
{
    public class Manufacturer
    {
        public int ManufacturerID { get; set; }

        [Required]
        [Display(Name = "Наименование")]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Адрес")]
        [StringLength(30)]
        public string Address { get; set; }

        [Display(Name = "Сайт")]
        [StringLength(30)]
        public string Site { get; set; }

        public virtual ICollection<Notebook> Notebooks { get; set; }
    }
}