

namespace EmployeeProjectReviewScheduler
{
    class Employee
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string id { get; set; }
        public string emailId { get; set; }
        public string mobileNumber { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string designation { get; set; }
        public string action { get; set; }
        public Employee(string firstName, string lastName, string emailId, string mobileNumber, string userName, string password,string designation,string action)
        {
            this.firstName = firstName;
            this.lastName = lastName;
           // this.id = id;
            this.emailId = emailId;
            this.mobileNumber = mobileNumber;
            this.userName = userName;
            this.password = password;
            this.designation = designation;
            this.action= action;
        }

    }
    
}
