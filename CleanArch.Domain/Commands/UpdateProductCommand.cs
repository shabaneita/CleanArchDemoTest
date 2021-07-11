using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands
{
   public class UpdateProductCommand:ProductCommand
    {
        public UpdateProductCommand(int id, string name, string description, string imageUrl,double price, int categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = imageUrl;
            Price = price;
            CategoryId = categoryId;


        }
    }
}
