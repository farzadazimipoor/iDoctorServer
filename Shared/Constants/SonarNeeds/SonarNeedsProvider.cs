using Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Constants.SonarNeeds
{
    public class SonarNeedsProvider : ISonarNeedsProvider
    {
        public static readonly SonarNeedModel DopplerLowerLimbsVerons = new SonarNeedModel
        {
            Id = 1,
            Title = "Doppler lower limbs verons",
            Title_Ku = "Doppler lower limbs verons",
            Title_Ar = "Doppler lower limbs verons",            
        };

        public static readonly SonarNeedModel DopplerLowerLimbsBilal = new SonarNeedModel
        {
            Id = 2,
            Title = "Doppler lower limbs bilal",
            Title_Ku = "Doppler lower limbs bilal",
            Title_Ar = "Doppler lower limbs bilal",
        };

        public static readonly SonarNeedModel DopplerKidneys = new SonarNeedModel
        {
            Id = 3,
            Title = "Doppler kidneys",
            Title_Ku = "Doppler kidneys",
            Title_Ar = "Doppler kidneys",
        };

        public static readonly SonarNeedModel AbdomenPelvisUs = new SonarNeedModel
        {
            Id = 4,
            Title = "Abdomen_pelvis us",
            Title_Ku = "Abdomen_pelvis us",
            Title_Ar = "Abdomen_pelvis us",
        };

        public static readonly SonarNeedModel AspirationFluid = new SonarNeedModel
        {
            Id = 5,
            Title = "Aspiration fluid (Plearal or asct)",
            Title_Ku = "Aspiration fluid (Plearal or asct)",
            Title_Ar = "Aspiration fluid (Plearal or asct)",
        };

        public static readonly SonarNeedModel TransneetalProstate = new SonarNeedModel
        {
            Id = 6,
            Title = "Transneetal prostate",
            Title_Ku = "Transneetal prostate",
            Title_Ar = "Transneetal prostate",
        };

        public static readonly SonarNeedModel Pelvis = new SonarNeedModel
        {
            Id = 7,
            Title = "Pelvis",
            Title_Ku = "Pelvis",
            Title_Ar = "Pelvis",
        };

        public static readonly SonarNeedModel BPP = new SonarNeedModel
        {
            Id = 8,
            Title = "BPP (Biophysical profile)",
            Title_Ku = "BPP (Biophysical profile)",
            Title_Ar = "BPP (Biophysical profile)",
        };

        public static readonly SonarNeedModel DopplerArterial = new SonarNeedModel
        {
            Id = 9,
            Title = "Doppler arterial",
            Title_Ku = "Doppler arterial",
            Title_Ar = "Doppler arterial",
        };

        public static readonly SonarNeedModel ObsUISDoppler = new SonarNeedModel
        {
            Id = 10,
            Title = "Obs, UIS + Doppler",
            Title_Ku = "Obs, UIS + Doppler",
            Title_Ar = "Obs, UIS + Doppler",
        };

        public static readonly SonarNeedModel HSG = new SonarNeedModel
        {
            Id = 11,
            Title = "HSG",
            Title_Ku = "HSG",
            Title_Ar = "HSG",
        };

        public static readonly SonarNeedModel Breast = new SonarNeedModel
        {
            Id = 12,
            Title = "Breast",
            Title_Ku = "Breast",
            Title_Ar = "Breast",
        };

        public static readonly SonarNeedModel Scolal = new SonarNeedModel
        {
            Id = 13,
            Title = "Scolal",
            Title_Ku = "Scolal",
            Title_Ar = "Scolal",
        };

        public static readonly SonarNeedModel SoftTissue = new SonarNeedModel
        {
            Id = 14,
            Title = "Soft tissue",
            Title_Ku = "Soft tissue",
            Title_Ar = "Soft tissue",
        };

        public static readonly SonarNeedModel Carotid = new SonarNeedModel
        {
            Id = 15,
            Title = "Carotid",
            Title_Ku = "Carotid",
            Title_Ar = "Carotid",
        };

        public static readonly SonarNeedModel FNA = new SonarNeedModel
        {
            Id = 16,
            Title = "FNA",
            Title_Ku = "FNA",
            Title_Ar = "FNA",
        };

        public static readonly SonarNeedModel BiopsyUis = new SonarNeedModel
        {
            Id = 17,
            Title = "Biopsy uis",
            Title_Ku = "Biopsy uis",
            Title_Ar = "Biopsy uis",
        };

        public static readonly SonarNeedModel NeckChild = new SonarNeedModel
        {
            Id = 18,
            Title = "Neck child",
            Title_Ku = "Neck child",
            Title_Ar = "Neck child",
        };

        public static readonly SonarNeedModel NeckAdult = new SonarNeedModel
        {
            Id = 19,
            Title = "Neck adult",
            Title_Ku = "Neck adult",
            Title_Ar = "Neck adult",
        };

        public static readonly SonarNeedModel ObsUIS = new SonarNeedModel
        {
            Id = 20,
            Title = "Obs, UIS",
            Title_Ku = "Obs, UIS",
            Title_Ar = "Obs, UIS",
        };

        public IEnumerable<SonarNeedModel> GetAll()
        {
            return new[]
            {
                DopplerLowerLimbsVerons,
                DopplerLowerLimbsBilal,
                DopplerKidneys,
                AbdomenPelvisUs,
                AspirationFluid,
                TransneetalProstate,
                Pelvis,
                BPP,
                DopplerArterial,
                ObsUISDoppler,
                HSG,
                Breast,
                Scolal,
                SoftTissue,
                Carotid,
                FNA,
                BiopsyUis,
                NeckChild,
                NeckAdult,
                ObsUIS
            };
        }

        public SonarNeedModel GetById(int id)
        {
            return GetAll().Where(x => x.Id == id).Select(x => new SonarNeedModel
            {
                Id = x.Id,
                Title = x.Title,
                Title_Ku = x.Title_Ku,
                Title_Ar = x.Title_Ar
            }).FirstOrDefault();
        }
    }
}
