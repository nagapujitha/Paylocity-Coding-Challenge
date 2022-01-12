using Paylocity.Models;
using Paylocity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paylocity
{
    public class DiscountCalculator : IDiscountCalculator
    {
        public decimal GetDiscountRateByName(Person person)
        {
            if (person.Name!=null)
            {
                if (person.Name.ToLower().StartsWith("a"))
                    return Constants.Discount_Rate;                   
            }
          
            return Constants.No_Discount;
        }
    }
}