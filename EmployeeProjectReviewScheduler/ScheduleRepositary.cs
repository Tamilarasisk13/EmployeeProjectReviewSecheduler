using System;
using System.Collections.Generic;
namespace EmployeeProjectReviewScheduler
{
    class ScheduleRepositary
    {
        List<object> reviewList = new List<object>();
        EmployeeManager employeeManager = new EmployeeManager();
        private string revieweeName;
        private string revieweeId;
        private string reviewerName;
        private string reviewerId;
        private string schedulerId;
        private string reviewDate;
        private string reviewTime;
        private  string reviewDuration;
        public void Schedule()
        {
            foreach(Employee schedule in employeeManager.GetList())
            {
                if(schedule.designation=="Reviewer")
                {
                    Console.WriteLine("Reviewer name is {0} \nReviewer Id is {1}", schedule.firstName + schedule.lastName, schedule.id);
                }
                if (schedule.designation == "Reviewee")
                {
                    Console.WriteLine("Reviewee name is {0} \nReviewee Id is {1}", schedule.firstName + schedule.lastName, schedule.id);
                }
            }
        }
        public void ScheduleReview()
        {
            GetRevieweeName();
            GetRevieweeId();
            GetReviewerName();
            GetReviewerId();
            GetReviewDate();
            GetReviewTime();
            GetReviewDuration();
            AddReview();
        }
        public void GetRevieweeName()
        {
            try
            {
                Console.WriteLine("Enter the reviewee name");
                Console.WriteLine("First letter must be capital");
                revieweeName = Console.ReadLine();
                if (!ValidateEmployeeDetails.ValidateName(revieweeName))
                {
                    Console.WriteLine("Invalid reviewee name");
                    GetRevieweeName();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GetReviewerName()
        {
            try
            {
                Console.WriteLine("Enter the reviewer name");
                Console.WriteLine("First letter must be capital");
                reviewerName = Console.ReadLine();
                if (!ValidateEmployeeDetails.ValidateName(reviewerName))
                {
                    Console.WriteLine("Invalid reviewer name");
                    GetReviewerName();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GetRevieweeId()
        {
            Console.WriteLine("Enter the reviewee Id");
            revieweeId = Console.ReadLine();
            if (!ValidateEmployeeDetails.ValidateId(revieweeId))
            {
                Console.WriteLine("Invalid reviewee Id");
                GetRevieweeId();
            }
        }
        public void GetSchedulerId()
        {
            Console.WriteLine("Enter the Scheduler Id");
            schedulerId = Console.ReadLine();
            if (!ValidateEmployeeDetails.ValidateId(schedulerId))
            {
                Console.WriteLine("Invalid reviewee Id");
                GetRevieweeId();
            }
        }
        public void GetReviewerId()
        {
            Console.WriteLine("Enter the reviewer Id");
            reviewerId =Console.ReadLine();
            if (!ValidateEmployeeDetails.ValidateId(reviewerId))
            {
                Console.WriteLine("Invalid reviewer Id");
                GetReviewerId();
            }
        }
        public void GetReviewDate()
        {
            Console.WriteLine("Enter the date of the review");
           reviewDate= Console.ReadLine();
            if(!ValidateEmployeeDetails.ValidateDate(reviewDate))
            {
                Console.WriteLine("Invalid review date");
                GetReviewDate();
            }
               
        }
        public void GetReviewTime()
        {
            Console.WriteLine("Enter the time of the review");
            reviewTime = Console.ReadLine();
            if (!ValidateEmployeeDetails.ValidateTime(reviewTime))
            {
                Console.WriteLine("Invalid review time");
                GetReviewTime();
            }
                
        }
        public void GetReviewDuration()
        {
            Console.WriteLine("Enter the duration of the review");
            reviewDuration = Console.ReadLine();
            
        }
        public void AddReview()
        {
            Scheduler scheduler = new Scheduler( revieweeName,  revieweeId, reviewerName,  reviewerId,  reviewDate,  reviewTime,reviewDuration);
            reviewList.Add(scheduler);
            Console.WriteLine("*****Review is scheduled successfully*****");
        }
        public void DisplayReviewSchedule()
        {
           
            if (reviewList.Count == 0)
            {     
                Console.WriteLine("There is no review is scheduled");
            }
            else
            {
                foreach (Scheduler review in reviewList)
                {
                    Console.WriteLine("Reviewee Name : {0}\nReviewee Id : {1}\nReviewer Name : {2}\nReviewer Id {3}\nReview Date : {4}\nReview Time : {5}\nReview Duration : {6}", revieweeName, revieweeId, reviewerName, reviewerId, reviewDate, reviewTime, reviewDuration);
                    Console.WriteLine();
                }
            }
           
        }



        public void ShowReviewSchedule(string userid)
        {

            foreach (Scheduler review in reviewList)
            {

                if ((review.reviewerId == userid) || (review.revieweeId == userid))
                {
                    Console.WriteLine("Reviewee Name : {0}\nReviewee Id : {1}\nReviewer Name : {2}\nReviewer Id : {3}\nReview Date : {4}\nReview Time : {5}\nReview Duration : {6}", revieweeName, revieweeId, reviewerName, reviewerId, reviewDate, reviewTime, reviewDuration);
                    break;
                }
            }
        }
        public bool SearchReviewer(string id, string designation)
        {
            bool flag = true;
            foreach (Employee review in employeeManager.GetList())
            {
                if (review.id == id && review.designation == designation)
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
                return false;
            return true;
        }

        public bool SearchScheduler(string id,string designation)
        {

            bool flag = true;
            foreach (Employee review in employeeManager.GetList())
            {

                if (review.id == id && review.designation==designation)
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
                return false;
            return true;

        }
        public bool SearchReviewee(string id, string designation)
        {

            bool flag = true;
            foreach (Employee review in employeeManager.GetList())
            {

                if (review.id == id && review.designation == designation)
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
                return false;
            return true;

        }
    }
}
