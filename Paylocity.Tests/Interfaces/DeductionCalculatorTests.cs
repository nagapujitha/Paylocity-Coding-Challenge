using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Models;
using Paylocity.Services.Interfaces;

namespace Paylocity.Tests
{
    [TestClass]
    public class DeductionCalculatorTests
    {
        private const decimal ANNUAL_RATE = 10.0M;
        private const decimal DISCOUNT_RATE = 0.10M;

        [TestMethod]
        public void Check_discount_calculation()
        {
            // Arrange
            var testPerson = new Person() { Type = PersonType.Employee, Name = "Amar" };

            var deductionByType = A.Fake<IDeductionByType>();
            A.CallTo(() => deductionByType.GetDeductionByType(testPerson.Type)).Returns(ANNUAL_RATE);

            var discountCalculator = A.Fake<IDiscountCalculator>();
            A.CallTo(() => discountCalculator.GetDiscountRateByName(testPerson)).Returns(DISCOUNT_RATE);

            var objectUnderTest = new DeductionCalculator(deductionByType, discountCalculator);

            // Act
            var annualRatewithDiscount = objectUnderTest.CalculateDeductionForPerson(testPerson);

            //Assert
           var expectedAnnualRateWithDiscount = ANNUAL_RATE * (1 - DISCOUNT_RATE);
            Assert.IsTrue(annualRatewithDiscount == expectedAnnualRateWithDiscount);
        }

        [TestMethod]
        public void Check_calculate_deduction_per_year()
        {
            // Arrange
            var testPerson1 = new Person() { Type = PersonType.Employee, Name = "Amar" };
            var testPerson2 = new Person() { Type = PersonType.Dependent, Name = "Naga" };

            var annualDeductionRate = A.Fake<IDeductionByType>();
            A.CallTo(() => annualDeductionRate.GetDeductionByType(testPerson1.Type)).Returns(ANNUAL_RATE);
            A.CallTo(() => annualDeductionRate.GetDeductionByType(testPerson2.Type)).Returns(ANNUAL_RATE);

            var discountCalculator = A.Fake<IDiscountCalculator>();
            A.CallTo(() => discountCalculator.GetDiscountRateByName(testPerson1)).Returns(DISCOUNT_RATE);
            A.CallTo(() => discountCalculator.GetDiscountRateByName(testPerson2)).Returns(0.0M);

            var objectUnderTest = new DeductionCalculator(annualDeductionRate, discountCalculator);

            // Act            
            var persons = new List<Person>() { testPerson1, testPerson2 };
            var deductionPerAnnum=  persons.Sum(person => objectUnderTest.CalculateDeductionForPerson(person));
            // Assert
            var expectedDeductionPerAnnum = (ANNUAL_RATE * (1 - DISCOUNT_RATE)) + (ANNUAL_RATE * (1 - 0.0M));
            Assert.IsTrue(deductionPerAnnum == expectedDeductionPerAnnum);
        }

    }
}
