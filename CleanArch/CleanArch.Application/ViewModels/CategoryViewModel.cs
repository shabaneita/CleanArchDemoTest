using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.ViewModels
{
   public class CategoryViewModel
    {      
        public string Image { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
