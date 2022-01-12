using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Paylocity.Models
{
    public class CalculationResults
    {
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public decimal TotalDeductionPerPayCheck { get; set; }
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public decimal TotalDeductionPerYear { get; set; }
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public decimal SalaryPerPayCheckAfterDeductions { get; set; }
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public decimal YearlySalaryAfterDeductions { get; set; }

    }
}