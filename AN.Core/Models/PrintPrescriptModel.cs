namespace AN.Core.Models
{
    public class PrintPrescriptModel
    {
        public string DoctorName { get; set; }
        public string DoctorName_Ku { get; set; }
        public string DoctorName_Ar { get; set; }
        public string DoctorMedicalCounsilNumber { get; set; }
        public string HealthCenterName { get; set; }
        public string HealthCenterName_Ku { get; set; }
        public string HealthCenterName_Ar { get; set; }
        public string HealthCenterPhone { get; set; }
        public string HealthCenterAddress { get; set; }        
        public string HealthCenterAddress_Ku { get; set; }        
        public string HealthCenterAddress_Ar { get; set; }              
        public byte[] HealthCenterLogo { get; set; }              
        public string PatientName { get; set; }
        public string PatientName_Ku { get; set; }
        public string PatientName_Ar { get; set; }
        public float PatientAge { get; set; }
        public string VisitDate { get; set; }       
        public string PatientGender { get; set; }       
        public string PatientGender_Ku { get; set; }       
        public string PatientGender_Ar { get; set; }       
    }

    public class PrintPrescriptSpecialitiesModel
    {
        public string Name { get; set; }
        public string Name_Ku { get; set; }
        public string Name_Ar { get; set; }
    }

    public class PrintPrescriptTreatmentsModel
    {
        public int Id { get; set; }

        public string GenericName { get; set; }

        public string TradeName { get; set; }

        public string StrengthVaue { get; set; }

        public string UnitOfStrength { get; set; }

        public string DosageForm { get; set; }

        public string RouteOfAdministration { get; set; }

        public string Volume { get; set; }

        public string UnitOfVolume { get; set; }

        public string PackageType { get; set; }

        public string PackageSize { get; set; }

        public string Dose { get; set; }

        public string Frequency { get; set; }

        public string Quantity { get; set; }

        public string Description { get; set; }
    }
}
