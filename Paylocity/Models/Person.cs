using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Paylocity.Models
{
    public class Person
    {
        public PersonType Type { get; set; }

        [Required (ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }
       
       
    }
}