using AN.Core.Enums;
using System;
using System.Collections.Generic;

namespace AN.Core.DTO.Treatment
{
    public class TreatmentDTO : BaseDTO
    {
        public int UserId { get; set; }
        public string Fullname { get; set; }
        public int ServiceSupplyId { get; set; }
        public string DoctorName { get; set; }
        public string Speciality { get; set; }
        public string VisitDate { get; set; }
    }

    public class TreatmentsResultDTO
    {
        public long TotalCount { get; set; }
        public List<TreatmentDTO> Treatments { get; set; }
    }

    public class TreatmentDetailsDTO : TreatmentDTO
    {
        public string Problems { get; set; }

        public string Treatments { get; set; }

        public string Description { get; set; }

        public List<TreatmentItemDTO> TreatmentItems { get; set; }
        public List<TreatmentAttachDTO> TreatmentAttaches { get; set; }
    }

    public class TreatmentItemDTO : BaseDTO
    {
        public string DrugName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Quantity { get; set; }
        public DateTime DateStarted { get; set; }
        public string Description { get; set; }
    }

    public class TreatmentAttachDTO : BaseDTO
    {
        public FileType FileType { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public string CreatedAt { get; set; }
        public string Description { get; set; }
    }
}
