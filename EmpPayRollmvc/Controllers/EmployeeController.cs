using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System.Collections.Generic;
using System.Linq;

namespace EmpPayRollmvc.Controllers
{
    
        public class EmployeeController : Controller
        {
            IEmpBl empBl;


            public EmployeeController(IEmpBl empBl)
            {
                this.empBl = empBl;
            }
            public IActionResult Index()
            {
                List<EmployeeModel> lstEmployee = new List<EmployeeModel>();
                //lstEmployee = empBl.getEmployeeList().ToList();

                return View(lstEmployee);
            }
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create([Bind] EmployeeModel employee)
            {
                if (ModelState.IsValid)
                {
                    empBl.AddEmployee(employee);
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
        }
}
