using Paylocity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Services.Interfaces
{
    public interface IDiscountCalculator
    {
        //Method to calculate discount by name
        decimal GetDiscountRateByName(Person person);
    }
}
