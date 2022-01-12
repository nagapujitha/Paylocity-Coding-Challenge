using Paylocity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Interfaces
{
   public interface ICalculationService
    {
        CalculationResults CalculateDeductionsforEmployee(Employee employee);
    }
}
