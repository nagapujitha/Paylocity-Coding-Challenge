using Paylocity.Interfaces;
using Paylocity.Models;
using Paylocity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paylocity.Services
{
    public class CalculationService: ICalculationService
    {

        private readonly IDeductionCalculator _deductionCalculator;

        public CalculationService(IDeductionCalculator deductionCalculator)
        {
            _deductionCalculator = deductionCalculator;
        }

        public CalculationResults CalculateDeductionsforEmployee(Employee employee)
        {
            List<Person> persons = ConvertEmployeeToPersons(employee);
            decimal yearlyDeductionForEmployee = persons.Sum(person => _deductionCalculator.CalculateDeductionForPerson(person));
            decimal deductionperpaycheck = yearlyDeductionForEmployee / employee.NumberOfPaychecksPerYear;


            return new CalculationResults()
            {               
                TotalDeductionPerPayCheck = deductionperpaycheck,
                 TotalDeductionPerYear = yearlyDeductionForEmployee,
                 SalaryPerPayCheckAfterDeductions=(employee.YearlySalary/employee.NumberOfPaychecksPerYear)- deductionperpaycheck,
                 YearlySalaryAfterDeductions=employee.YearlySalary- yearlyDeductionForEmployee
            };
        }
        public static List<Person> ConvertEmployeeToPersons(Employee employee)
        {
            var persons = new List<Person>();

            persons.Add(new Person() { Name = employee.Name, Type = PersonType.Employee });

            foreach (Dependent dependent in employee.Dependents)
            {
                persons.Add(new Person() { Name = dependent.Name, Type = PersonType.Dependent });
            }
            return persons;
        }

       

       

       
       
    }
}