using AN.Core.Data;
using System;

namespace AN.Core.Domain
{
    public class TreatmentsItems : BaseEntity
    {                   
        public string CustomDrugName { get; set; }        
        public string CustomDrugName_Ku { get; set; }       
        public string CustomDrugName_Ar { get; set; }
       
        public string Dosage { get; set; }
       
        public string Frequency { get; set; }
      
        public string Quantity { get; set; }

        public DateTime DateStarted { get; set; }
       
        public string Description { get; set; }       
        public string Description_Ku { get; set; }       
        public string Description_Ar { get; set; }
       
        public int? DrugId { get; set; }       
       
        public int TreatmentHistoryId { get; set; }
        
        public virtual Drug Drug { get; set; }
      
        public virtual TreatmentHistory TreatmentHistory { get; set; }
    }
}
