using Microsoft.Extensions.Configuration;
using ModelLayer.Services;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmpRl : IEmpRl
    {
        private readonly IConfiguration Configuration;
        public EmpRl(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public void AddEmployee(EmployeeModel employeemodel)
        {


            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
            {

                SqlCommand cmd = new SqlCommand("PayformCredentials", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@IMG", employeemodel.IMG);
                cmd.Parameters.AddWithValue("@NAME", employeemodel.NAME);
                cmd.Parameters.AddWithValue("@GENDER", employeemodel.GENDER);
                cmd.Parameters.AddWithValue("@DEPARTMENT", employeemodel.DEPARTMENT);
                cmd.Parameters.AddWithValue("@SALARY", employeemodel.SALARY);
                cmd.Parameters.AddWithValue("@START_DATE", employeemodel.START_DATE);
                cmd.Parameters.AddWithValue("@NOTES", employeemodel.NOTES);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

        }
        public List<EmployeeModel> getEmployeeList()
        {
            List<EmployeeModel> EmpList = new List<EmployeeModel>();
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
            {
                SqlCommand cmd = new SqlCommand("allEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                //Bind EmpModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {
                    EmpList.Add(
                        new EmployeeModel
                        {
                            EMPID = Convert.ToInt32(dr["EMPID"]),
                            IMG = Convert.ToString(dr["IMG"]),
                            NAME = Convert.ToString(dr["NAME"]),
                            GENDER = Convert.ToString(dr["GENDER"]),
                            DEPARTMENT = Convert.ToString(dr["DEPARTMENT"]),
                            SALARY = Convert.ToString(dr["SALARY"]),
                            START_DATE = Convert.ToString(dr["START_DATE"]),
                            NOTES = Convert.ToString(dr["NOTES"])
                        }
                        );
                }
            }
            return EmpList;
        }

        public EmployeeModel getEmployeeById(int? id)
        {
            EmployeeModel employee = new EmployeeModel();

            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
            {
                string sqlQuery = "SELECT * FROM PayformDetails WHERE EMPID= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee.EMPID = Convert.ToInt32(rdr["EMPID"]);
                    employee.IMG = rdr["IMG"].ToString();
                    employee.NAME = rdr["NAME"].ToString();
                    employee.GENDER = rdr["GENDER"].ToString();
                    employee.DEPARTMENT = rdr["DEPARTMENT"].ToString();
                    employee.SALARY = Convert.ToString(rdr["SALARY"]);
                    employee.START_DATE = Convert.ToString(rdr["START_DATE"]);
                    employee.NOTES = rdr["NOTES"].ToString();
                }
            }
            return employee;
        }

        public void deleteEmployee(EmployeeModel employeemodel)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
            {
                SqlCommand cmd = new SqlCommand("deleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EMPID", employeemodel.EMPID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void editEmployee(EmployeeModel employeemodel)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
            {
                SqlCommand cmd = new SqlCommand("UpdateEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EMPID", employeemodel.EMPID);
                cmd.Parameters.AddWithValue("@IMG", employeemodel.IMG);
                cmd.Parameters.AddWithValue("@NAME", employeemodel.NAME);
                cmd.Parameters.AddWithValue("@GENDER", employeemodel.GENDER);
                cmd.Parameters.AddWithValue("@DEPARTMENT", employeemodel.DEPARTMENT);
                cmd.Parameters.AddWithValue("@SALARY", employeemodel.SALARY);
                cmd.Parameters.AddWithValue("@START_DATE", employeemodel.START_DATE);
                cmd.Parameters.AddWithValue("@NOTES", employeemodel.NOTES);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
