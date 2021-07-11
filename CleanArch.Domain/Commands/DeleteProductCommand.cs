using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands
{
  public  class DeleteProductCommand:ProductCommand
    {
        public DeleteProductCommand(string name, string description, string image, double price, int categoryId)
        {
            Name = name;
            Description = description;
            Image = image;
            Price = price;
            CategoryId = categoryId;
        }
    }
}
