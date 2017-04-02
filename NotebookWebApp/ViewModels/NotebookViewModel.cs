using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotebookWebApp.Models;
using System.Web.Mvc;

namespace NotebookWebApp.ViewModels
{
    public class NotebookViewModel
    {
        public Notebook Notebook { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
        public IEnumerable<SelectListItem> Processors { get; set; }
        public IEnumerable<SelectListItem> Manufacturers { get; set; }
    }
}