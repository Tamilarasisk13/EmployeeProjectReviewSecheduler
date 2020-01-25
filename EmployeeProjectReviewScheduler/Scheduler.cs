

namespace EmployeeProjectReviewScheduler
{
    class Scheduler
    {
        public string revieweeName { get; set; }
        public string revieweeId { get; set; }
        public string reviewerName { get; set; }
        public string reviewerId { get; set; }
        public string reviewDate { get; set; }
        public string reviewTime { get; set; }
        public string reviewDuration { get; set; }
        public Scheduler(string revieweeName,string revieweeId,string reviewerName,string reviewerId,string reviewDate,string reviewTime,string reviewDuration)
        {
            this.revieweeName = revieweeName;
            this.revieweeId = revieweeId;
            this.reviewerName = reviewerName;
            this.reviewerId = reviewerId;
            this.reviewDate = reviewDate;
            this.reviewTime = reviewTime;
            this.reviewDuration = reviewDuration;
        }
    }
}
