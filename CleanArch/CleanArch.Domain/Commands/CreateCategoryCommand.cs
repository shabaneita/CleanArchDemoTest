using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands
{
   

    public class CreateCategoryCommand : CategoryCommand
    {
        public CreateCategoryCommand(string name, string description, string imageUrl)
        {
  
                    Name = name;
                    Content = description;
                    Image = imageUrl;
        }
    }
}
