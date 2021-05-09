namespace AN.Core.DTO
{
    public class InsuranceItemDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Logo { get; set; }
    }

    public class InsuranceServiceItemDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public bool HasAttachments { get; set; } = false;
        public string Photo { get; set; }
    }
}
