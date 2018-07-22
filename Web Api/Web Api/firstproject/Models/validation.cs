using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace firstproject.Models
{
    public class validation: ValidationAttribute
    {
       
            public override bool IsValid(object value)
            {
                int num;
                int.TryParse(value.ToString(), out num);
                return num % 2 == 0;
            }
        
    }
}