using System;
using System.Collections.Generic;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Models;
using Paylocity.Services;
using Paylocity.Services.Interfaces;

namespace Paylocity.Tests.Services
{
    [TestClass]
    public class CalculationServiceTests
    {
        [TestMethod]
        public void Check_employee_salary_per_annum_after_deduction_calculation()
        {
            // Arrange
            var testEmployee = new Employee() { Name = "Emma", YearlySalary = 10000, NumberOfPaychecksPerYear = 10 };

            var deductionCalculator = A.Fake<IDeductionCalculator>();
            A.CallTo(() => deductionCalculator.CalculateDeductionForPerson(A<Person>._)).Returns(1000);

            var objectUnderTest = new CalculationService(deductionCalculator);

            // Act
            var calculationResults = objectUnderTest.CalculateDeductionsforEmployee(testEmployee);

            // Assert
            var expectedYearlySalaryAfterDeduction = 10000 - 1000;
            Assert.IsTrue(expectedYearlySalaryAfterDeduction == calculationResults.YearlySalaryAfterDeductions);
        }

       
        [TestMethod]
        public void verify_deduction_calculation_calls_are_made()
        {
            // Arrange
            var testEmployee = new Employee() { Name = "Raj", YearlySalary = 10000, NumberOfPaychecksPerYear = 10 };

            var deductionCalculator = A.Fake<IDeductionCalculator>();
            var objectUnderTest = new CalculationService(deductionCalculator);

            // Act
            var calculationResults = objectUnderTest.CalculateDeductionsforEmployee(testEmployee);

            // Assert
            A.CallTo(() => deductionCalculator.CalculateDeductionForPerson(A<Person>._)).MustHaveHappened();
        }
    }
}
