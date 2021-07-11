using CleanArch.Domain.Core.Commands;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands
{
    public abstract class CategoryCommand : Command
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}