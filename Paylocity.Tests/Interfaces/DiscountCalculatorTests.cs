using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Models;

namespace Paylocity.Tests
{
    [TestClass]
    public class DiscountCalculatorTests
    {
        [TestMethod]
        public void Check_no_discount_if_name_does_not_start_with_letter_a()
        {
            // Arrange
            var person = new Person() { Name = "Naga Paylocity" };
            var discountbyName = new DiscountCalculator();

            // Act
            var discountRate = discountbyName.GetDiscountRateByName(person);

            // Assert
            Assert.IsTrue(discountRate == Constants.No_Discount);
        }

        [TestMethod]
        public void Check_percent_discount_rate_if_name_starts_with_letter_a()
        {
            // Arrange
            var person = new Person() { Name = "America" };
            var discountbyName = new DiscountCalculator();

            // Act
            var discountRate = discountbyName.GetDiscountRateByName(person);

            // Assert
            Assert.IsTrue(discountRate == Constants.Discount_Rate);
        }       

        [TestMethod]        
        public void Check_no_discount_if_person_name_is_null()
        {
            // Arrange
            Person person = new Person();
            var discountbyName = new DiscountCalculator();

            // Act
            var discountRate = discountbyName.GetDiscountRateByName(person);

            // Assert
            Assert.IsTrue(discountRate == Constants.No_Discount);
        }
    }
}
