using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands
{
  public  class UpdateCategoryCommand : CategoryCommand
    {

        public UpdateCategoryCommand(int id, string name, string description, string imageUrl)
        {
            Id = id;
            Name = name;
            Content = description;
            Image = imageUrl;
        }


    }
}
