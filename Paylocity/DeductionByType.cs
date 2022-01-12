using Paylocity.Models;
using Paylocity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paylocity
{
    public class DeductionByType : IDeductionByType
    {
        public decimal GetDeductionByType(PersonType personType)
        {
            switch (personType)
            {
                case PersonType.Employee:
                    return Constants.Employee_Deduction;
                case PersonType.Dependent:
                    return Constants.Dependent_Deduction;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}