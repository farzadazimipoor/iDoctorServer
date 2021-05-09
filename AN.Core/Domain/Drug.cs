using AN.Core.Data;
using System.Collections.Generic;

namespace AN.Core.Domain
{
    public class Drug : BaseEntity
    {
        public Drug()
        {
            DrugGroups = new HashSet<DrugGroups>();
            TreatmentsItems = new HashSet<TreatmentsItems>();
        }

        public string GenericName { get; set; }
        public string GenericName_Ku { get; set; }
        public string GenericName_Ar { get; set; }

        public string TradeName { get; set; }

        public string StrengthVaue { get; set; }

        public string UnitOfStrength { get; set; }

        public string DosageForm { get; set; }

        public string RouteOfAdministration { get; set; }

        public string ATCCode1 { get; set; }

        public string ATCCode2 { get; set; }

        public string Volume { get; set; }

        public string UnitOfVolume { get; set; }

        public string PackageType { get; set; }

        public string PackageSize { get; set; }

        public string LegalStatus { get; set; }

        public string ShelfLifeInMonth { get; set; }

        public string StorageConditions { get; set; }

        public string EffectMechanism { get; set; }
        public string EffectMechanism_Ku { get; set; }
        public string EffectMechanism_Ar { get; set; }

        public string ConsumptionTypes { get; set; }
        public string ConsumptionTypes_Ku { get; set; }
        public string ConsumptionTypes_Ar { get; set; }

        public string SideEffects { get; set; }
        public string SideEffects_Ku { get; set; }
        public string SideEffects_Ar { get; set; }

        public virtual ICollection<DrugGroups> DrugGroups { get; set; }

        public virtual ICollection<TreatmentsItems> TreatmentsItems { get; set; }
    }
}
