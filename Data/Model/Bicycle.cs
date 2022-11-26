using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication2.Data.Model
{
    public class Bicycle
    {
        [BindNever]
        public int id { get; set; }
        public string name { get; set; }
        public string shortDesc { get; set; }
        public string longDesc { get; set; }
        public string img { get; set; }
        public ushort price { get; set; }
        public ushort count { get; set; }
        public string firm { get; set; }
        public bool isFavorit { get; set; }
        public int categoryId { get; set; }
       
        public virtual Category Category { get; set; }
        [NotMapped]
        public List<SelectListItem> listOfType { get; set; }
    }
}
