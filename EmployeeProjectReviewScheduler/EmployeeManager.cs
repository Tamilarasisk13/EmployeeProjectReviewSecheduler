using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeProjectReviewScheduler
{
    class EmployeeManager
    {
        List<object> employeeList = new List<object>();
        EmployeeRepositary employeeRepositary = new EmployeeRepositary();
        private string firstName;
        private string lastName;
        private string id;
        private string emailId;
        private string mobileNumber;
        private string userName;
        private string password;
        private string designation;
        private string action;

        public string SearchAdmin(SqlConnection sqlconnection)
        {
            using (SqlCommand sqlCommand = new SqlCommand("spLogin", sqlconnection))
            {
                Console.WriteLine("Enter the username");
                string userName = Console.ReadLine();
                Console.WriteLine("Enter the password");
                string password = Console.ReadLine();
                Admin admin = new Admin(userName,password);
                return employeeRepositary.AddAdmin(admin, sqlconnection);
               
            }
        }

        public int AddEmployee(SqlConnection sqlConnection)
        {
           // GetId();
            GetFirstName();
            GetLastName();
            GetEmailId();
            GetMobileNumber();
            GetUserName();
            GetPassword();
            GetDesignation();
            return AddEmployeeList(sqlConnection);
        }
        public void GetFirstName()
        {

            Console.WriteLine("Enter the first name of the employee");
            Console.WriteLine("First letter must be capital");
            firstName = Console.ReadLine();

            if (!ValidateEmployeeDetails.ValidateName(firstName))
            {
                Console.WriteLine("Invalid First name");
                GetFirstName();
            }
        }
        public void GetLastName()
        {
            Console.WriteLine("Enter the last name of the employee");
            Console.WriteLine("First letter must be capital");
            lastName = Console.ReadLine();
            if (!ValidateEmployeeDetails.ValidateName(lastName))
            {
                Console.WriteLine("Invalid last name");
                GetLastName();
            }
        }
        public void GetId()
        {
            Console.WriteLine("Enter the Id ");
            id = Console.ReadLine();
            if (!ValidateEmployeeDetails.ValidateId(id))
            {
                Console.WriteLine("InValid ID");
                GetId();
            }
            else
            {
                bool flag = true;
                foreach (Employee details in employeeList)
                {
                    if (details.id == id)
                    {
                        Console.WriteLine("*****Employee is already exists*****");
                        flag = false;
                        break;
                    }
                }
                if (flag == false)
                {
                    Portal portal = new Portal();
                    portal.GetChoice();
                }
            }
        }
        public void GetEmailId()
        {
            Console.WriteLine("Enter the Email Id");
            emailId = Console.ReadLine();
            if (!ValidateEmployeeDetails.ValidateEmailId(emailId))
            {
                Console.WriteLine("Invalid Email id");
                GetEmailId();
            }
        }
        public void GetMobileNumber()
        {
            Console.WriteLine("Enter the mobile number");
            mobileNumber = Console.ReadLine();
            if (!ValidateEmployeeDetails.ValidateMobileNumber(mobileNumber))
            {
                Console.WriteLine("Invalid Mobile number");
                GetMobileNumber();
            }
        }
        public void GetUserName()
        {
            Console.WriteLine("Enter the user name");
            Console.WriteLine("First letter must be capital");
            userName = Console.ReadLine();
            if (!ValidateEmployeeDetails.ValidateName(userName))
            {
                Console.WriteLine("Invalid user name");
                GetUserName();
            }
        }
        public void GetPassword()
        {
            Console.WriteLine("Enter the password");
            Console.WriteLine("\nPassword must contain atleast 8 letters");
            password = Console.ReadLine();
            if (!ValidateEmployeeDetails.ValidatePassword(password))
            {
                Console.WriteLine("Invalid password");
                GetPassword();
            }
        }
        public void GetDesignation()
        {
            Console.WriteLine("Enter the Designation");
            designation=Console.ReadLine();
        }
        
        public int AddEmployeeList(SqlConnection sqlConnection)
        {
            action = "Insert";
            Employee employee = new Employee(firstName,lastName,emailId,mobileNumber,userName,password,designation,action);
            return employeeRepositary.AddEmployee(employee, sqlConnection);
        }
        public void DeleteEmployee(string userId)
        {
            bool flag = true;
            foreach (Employee employee in employeeList)
            {

                if (employee.id == userId)
                {
                    employeeList.Remove(employee);
                    Console.WriteLine("******Employee is Deleted successfully******");
                    flag = false;
                    break;
                }
            }
            if (flag == true)
            {
                Console.WriteLine("******Employee does not exists******");
            }
        }
        public void UpdateEmployee(string userId)
        {
            bool flag = true;
            foreach (Employee employee in employeeList)
            {

                if (employee.id == userId)
                {

                    Console.WriteLine("Enter the mobile  number  you want to update");
                    string userChoice = Console.ReadLine();
                    employee.mobileNumber = userChoice;
                    Console.WriteLine("Mobile number is updated Successfully");
                    flag = false;
                    break;
                }
                if (flag == true)
                {

                    Console.WriteLine("******Employee ID does not exists******");
                }
            }
        }


        public void DisplayEmployee()
        {
            foreach (Employee e in employeeList)
            {
                Console.WriteLine("First Name    : {0}\nLast Name     : {1}\nID            : {2}\nEmail Id      : {3}\nMobile Number : {4}\nUsername      : {5}\nPassword      : {6}", e.firstName, e.lastName, e.id, e.emailId, e.mobileNumber, e.userName, e.password);
                Console.WriteLine();
            }
        }
        public bool SearchEmployee(string username, string Password)
        {
            bool flag = true;
            foreach (Employee details in employeeList)
            {
                if (details.userName == username && details.password == Password)
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
                return false;
            return true;

        }
        //public bool SearchAdmin(string username, string password)
        //{
        //    if(adminPassword==password && adminUsername == username)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        public List<object> GetList()
        {
            return employeeList;
        }
        public EmployeeManager()
        {

            BindEmployeeDetails();
        }
        public void BindEmployeeDetails()
        {

            Employee employee = new Employee("Tamil", "Arasi", "tamil@aspiresys.com", "9787617628", "Tamilarasi", "tamil@123", "Scheduler", "Admin");
            employeeList.Add(employee);
            employee = new Employee("Sangavi", "Shanmugam", "sangavi@aspiresys.com", "8040417628", "Sangavi", "sangavi@123", "Reviewer", "User");
            employeeList.Add(employee);
            employee = new Employee("Kavi", "Kamachi", "kavi@aspiresys.com", "9026847628", "Kavi", "kavi@123", "Reviewee", "User");
            employeeList.Add(employee);
            employee = new Employee("Anisha", "Rose", "kavi@aspiresys.com", "9026847628", "Kavi", "anish@123", "Manager", "User");
            employeeList.Add(employee);
        }

    }
}
