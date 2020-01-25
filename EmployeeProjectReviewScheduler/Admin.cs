namespace EmployeeProjectReviewScheduler
{
    class Admin
    {
        public string userName {get; set;}
        public string password { get; set; }
        public string role { get; set; }
        public Admin(string userName,string password)
        {
            this.userName = userName;
            this.password = password;
            
        }
    }
}
