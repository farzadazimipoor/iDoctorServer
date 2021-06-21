namespace AN.Core.DTO.Rating
{
    public class RatingDTO
    {
        public int? AppointmentId { get; set; }
        public int UserId { get; set; }
        public int ServiceSupplyId { get; set; }
        public double AverageRating { get; set; }
        public string Review { get; set; }
    }
}
