using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity;
using Paylocity.Controllers;
using Paylocity.Models;

namespace Paylocity.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Test_Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        

        [TestMethod]
        public void Test_Model_in_Employee()
        {
            var controller = new HomeController();
            var result = controller.Employee(2) as ViewResult;
            var employee = (Employee)result.ViewData.Model;
            Assert.AreEqual(2, employee.Dependents.Count);
        }

       
        [TestMethod]
        public void Test_dependenttypes_setup_in_Employee()
        {
            // Arrange     
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Employee(3) as ViewResult;
            // Assert
            Assert.IsNotNull(result.ViewBag.types);
        }

      
        [TestMethod]
        public void Test_About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Paylocity Coding Challenge Description", result.ViewBag.Message);
        }

       

    }
}
