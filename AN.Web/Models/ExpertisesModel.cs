using System.Collections.Generic;

namespace AN.Web.Areas.Public.Models
{
    public class DoctorsExpertisesModel
    {
        public int ExpertiseCategoryId { get; set; }
        public string ExpertiseCategory { get; set; }
        public bool ExpertiseCategorySelected { get; set; }
        public List<ExpertiseModel> Expertises { get; set; }        
    }

    public class ExpertiseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
}