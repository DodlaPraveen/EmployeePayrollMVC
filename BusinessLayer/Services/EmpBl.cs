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

            public void AddEmployee(EmployeeModel employee)
            {
                try
                {
                    this.iemprl.AddEmployee(employee); 
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
       
    }

    
}
