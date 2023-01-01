using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Services
{
    public class EmployeeModel
    {
        public int EMPID { get; set; }
        public string IMG { get; set; }

        public string NAME { get; set; }

        public string GENDER { get; set; }

        public string DEPARTMENT { get; set; }

        public string SALARY { get; set; }
        public string START_DATE { get; set; }
        public string NOTES { get; set; }
    }
}
