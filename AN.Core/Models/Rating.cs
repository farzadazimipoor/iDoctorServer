using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Models
{

    [ComplexType]
    public class Rating
    {
        public double? TotalRating { get; set; }
        public int? TotalRaters { get; set; }
        public double? AverageRating { get; set; }
    }

}
