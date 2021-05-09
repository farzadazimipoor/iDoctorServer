using AN.BLL.DataRepository;
using AN.Core;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Extensions;
using AN.Core.ViewModels;
using AN.Web.App_Code;
using AN.Web.Areas.LabManager.Models;
using AN.Web.Areas.SonarManager.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.Constants.LabratoryNeeds;
using Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.LabManager.Controllers
{
    public class PrescriptionController : LabManagerController
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly ILabratoryNeedsProvider _labratoryNeedsProvider;
        public PrescriptionController(IWorkContext workContext, IPrescriptionRepository prescriptionRepository, ILabratoryNeedsProvider labratoryNeedsProvider) : base(workContext)
        {
            _prescriptionRepository = prescriptionRepository;
            _labratoryNeedsProvider = labratoryNeedsProvider;
        }

        public IActionResult Index(PrescriptionStatus? currentStatus = null)
        {
            ViewBag.Lang = Lng;

            ViewBag.CurrentStatus = currentStatus;

            ViewBag.PrescriptionStatusList = MyEnumExtensions.EnumToSelectList<PrescriptionStatus>().ToList();

            return View(new SonarPrescriptionListViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody]DataTablesParameters param)
        {
            try
            {
                var filtersModel = JsonConvert.DeserializeObject<PrescriptionFilterViewModel>(param.FiltersObject);

                filtersModel.CenterId = CurrentLab.Id;

                var results = await _prescriptionRepository.GetDataTableAsync(param, filtersModel, Lng);

                var prescriptions = await Task.WhenAll(results.Items.Select(async (x) => new SonarPrescriptionListViewModel
                {
                    Id = x.Id,
                    CenterId = x.CenterId,
                    TreatmentHistoryId = x.TreatmentHistoryId,
                    Status = x.Status,
                    SonarCenter = x.SonarCenter,
                    StatusName = x.StatusName,
                    Doctor = x.Doctor,
                    Patient = x.Patient,
                    CreateDate = x.CreateDate,
                    ActionsHtml = await this.RenderViewToStringAsync("_PrescriptionItemActions", (x.Id, x.CenterId, x.TreatmentHistoryId, x.Status))
                }).ToList());

                return new JsonResult(new DataTablesResult<SonarPrescriptionListViewModel>
                {
                    Draw = param.Draw,
                    Data = prescriptions.ToList(),
                    RecordsFiltered = results.TotalSize,
                    RecordsTotal = results.TotalSize
                });
            }
            catch (Exception e)
            {
                return new JsonResult(new { error = "Internal Server Error" });
            }
        }

        public async Task<IActionResult> SetStatus(int id, int centerId, int treatmentId, PrescriptionStatus status)
        {
            await _prescriptionRepository.SetStatusAsync(id, centerId, treatmentId, status);

            return Json(new { success = true, message = Core.Resources.EntitiesResources.Messages.ActionDoneSuccesfully });
        }

        public async Task<IActionResult> DeletePrescription(int id, int centerId, int treatmentId)
        {
            await _prescriptionRepository.DeletePrescriptionAsync(id, centerId, treatmentId);

            return Json(new { success = true, message = Core.Resources.EntitiesResources.Messages.ActionDoneSuccesfully });
        }

        [HttpPost]
        public async Task<IActionResult> ViewPrescription(int prescriptionId)
        {
            var prescription = await _prescriptionRepository.GetByIdAsync(prescriptionId);

            if (prescription == null || prescription.CenterId != CurrentLab.Id) throw new AwroNoreException(Core.Resources.EntitiesResources.Messages.PrescriptionNotFound);

            var treatmentHistory = prescription.TreatmentHistory;

            var polyclinic = treatmentHistory.Patient.ServiceSupply.ShiftCenter;

            var doctor = treatmentHistory.Patient.ServiceSupply.Person;

            var person = treatmentHistory.Patient.Person;

            var expertise = treatmentHistory.Patient.ServiceSupply.DoctorExpertises.FirstOrDefault();

            var viewModel = new LabratoryPrescriptionDetailsViewModel
            {
                Id = prescription.Id,
                TreatmentHistoryId = treatmentHistory.Id,
                HealthCenterName = Lng == Lang.KU ? polyclinic.Name_Ku : Lng == Lang.AR ? polyclinic.Name_Ar : polyclinic.Name,
                HealthCenterPhone = polyclinic.PhoneNumbers[0].PhoneNumber,
                HealthCenterAddress = Lng == Lang.KU ? polyclinic.Address_Ku : Lng == Lang.AR ? polyclinic.Address_Ar : polyclinic.Address,
                DoctorName = Lng == Lang.KU ? doctor.FullName_Ku : Lng == Lang.AR ? doctor.FullName_Ar : doctor.FullName,
                DoctorExpertise = Lng == Lang.KU ? expertise?.Expertise.Name_Ku : Lng == Lang.AR ? expertise?.Expertise.Name_Ar : expertise?.Expertise.Name,
                PatientName = Lng == Lang.KU ? person.FullName_Ku : Lng == Lang.AR ? person.FullName_Ar : person.FullName,
                PatientAge = person.Age ?? 0,
                PatientAvatar = person.RealAvatar,
                VisitDate = treatmentHistory.VisitDate.ToShortDateString(),
                Problems = Lng == Lang.KU ? treatmentHistory.Problems_Ku : Lng == Lang.AR ? treatmentHistory.Problems_Ar : treatmentHistory.Problems,
                Instructions = Lng == Lang.KU ? treatmentHistory.Description_Ku : Lng == Lang.AR ? treatmentHistory.Description_Ar : treatmentHistory.Description,
                Status = prescription.Status,
                LabNeedIds = prescription.SonarNeedIds,
                LabNeeds = prescription.SonarNeedIds?.Select(x => _labratoryNeedsProvider.GetById(x)?.Title).ToList()
            };

            ViewBag.CenterId = CurrentLab.Id;

            return PartialView(viewModel);
        }
    }
}