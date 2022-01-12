using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paylocity.Models
{
    public class Constants
    {
        public const int Salary_per_PayCheck = 2000;
        public const int Paychecks_per_Yr = 26;
        public const decimal Employee_Deduction = 1000;
        public const decimal Dependent_Deduction = 500;
        public const decimal Discount_Rate = 0.10M;
        public const decimal No_Discount = 0.00M;
    }
}