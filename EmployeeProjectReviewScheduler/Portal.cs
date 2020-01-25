using System;
using System.Configuration;
using System.Data.SqlClient;
namespace EmployeeProjectReviewScheduler
{
    class Portal
    {
        EmployeeManager employeeManager = new EmployeeManager();
        public void GetChoice()
        {
            ScheduleRepositary scheduleRepositary = new ScheduleRepositary();
            //try
            //{
                string connectionstring = ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionstring);
                bool flag = true;
                while (flag == true)
                {
                    Console.WriteLine("1.Admin\n2.User\n3.Exit");
                    Console.WriteLine("Enter the choice");
                    byte userChoice = Convert.ToByte(Console.ReadLine());
                    switch (userChoice)
                    {
                        case 1:                                               
                            if (employeeManager.SearchAdmin(sqlConnection)=="Admin")
                            {
                                Console.WriteLine("******Login Successfully*****");
                                Console.WriteLine("1.Add Employee\n2.Delete Employee\n3.Update Employee Details \n4.Display Employee");
                                Console.WriteLine("Enter the choice");
                                userChoice = Convert.ToByte(Console.ReadLine());
                                switch (userChoice)
                                {
                                    case 1:
                                        if (employeeManager.AddEmployee(sqlConnection) > 0)

                                            Console.WriteLine("Employee is added successfully");
                                        else
                                            Console.WriteLine("Employee is not added");
                                            break;
                                    case 2:

                                        Console.WriteLine(" Enter the employee Id you want to delete");
                                        string userId = Console.ReadLine();
                                        employeeManager.DeleteEmployee(userId);
                                        break;
                                    case 3:
                                        Console.WriteLine(" Enter the employee Id you want to update");
                                        userId = Console.ReadLine();
                                        employeeManager.UpdateEmployee(userId);
                                        break;
                                    case 4:
                                        employeeManager.DisplayEmployee();
                                        break;
                                }

                            }
                            else
                                Console.WriteLine("Username or password is invalid");
                            Console.WriteLine("===========================");
                            break;
                        case 2:
                            Console.WriteLine("\nLogin\n======");
                            Console.WriteLine("1.Scheduler \n2.Reviewer \n3.Reviewee");
                            Console.WriteLine("Enter the choice");
                            userChoice = Convert.ToByte(Console.ReadLine());
                            switch (userChoice)
                            {
                                case 1:
                                    Console.WriteLine("Enter the user name");
                                    Console.WriteLine("First letter must be capital");
                                   string  userName = Console.ReadLine();
                                    Console.WriteLine("Enter the password");
                                   string  password = Console.ReadLine();
                                    if (employeeManager.SearchEmployee(userName, password))
                                    {

                                        Console.WriteLine("******Login Successfully*****");
                                        Console.WriteLine("Enter the Scheduler id");
                                        string id = Console.ReadLine();
                                        Console.WriteLine("Enter the designation");
                                        string designation = Console.ReadLine();
                                        if (!ValidateEmployeeDetails.ValidateId(id))
                                        {
                                            Console.WriteLine("Invalid Scheduler Id");
                                            scheduleRepositary.GetSchedulerId();
                                        }
                                        if (scheduleRepositary.SearchScheduler(id, designation))
                                        {
                                            Console.WriteLine("1.Schedule the review\n2.View the Schedule");
                                            Console.WriteLine("Enter the choice");
                                            userChoice = Convert.ToByte(Console.ReadLine());
                                            switch (userChoice)
                                            {
                                                case 1:
                                                    scheduleRepositary.Schedule();
                                                    Console.WriteLine("\nSchedule the review");
                                                    scheduleRepositary.ScheduleReview();
                                                    break;
                                                case 2:
                                                    scheduleRepositary.DisplayReviewSchedule();
                                                    break;
                                            }
                                        }
                                        else
                                            Console.WriteLine("He is not a Scheduler");
                                    }
                                    else
                                        Console.WriteLine("Username or password is invalid");
                                    break;
                                case 2:
                                    Console.WriteLine("\nLogin\n======");
                                    Console.WriteLine("Enter the user name");
                                    Console.WriteLine("First letter must be capital");
                                     userName = Console.ReadLine();
                                    Console.WriteLine("Enter the password");
                                  password = Console.ReadLine();

                                    if (employeeManager.SearchEmployee(userName, password))
                                    {
                                        Console.WriteLine("******Login Successfully*****");
                                        Console.WriteLine("Enter the reviewer id");
                                        string id = Console.ReadLine();

                                        Console.WriteLine("Enter the designation");
                                        string designation = Console.ReadLine();
                                        if (!ValidateEmployeeDetails.ValidateId(id))
                                        {
                                            Console.WriteLine("Invalid reviewer Id");
                                            scheduleRepositary.GetReviewerId();
                                        }
                                        if (scheduleRepositary.SearchReviewer(id, designation))
                                        {
                                            scheduleRepositary.ShowReviewSchedule(id);
                                        }
                                        else
                                        {
                                            Console.WriteLine("*** There is no review schedule for you ***");
                                        }
                                    }
                                    else
                                        Console.WriteLine("Username or password is invalid");
                                    break;
                                case 3:
                                    Console.WriteLine("\nLogin\n======");
                                    Console.WriteLine("Enter the user name");
                                    Console.WriteLine("First letter must be capital");
                                    userName = Console.ReadLine();
                                    Console.WriteLine("Enter the password");
                                     password = Console.ReadLine();

                                    if (employeeManager.SearchEmployee(userName, password))
                                    {
                                        Console.WriteLine("******Login successfully*****");
                                        Console.WriteLine("Enter the reviewee id");
                                        string id = Console.ReadLine();
                                        Console.WriteLine("Enter the reviewee designation");
                                        string designation = Console.ReadLine();
                                        if (!ValidateEmployeeDetails.ValidateId(id))
                                        {
                                            Console.WriteLine("Invalid reviewee Id");
                                            scheduleRepositary.GetRevieweeId();
                                        }

                                        if (scheduleRepositary.SearchReviewee(id, designation))
                                        {

                                            scheduleRepositary.ShowReviewSchedule(id);
                                        }
                                        else
                                        {
                                            Console.WriteLine("*** There is no schedule review for you ***");
                                        }
                                    }
                                    else
                                        Console.WriteLine("User name or password is incorrect");
                                    break;
                            }
                            break;
                        case 3:
                            flag = false;
                            break;
                    }
                }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
        }
    }
}
