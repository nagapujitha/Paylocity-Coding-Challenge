using Paylocity.Interfaces;
using Paylocity.Models;
using Paylocity.Services;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paylocity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculationService _calculationService;

        public HomeController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public HomeController()
        {
        }

        public ActionResult About()
        {
            ViewBag.Message = "Paylocity Coding Challenge Description";
          return View();
        }
        public ActionResult Index()
        {
            List<SelectListItem> DependentNumberList = new List<SelectListItem>();
            for (var i = 0; i <= 20; i++)
            {
                DependentNumberList.Add(new SelectListItem() { Value = $"{(i == 0 ? "No" : i.ToString())} Dependent{(i == 1 ? "" : "s")}", Text = i.ToString() });
            }
            ViewBag.dependents = DependentNumberList;
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            try
            {
                    int noofDependents = int.Parse(Request.Form["noofDependents"].ToString());
                    return RedirectToAction("Employee", "Home", new { numberOfDependents = noofDependents });
               
            }
            catch (Exception ex1)
            {
                ViewBag.Message = ex1.GetBaseException().Message;
                return View();
            }
        }

        
        public ActionResult Employee(int? numberOfDependents)
        {
            if (String.IsNullOrEmpty(numberOfDependents.ToString()))
            {
                return RedirectToAction("Index","Home");
            }

            Employee employee = new Employee();

            employee.YearlySalary = Constants.Salary_per_PayCheck * Constants.Paychecks_per_Yr;
            employee.NumberOfPaychecksPerYear = Constants.Paychecks_per_Yr;

            for (int i = 0; i < numberOfDependents; i++)
            {
                employee.Dependents.Add(new Dependent() { DependentType = (i == 0 ? DependentType.Spouse : DependentType.Child) });
            }
           
            ViewBag.types = getDepedentTypes();
            return View(employee);
        }

       private List<SelectListItem> getDepedentTypes()
        {
            List<SelectListItem> dependentTypes = new List<SelectListItem>();
            foreach (var value in Enum.GetValues(typeof(DependentType)))
            {
                dependentTypes.Add(new SelectListItem() { Text = value.ToString(), Value = value.ToString() });
            }
            return dependentTypes;
        }

        [HttpPost]
        public ActionResult Employee(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CalculationResults results = _calculationService.CalculateDeductionsforEmployee(employee);
                    TempData["calculatedResults"] = results;
                    TempData["employee"] = employee;
                    return RedirectToAction("Results", "Home");
                }
               
                ViewBag.types = getDepedentTypes();
                return View(employee);
            }
            catch (Exception ex1)
            {
                ViewBag.Message = ex1.GetBaseException().Message;
                return View(employee);
            }
        }

        public ActionResult Results()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dynamic model = new ExpandoObject();
                    model.Employee = (Employee)TempData["employee"];
                    model.Results = (CalculationResults)TempData["calculatedResults"];
                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex1)
            {
                ViewBag.Message = ex1.GetBaseException().Message;
                return View();
            }
        } 
    }
}