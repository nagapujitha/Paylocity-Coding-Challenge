using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Paylocity.Models
{
    public class Person
    {
       [Required (ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }
       
        public PersonType Type { get; set; }
    }
}