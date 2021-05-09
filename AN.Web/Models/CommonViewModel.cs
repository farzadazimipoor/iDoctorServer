namespace AN.Web.Models
{
    public class CommonViewModel
    {
        public string LoginAs { get; set; }
        public string User_Name { get; set; }
        public string User_Family { get; set; }
        public string User_Avatar { get; set; }
        public int MessagesCount { get; set; }
        public string HaveMessage { get; set; }
    }    
    

    public class UploadFilesResultViewModel
    {
        public int? Id { get; set; }
        public string name { get; set; }
        public double size { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string deleteUrl { get; set; }
        public string thumbnailUrl { get; set; }
        public string deleteType { get; set; }
    }

    public class MVCResultModel
    {
        public MVCResultStatus status { get; set; }
        public string message { get; set; }
    }

    public enum MVCResultStatus
    {
        success,
        warning,
        danger
    }

    public class DayAppointsStatistics
    {
        public string Date { get; set; }
        public int Counts { get; set; }
    }
}