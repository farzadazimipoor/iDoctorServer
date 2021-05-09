namespace AN.Web.Areas.Public.Models
{
    public class ServiceSupplyModel
    {
        public int serviceSupplyId { get; set; }
        public int poliClinicId { get; set; }
        public int doctorId { get; set; }
        public string doctorFullName { get; set; }        
        public string doctorScientificCategory { get; set; }
        public string doctorMedicalCouncilNumber { get; set; }
        public string reservationType { get; set; }
        public bool haveEmptyTurns { get; set; }
        
    }
}