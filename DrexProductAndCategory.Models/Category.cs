﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrexProductAndCategory.Models
{
    public class Category
    {
        public Guid Id { get; set; }  
        public string? Name { get; set; }
        public string? Description { get; set; }

     
        public ICollection<Product>? Products { get; set; } = new List<Product>();
    }

}

