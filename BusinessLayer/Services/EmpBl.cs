using BusinessLayer.Interface;
using ModelLayer.Services;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{


    public class EmpBl : IEmpBl
    {
        IEmpRl iemprl;

        public EmpBl(IEmpRl iemprl)
        {
            this.iemprl = iemprl;
        }

        public void AddEmployee(EmployeeModel employeemodel)
        {
            try
            {
                this.iemprl.AddEmployee(employeemodel);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void deleteEmployee(EmployeeModel employeeModel)
        {
            try
            {
                this.iemprl.deleteEmployee(employeeModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void editEmployee(EmployeeModel employeemodel)
        {
            try
            {
               this.iemprl.editEmployee(employeemodel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public EmployeeModel getEmployeeById(int? id)
        {
            try
            {
                return this.iemprl.getEmployeeById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<EmployeeModel> getEmployeeList()
        {
            try
            {
                return this.iemprl.getEmployeeList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
   


}
