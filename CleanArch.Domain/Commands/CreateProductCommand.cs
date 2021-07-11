using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands
{



    public class CreateProductCommand : ProductCommand
    {
        public CreateProductCommand(string name, string description, string image, double price, int categoryId)
        {
            Name = name;
            Description = description;
            Image = image;
            CategoryId = categoryId;
        }
    }
}
