using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Paylocity.Models
{
    
    public class Dependent : Person
    {
        [Required]
        public DependentType DependentType { get; set; }
       
    }

  
}