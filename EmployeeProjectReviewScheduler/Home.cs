/**
 * Class Name : Project
 * Version    : 1.0
 * Date       : 16-01-2020
 * Author     : Tamilarasi
 */
using System;
namespace EmployeeProjectReviewScheduler
{
    class Home
    {     
  static void Main(string[] args)
        {

            Portal portal = new Portal();
            portal.GetChoice();
            Console.ReadLine();
        }
    }
}
//public void GetRole()
//{
//    Console.WriteLine("Enter the action");
//    action= Console.ReadLine();
//}



//bool flag = true;
//foreach (Employee details in employeeList)
//{
//    if (details.id == userId)
//    {
//        Console.WriteLine("*****Employee is already exists*****");
//        flag = false;
//        break;
//    }
//}
//if (flag == true)
//{
//    Employee employee = new Employee(firstName, lastName, id, emailId, mobileNumber, userName, password,designation);
//    employeeList.Add(employee);
//    Console.WriteLine("******Employee is added successfully******");
//}
