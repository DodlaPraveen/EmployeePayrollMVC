using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IEmpRl
    {
        public void AddEmployee(EmployeeModel employeemodel);
        List<EmployeeModel> getEmployeeList();
        EmployeeModel getEmployeeById(int? id);
        void deleteEmployee(EmployeeModel employeemodel);
        void editEmployee(EmployeeModel employeemodel);
    }
}
