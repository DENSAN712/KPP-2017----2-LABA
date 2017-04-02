using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NotebookWebApp.Models
{
    public class Processor
    {
        public int ProcessorID { get; set; }

        [Required]
        [Display(Name = "Модель")]
        [StringLength(20)]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Частота")]
        [StringLength(10)]
        public string Frequency { get; set; }

        [Required]
        [Display(Name = "Сокет")]
        [StringLength(20)]
        public string Socket { get; set; }

        [Required]
        [Display(Name = "Количество ядер")]
        public int Cores { get; set; }

        public virtual ICollection<Notebook> Notebooks { get; set; }
    }
}