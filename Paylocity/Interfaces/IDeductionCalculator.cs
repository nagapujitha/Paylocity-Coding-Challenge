using Paylocity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Services.Interfaces
{
    public interface IDeductionCalculator
    {
        //calculates entire discount and deduction for person
        decimal CalculateDeductionForPerson(Person person);
    }
}
