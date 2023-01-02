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
            lstEmployee = empBl.getEmployeeList().ToList();

            return View(lstEmployee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
       
        public IActionResult Create( EmployeeModel employeemodel)
        {
            if (ModelState.IsValid)
            {
                empBl.AddEmployee(employeemodel);
                return RedirectToAction("Index");
            }
            return View(employeemodel);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = empBl.getEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = empBl.getEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            var employee = empBl.getEmployeeById(id);
            empBl.deleteEmployee(employee);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employeemodel = empBl.getEmployeeById(id);

            if (employeemodel == null)
            {
                return NotFound();
            }
            return View(employeemodel);
        }

        [HttpPost]
        public IActionResult Edit(int id, EmployeeModel employeemodel)
        {
            if (id != employeemodel.EMPID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                empBl.editEmployee(employeemodel);
                return RedirectToAction("Index");
            }
            return View(employeemodel);
        }

    }
}
