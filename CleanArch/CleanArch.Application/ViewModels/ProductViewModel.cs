using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.ViewModels
{
   public class ProductViewModel
    {  
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public IEnumerable <Product> Products { get; set; }
    }
}
