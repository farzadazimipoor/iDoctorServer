using Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Constants.LabratoryNeeds
{
    public class LabratoryNeedsProvider : ILabratoryNeedsProvider
    {
        public static readonly LabratoryNeedModel CBC = new LabratoryNeedModel
        {
            Id = 1,
            Title = "Complete blood count (CBC)",
            Title_Ku = "Complete blood count (CBC)",
            Title_Ar = "Complete blood count (CBC)",
        };

        public static readonly LabratoryNeedModel PT = new LabratoryNeedModel
        {
            Id = 2,
            Title = "Prothrombin Time (PT) (Pro Time)",
            Title_Ku = "Prothrombin Time (PT) (Pro Time)",
            Title_Ar = "Prothrombin Time (PT) (Pro Time)",
        };

        public static readonly LabratoryNeedModel Glucose = new LabratoryNeedModel
        {
            Id = 3,
            Title = "Glucose",
            Title_Ku = "Glucose",
            Title_Ar = "Glucose",
        };

        public static readonly LabratoryNeedModel Sodium = new LabratoryNeedModel
        {
            Id = 4,
            Title = "Sodium",
            Title_Ku = "Sodium",
            Title_Ar = "Sodium",
        };

        public static readonly LabratoryNeedModel Potassium = new LabratoryNeedModel
        {
            Id = 5,
            Title = "Potassium",
            Title_Ku = "Potassium",
            Title_Ar = "Potassium",
        };

        public static readonly LabratoryNeedModel Calcium = new LabratoryNeedModel
        {
            Id = 6,
            Title = "Calcium",
            Title_Ku = "Calcium",
            Title_Ar = "Calcium",
        };

        public static readonly LabratoryNeedModel Chloride = new LabratoryNeedModel
        {
            Id = 7,
            Title = "Chloride",
            Title_Ku = "Chloride",
            Title_Ar = "Chloride",
        };

        public static readonly LabratoryNeedModel CarbonDioxide = new LabratoryNeedModel
        {
            Id = 8,
            Title = "Carbon Dioxide",
            Title_Ku = "Carbon Dioxide",
            Title_Ar = "Carbon Dioxide",
        };

        public static readonly LabratoryNeedModel BUN = new LabratoryNeedModel
        {
            Id = 9,
            Title = "Blood Urea Nitrogen (BUN)",
            Title_Ku = "Blood Urea Nitrogen (BUN)",
            Title_Ar = "Blood Urea Nitrogen (BUN)",
        };

        public static readonly LabratoryNeedModel Creatinine = new LabratoryNeedModel
        {
            Id = 10,
            Title = "Creatinine",
            Title_Ku = "Creatinine",
            Title_Ar = "Creatinine",
        };

        public static readonly LabratoryNeedModel Albumin = new LabratoryNeedModel
        {
            Id = 11,
            Title = "Albumin",
            Title_Ku = "Albumin",
            Title_Ar = "Albumin",
        };

        public static readonly LabratoryNeedModel TotalBilirubin = new LabratoryNeedModel
        {
            Id = 12,
            Title = "Total Bilirubin",
            Title_Ku = "Total Bilirubin",
            Title_Ar = "Total Bilirubin",
        };

        public static readonly LabratoryNeedModel TotalProtein = new LabratoryNeedModel
        {
            Id = 13,
            Title = "Total Protein",
            Title_Ku = "Total Protein",
            Title_Ar = "Total Protein",
        };

        public static readonly LabratoryNeedModel AlanineAminotransferase = new LabratoryNeedModel
        {
            Id = 14,
            Title = "Alanine Aminotransferase",
            Title_Ku = "Alanine Aminotransferase",
            Title_Ar = "Alanine Aminotransferase",
        };

        public static readonly LabratoryNeedModel AlkalinePhosphatase = new LabratoryNeedModel
        {
            Id = 15,
            Title = "Alkaline Phosphatase",
            Title_Ku = "Alkaline Phosphatase",
            Title_Ar = "Alkaline Phosphatase",
        };

        public static readonly LabratoryNeedModel AspartateAminotransferase = new LabratoryNeedModel
        {
            Id = 16,
            Title = "Aspartate Aminotransferase",
            Title_Ku = "Aspartate Aminotransferase",
            Title_Ar = "Aspartate Aminotransferase",
        };

        public static readonly LabratoryNeedModel TotalCholestrol = new LabratoryNeedModel
        {
            Id = 17,
            Title = "Total Cholestrol (TC)",
            Title_Ku = "Total Cholestrol (TC)",
            Title_Ar = "Total Cholestrol (TC)",
        };

        public static readonly LabratoryNeedModel Cholestrol = new LabratoryNeedModel
        {
            Id = 18,
            Title = "Cholestrol",
            Title_Ku = "Cholestrol",
            Title_Ar = "Cholestrol",
        };

        public static readonly LabratoryNeedModel Triglycerides = new LabratoryNeedModel
        {
            Id = 19,
            Title = "Triglycerides (TG)",
            Title_Ku = "Triglycerides (TG)",
            Title_Ar = "Triglycerides (TG)",
        };

        public static readonly LabratoryNeedModel HighDensityLipoprotein = new LabratoryNeedModel
        {
            Id = 20,
            Title = "High-density Lipoprotein (HDL)",
            Title_Ku = "High-density Lipoprotein (HDL)",
            Title_Ar = "High-density Lipoprotein (HDL)",
        };

        public static readonly LabratoryNeedModel LowDensityLipoporotein = new LabratoryNeedModel
        {
            Id = 21,
            Title = "Low-density Lipoporotein (LDL)",
            Title_Ku = "Low-density Lipoporotein (LDL)",
            Title_Ar = "Low-density Lipoporotein (LDL)",
        };

        public static readonly LabratoryNeedModel VeryLowDensityLipoprotein = new LabratoryNeedModel
        {
            Id = 22,
            Title = "Very low-density Lipoprotein (VLDL)",
            Title_Ku = "Very low-density Lipoprotein (VLDL)",
            Title_Ar = "Very low-density Lipoprotein (VLDL)",
        };

        public static readonly LabratoryNeedModel TheRatioOfTotalCholestrolToHDL = new LabratoryNeedModel
        {
            Id = 23,
            Title = "The ratio of total cholestrol to HDL",
            Title_Ku = "The ratio of total cholestrol to HDL",
            Title_Ar = "The ratio of total cholestrol to HDL",
        };

        public static readonly LabratoryNeedModel TheRatioOfLDLToHDL = new LabratoryNeedModel
        {
            Id = 24,
            Title = "The ratio of LDL to HDL",
            Title_Ku = "The ratio of LDL to HDL",
            Title_Ar = "The ratio of LDL to HDL",
        };

        public static readonly LabratoryNeedModel AlanineTransaminase = new LabratoryNeedModel
        {
            Id = 25,
            Title = "Alanine Transaminase",
            Title_Ku = "Alanine Transaminase",
            Title_Ar = "Alanine Transaminase",
        };

        public static readonly LabratoryNeedModel AspartateTransaminase = new LabratoryNeedModel
        {
            Id = 26,
            Title = "Aspartate Transaminase",
            Title_Ku = "Aspartate Transaminase",
            Title_Ar = "Aspartate Transaminase",
        };

        public static readonly LabratoryNeedModel Bilirubin = new LabratoryNeedModel
        {
            Id = 27,
            Title = "Bilirubin",
            Title_Ku = "Bilirubin",
            Title_Ar = "Bilirubin",
        };

        public static readonly LabratoryNeedModel DirectBilirubin = new LabratoryNeedModel
        {
            Id = 28,
            Title = "Direct Bilirubin",
            Title_Ku = "Direct Bilirubin",
            Title_Ar = "Direct Bilirubin",
        };

        public static readonly LabratoryNeedModel GammaGlutamylTransferase = new LabratoryNeedModel
        {
            Id = 29,
            Title = "Gamma-glutamyltransferase (GGT)",
            Title_Ku = "Gamma-glutamyltransferase (GGT)",
            Title_Ar = "Gamma-glutamyltransferase (GGT)",
        };

        public static readonly LabratoryNeedModel L_LactateDehydrogenase = new LabratoryNeedModel
        {
            Id = 30,
            Title = "L-lactate dehydrogenase (LD)",
            Title_Ku = "L-lactate dehydrogenase (LD)",
            Title_Ar = "L-lactate dehydrogenase (LD)",
        };

        public static readonly LabratoryNeedModel ThyroidStimulatingHormone = new LabratoryNeedModel
        {
            Id = 31,
            Title = "Thyroid Stimulating Hormone (TSH)",
            Title_Ku = "Thyroid Stimulating Hormone (TSH)",
            Title_Ar = "Thyroid Stimulating Hormone (TSH)",
        };

        public static readonly LabratoryNeedModel Thyroxine = new LabratoryNeedModel
        {
            Id = 32,
            Title = "Thyroxine (T4)",
            Title_Ku = "Thyroxine (T4)",
            Title_Ar = "Thyroxine (T4)",
        };

        public static readonly LabratoryNeedModel Tri_Iodothyronine = new LabratoryNeedModel
        {
            Id = 33,
            Title = "Tri-iodothyronine (T3)",
            Title_Ku = "Tri-iodothyronine (T3)",
            Title_Ar = "Tri-iodothyronine (T3)",
        };

        public static readonly LabratoryNeedModel ParaThyroidHormone = new LabratoryNeedModel
        {
            Id = 34,
            Title = "Parathyroid hormone (PTH)",
            Title_Ku = "Parathyroid hormone (PTH)",
            Title_Ar = "Parathyroid hormone (PTH)",
        };

        public static readonly LabratoryNeedModel LuteinizingHormone = new LabratoryNeedModel
        {
            Id = 35,
            Title = "Luteinizing Hormone (LH)",
            Title_Ku = "Luteinizing Hormone (LH)",
            Title_Ar = "Luteinizing Hormone (LH)",
        };

        public static readonly LabratoryNeedModel GrowthHormone = new LabratoryNeedModel
        {
            Id = 36,
            Title = "Growth Hormone",
            Title_Ku = "Growth Hormone",
            Title_Ar = "Growth Hormone",
        };

        public static readonly LabratoryNeedModel FollicleStimulatingHormone = new LabratoryNeedModel
        {
            Id = 37,
            Title = "Follicle Stimulating Hormone (FSH)",
            Title_Ku = "Follicle Stimulating Hormone (FSH)",
            Title_Ar = "Follicle Stimulating Hormone (FSH)",
        };

        public static readonly LabratoryNeedModel Dihydrotestosterone = new LabratoryNeedModel
        {
            Id = 38,
            Title = "Dihydrotestosterone (DHT)",
            Title_Ku = "Dihydrotestosterone (DHT)",
            Title_Ar = "Dihydrotestosterone (DHT)",
        };

        public static readonly LabratoryNeedModel Renin = new LabratoryNeedModel
        {
            Id = 39,
            Title = "Renin",
            Title_Ku = "Renin",
            Title_Ar = "Renin",
        };

        public static readonly LabratoryNeedModel Aldosterone = new LabratoryNeedModel
        {
            Id = 40,
            Title = "Aldosterone",
            Title_Ku = "Aldosterone",
            Title_Ar = "Aldosterone",
        };

        public static readonly LabratoryNeedModel Vitamin_D = new LabratoryNeedModel
        {
            Id = 41,
            Title = "Vitamin D",
            Title_Ku = "Vitamin D",
            Title_Ar = "Vitamin D",
        };

        public static readonly LabratoryNeedModel Estrogen = new LabratoryNeedModel
        {
            Id = 42,
            Title = "Estrogen",
            Title_Ku = "Estrogen",
            Title_Ar = "Estrogen",
        };

        public static readonly LabratoryNeedModel Testosterone = new LabratoryNeedModel
        {
            Id = 43,
            Title = "Testosterone",
            Title_Ku = "Testosterone",
            Title_Ar = "Testosterone",
        };

        public static readonly LabratoryNeedModel Cortisol = new LabratoryNeedModel
        {
            Id = 44,
            Title = "Cortisol",
            Title_Ku = "Cortisol",
            Title_Ar = "Cortisol",
        };

        public static readonly LabratoryNeedModel Prolactin = new LabratoryNeedModel
        {
            Id = 45,
            Title = "Prolactin",
            Title_Ku = "Prolactin",
            Title_Ar = "Prolactin",
        };

        public static readonly LabratoryNeedModel Hemoglobin_A1C = new LabratoryNeedModel
        {
            Id = 46,
            Title = "Hemoglobin A1C",
            Title_Ku = "Hemoglobin A1C",
            Title_Ar = "Hemoglobin A1C",
        };

        public IEnumerable<LabratoryNeedModel> GetAll()
        {
            return new[]
            {
                CBC,
                PT,
                Glucose,
                Sodium,
                Potassium,
                Calcium,
                Chloride,
                CarbonDioxide,
                BUN,
                Creatinine,
                Albumin,
                TotalBilirubin,
                TotalProtein,
                AlanineAminotransferase,
                AlkalinePhosphatase,
                AspartateAminotransferase,
                TotalCholestrol,
                Cholestrol,
                Triglycerides,
                HighDensityLipoprotein,
                LowDensityLipoporotein,
                VeryLowDensityLipoprotein,
                TheRatioOfTotalCholestrolToHDL,
                TheRatioOfLDLToHDL,
                AlanineTransaminase,
                AspartateTransaminase,
                Bilirubin,
                DirectBilirubin,
                GammaGlutamylTransferase,
                L_LactateDehydrogenase,
                ThyroidStimulatingHormone,
                Thyroxine,
                Tri_Iodothyronine,
                ParaThyroidHormone,
                LuteinizingHormone,
                GrowthHormone,
                FollicleStimulatingHormone,
                Dihydrotestosterone,
                Renin,
                Aldosterone,
                Vitamin_D,
                Estrogen,
                Testosterone,
                Cortisol,
                Prolactin,
                Hemoglobin_A1C
            };
        }

        public LabratoryNeedModel GetById(int id)
        {
            return GetAll().Where(x => x.Id == id).Select(x => new LabratoryNeedModel
            {
                Id = x.Id,
                Title = x.Title,
                Title_Ku = x.Title_Ku,
                Title_Ar = x.Title_Ar
            }).FirstOrDefault();
        }
    }
}
