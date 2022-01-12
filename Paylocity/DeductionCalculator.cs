using Paylocity.Models;
using Paylocity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paylocity
{
    public class DeductionCalculator : IDeductionCalculator
    {
        private readonly IDeductionByType _annualDeductionRate;
        private readonly IDiscountCalculator _discountCalculator;

        public DeductionCalculator(IDeductionByType annualDeductionRate, IDiscountCalculator discountCalculator)
        {
            _annualDeductionRate = annualDeductionRate;
            _discountCalculator = discountCalculator;
        }

        public decimal CalculateDeductionForPerson(Person person)
        {
            return _annualDeductionRate.GetDeductionByType(person.Type) * (1 - (decimal)_discountCalculator.GetDiscountRateByName(person));
        }
    }
}