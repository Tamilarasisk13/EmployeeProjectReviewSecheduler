using System;
using System.Text.RegularExpressions;
namespace EmployeeProjectReviewScheduler
{
    class  ValidateEmployeeDetails
    {
        public static bool ValidateName(string name)
        {
            if (Regex.Match(name, "^[A-Z][a-zA-Z]*$").Success)
                return true;
            return false;
        }
        public static bool ValidateMobileNumber(string mobileNumber)
        {

            if (Regex.Match(mobileNumber, "^[3-9][0-9]{9}$").Success)
                return true;
            return false;
        }
        public static bool ValidateId(string id)
        {
            try
            {
                
                if (id.Length == 4)
                {
                    int iId = Convert.ToInt16(id);
                    if(iId>=1 && iId<=9999)
                    return true;
                    return false;
                }
                return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public static bool ValidateDate(string date)
        {
            try
            {
                string[] dateParts = date.Split('/');
                DateTime testDate = new
                DateTime(Convert.ToInt32(dateParts[2]),
                Convert.ToInt32(dateParts[0]),
                Convert.ToInt32(dateParts[1]));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool ValidateTime(string time)
        {
            TimeSpan dummyOutput;
            string stime = time.Substring(0, 4);
            if (TimeSpan.TryParse(stime, out dummyOutput))
                return true;
            return false;
        }
        //public static bool ValidateDuration(string duration)
        //{
        //    TimeSpan dummyOutput;
        //    string sduration = duration.Substring(0, 4);
        //    if (TimeSpan.TryParse(sduration, out dummyOutput))
        //        return true;
        //    return false;
        //}
        public static bool ValidateEmailId(string email)
        {
            Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            if (regex.Match(email).Success)
            {
                return true;
            }
            return false;
        }
        public static bool ValidatePassword(string password)
        {
            if (Regex.Match(password, @"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^(.{8,15})$").Success)
                return true;
            return false;
        }
    }
}
