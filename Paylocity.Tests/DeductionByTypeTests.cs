using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Models;

namespace Paylocity.Tests
{
    [TestClass]
    public class DeductionByTypeTests
    {
        [TestMethod]
        public void check_employee_deduction_rate()
        {
            // Arrange
            var employee = PersonType.Employee;
            var deductionbyType = new DeductionByType();

            // Act
            var deductedAmount = deductionbyType.GetDeductionByType(employee);

            // Assert
            Assert.IsTrue(deductedAmount == Constants.Employee_Deduction);
        }

        [TestMethod]
        public void check_dependent_deduction_rate()
        {
            // Arrange
            var dependent = PersonType.Dependent;
            var deductionbyType = new DeductionByType();

            // Act
            var deductedAmount = deductionbyType.GetDeductionByType(dependent);

            // Assert
            Assert.IsTrue(deductedAmount == Constants.Dependent_Deduction);
        }
     

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void check_exception_for_invalid_enum()
        {
            // Arrange
            var personType = (PersonType)100;
            var deductionbyType = new DeductionByType();

            // Act
            var deductedAmount = deductionbyType.GetDeductionByType(personType);

            // Assert
            // Should throw an exception
        }
    }
}
