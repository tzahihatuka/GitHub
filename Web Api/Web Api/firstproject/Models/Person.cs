using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace firstproject.Models
{
    public class Person
    {
       
            [Range(0, 999), validation]
            public int Id { get; set; }

            [MinLength(2), MaxLength(10)]
            public string Name { get; set; }

            [Range(10, 200)]
            public decimal Price { get; set; }

            [MinLength(10), MaxLength(70)]
            public string Description { get; set; }

            public bool IsVeg { get; set; }

            public Taste FoodTaste { get; set; }

        
    }
}