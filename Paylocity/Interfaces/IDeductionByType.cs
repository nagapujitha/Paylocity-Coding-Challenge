using Paylocity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Services.Interfaces
{
   public interface IDeductionByType
    {
        //Method to calculate the discount by type of Person
        decimal GetDeductionByType(PersonType personType);
    }
}
