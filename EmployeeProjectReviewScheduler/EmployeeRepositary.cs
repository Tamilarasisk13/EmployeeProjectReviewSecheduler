using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProjectReviewScheduler
{
    class EmployeeRepositary
    {
        public string AddAdmin(Admin admin, SqlConnection sqlConnection)
        {
            using (SqlCommand sqlCommand = new SqlCommand("spLogin", sqlConnection))
            {
                SqlParameter sqlParameter = new SqlParameter();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@userName", admin.userName);
                sqlCommand.Parameters.AddWithValue("@password", admin.password);
                sqlCommand.Parameters.Add("@role", SqlDbType.VarChar, 5);
                sqlCommand.Parameters["@role"].Direction = ParameterDirection.Output;
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine(Convert.ToString(sqlCommand.Parameters["@role"].Value));
                string Role = Convert.ToString(sqlCommand.Parameters["@role"].Value);
                return Role;

            }
        }
        public int AddEmployee(Employee employee, SqlConnection sqlConnection)
        {
            using (SqlCommand sqlCommand = new SqlCommand("spInsertEmployee", sqlConnection))
            {
                string action = "Insert";
                SqlParameter sqlParameter = new SqlParameter();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@firstName", employee.firstName);
                sqlCommand.Parameters.AddWithValue("@lastName", employee.lastName);
                sqlCommand.Parameters.AddWithValue("@emailId", employee.emailId);
                sqlCommand.Parameters.AddWithValue("@mobileNumber", employee.mobileNumber);
                sqlCommand.Parameters.AddWithValue("@userName", employee.userName);
                sqlCommand.Parameters.AddWithValue("@password", employee.password);
                sqlCommand.Parameters.AddWithValue("@designation", employee.designation);
                sqlCommand.Parameters.AddWithValue("@action",action);
                //sqlCommand.Parameters.Add("@action", SqlDbType.VarChar, 5);
                //sqlCommand.Parameters["@role"].Direction = ParameterDirection.Output;
                //sqlConnection.Open();
                int rows = sqlCommand.ExecuteNonQuery();
    
                //Console.WriteLine(sqlCommand.ExecuteNonQuery());
                return rows;
            }


        }

    }
}
