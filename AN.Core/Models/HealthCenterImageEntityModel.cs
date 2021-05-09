namespace AN.Core.Models
{
    public partial class HealthCenterImageEntityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Order { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Url { get; set; }
        public int Size { get; set; }
        public string DeleteUrl { get; set; }
    }
}
