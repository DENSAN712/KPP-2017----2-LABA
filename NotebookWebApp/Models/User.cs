using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NotebookWebApp.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required]
        [Display(Name = "ФИО")]
        [StringLength(30)]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [StringLength(30)]
        public string Email { get; set; }

        public virtual ICollection<Notebook> Notebooks { get; set; }
    }
}