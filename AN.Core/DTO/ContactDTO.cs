namespace AN.Core.DTO
{
    public class FeedBackDTO
    {        
        public string Comment { get; set; }
    }

    public class WebFeedBackDTO : FeedBackDTO
    {
        public string Topic { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
