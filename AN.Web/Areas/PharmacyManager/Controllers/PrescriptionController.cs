using AN.BLL.DataRepository;
using AN.Core;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Extensions;
using AN.Core.Models;
using AN.Core.ViewModels;
using AN.DAL;
using AN.Web.App_Code;
using AN.Web.Areas.PharmacyManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.PharmacyManager.Controllers
{
    public class PrescriptionController : PharmacyManagerController
    {
        private readonly IPharmacyPrescriptionRepository _prescriptionRepository;
        private readonly BanobatDbContext _dbContext;
        public PrescriptionController(IWorkContext workContext, IPharmacyPrescriptionRepository prescriptionRepository, BanobatDbContext dbContext) : base(workContext)
        {
            _prescriptionRepository = prescriptionRepository;
            _dbContext = dbContext;
        }

        public IActionResult Index(PrescriptionStatus? currentStatus = null)
        {
            ViewBag.Lang = Lng;

            ViewBag.CurrentStatus = currentStatus;

            ViewBag.PrescriptionStatusList = MyEnumExtensions.EnumToSelectList<PrescriptionStatus>().ToList();

            return View(new PharmacyPrescriptionListViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody]DataTablesParameters param)
        {
            try
            {
                var filtersModel = JsonConvert.DeserializeObject<PharmacyPrescriptionFilterViewModel>(param.FiltersObject);

                filtersModel.PharmacyId = CurrentPharmacy.Id;

                var results = await _prescriptionRepository.GetDataTableAsync(param, filtersModel, Lng);

                var prescriptions = await Task.WhenAll(results.Items.Select(async (x) => new PharmacyPrescriptionListViewModel
                {
                    Id = x.Id,
                    PharmacyId = x.PharmacyId,
                    TreatmentHistoryId = x.TreatmentHistoryId,
                    Status = x.Status,
                    Pharmacy = x.Pharmacy,
                    StatusName = x.StatusName,
                    Doctor = x.Doctor,
                    Patient = x.Patient,
                    CreateDate = x.CreateDate,
                    ActionsHtml = await this.RenderViewToStringAsync("_PrescriptionItemActions", (x.Id, x.PharmacyId, x.TreatmentHistoryId, x.Status))
                }).ToList());

                return new JsonResult(new DataTablesResult<PharmacyPrescriptionListViewModel>
                {
                    Draw = param.Draw,
                    Data = prescriptions.ToList(),
                    RecordsFiltered = results.TotalSize,
                    RecordsTotal = results.TotalSize
                });
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return new JsonResult(new { error = "Internal Server Error" });
            }
        }

        public async Task<IActionResult> SetStatus(int pharmacyId, int treatmentId, PrescriptionStatus status)
        {
            await _prescriptionRepository.SetStatusAsync(pharmacyId, treatmentId, status);

            return Json(new { success = true, message = Core.Resources.EntitiesResources.Messages.ActionDoneSuccesfully });
        }

        public async Task<IActionResult> DeletePrescription(int pharmacyId, int treatmentId)
        {
            await _prescriptionRepository.DeletePrescriptionAsync(pharmacyId, treatmentId);

            return Json(new { success = true, message = Core.Resources.EntitiesResources.Messages.ActionDoneSuccesfully });
        }

        [HttpPost]
        public async Task<IActionResult> PrescriptionProcess(int prescriptionId)
        {
            var prescription = await _prescriptionRepository.GetByIdAsync(prescriptionId);

            if (prescription == null || prescription.PharmacyId != CurrentPharmacy.Id) throw new AwroNoreException(Core.Resources.EntitiesResources.Messages.PrescriptionNotFound);

            var treatmentHistory = prescription.TreatmentHistory;

            var polyclinic = treatmentHistory.Patient.ServiceSupply.ShiftCenter;

            var doctor = treatmentHistory.Patient.ServiceSupply.Person;

            var patient = treatmentHistory.Patient.Person;

            var expertise = treatmentHistory.Patient.ServiceSupply.DoctorExpertises.FirstOrDefault();

            var viewModel = new ProcessPrescriptionViewModel
            {
                Id = prescription.Id,
                HealthCenterName = Lng == Lang.KU ? polyclinic.Name_Ku : Lng == Lang.AR ? polyclinic.Name_Ar : polyclinic.Name,
                HealthCenterPhone = polyclinic.PhoneNumbers[0].PhoneNumber,
                HealthCenterAddress = Lng == Lang.KU ? polyclinic.Address_Ku : Lng == Lang.AR ? polyclinic.Address_Ar : polyclinic.Address,
                DoctorName = Lng == Lang.KU ? doctor.FullName_Ku : Lng == Lang.AR ? doctor.FullName_Ar : doctor.FullName,
                DoctorExpertise = Lng == Lang.KU ? expertise?.Expertise.Name_Ku : Lng == Lang.AR ? expertise?.Expertise.Name_Ar : expertise?.Expertise.Name,
                PatientName = Lng == Lang.KU ? patient.FullName_Ku : Lng == Lang.AR ? patient.FullName_Ar : patient.FullName,
                VisitDate = treatmentHistory.VisitDate.ToShortDateString(),
                Problems = Lng == Lang.KU ? treatmentHistory.Problems_Ku : Lng == Lang.AR ? treatmentHistory.Problems_Ar : treatmentHistory.Problems,
                Instructions = Lng == Lang.KU ? treatmentHistory.Description_Ku : Lng == Lang.AR ? treatmentHistory.Description_Ar : treatmentHistory.Description,
                Treatments = treatmentHistory.TreatmentsItems.Select(x => new PrintPrescriptTreatmentsModel
                {              
                    Id = x.Id,
                    GenericName = x.Drug?.GenericName,
                    TradeName = x.Drug?.TradeName,
                    DosageForm = x.Drug?.DosageForm,
                    StrengthVaue = x.Drug?.StrengthVaue,
                    PackageSize = x.Drug?.PackageSize,
                    PackageType = x.Drug?.PackageType,
                    Volume = x.Drug?.Volume,
                    UnitOfStrength = x.Drug?.UnitOfStrength,
                    RouteOfAdministration = x.Drug?.RouteOfAdministration,
                    UnitOfVolume = x.Drug?.UnitOfVolume,
                    Dose = x.Dosage,
                    Frequency = x.Frequency,
                    Quantity = x.Quantity,
                    Description = x.Description
                }).ToList()
            };

            return PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> PrescriptionProcessDone(int pharmacyPrescriptionId, string doneItemsJson)
        {
            var doneTreatmentIds = new List<int>();
            try
            {
                var doneItemsObject = JObject.Parse(doneItemsJson);
                foreach (var item in doneItemsObject.Properties())
                {
                    var treatmentItemId = int.Parse(item.Name);
                    var doneStatusValue = item.Value.ToString();
                    var isDone = doneStatusValue == "on";
                    if (isDone) doneTreatmentIds.Add(treatmentItemId);
                }
            }
            catch
            {
                throw new AwroNoreException("Error while read data of prescription. please try again");
            }

            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var prescription = await _dbContext.PharmacyPrescriptions.FindAsync(pharmacyPrescriptionId);

                    if (prescription == null || prescription.PharmacyId != CurrentPharmacy.Id) throw new AwroNoreException(Core.Resources.EntitiesResources.Messages.PrescriptionNotFound);

                    if(prescription.Status == PrescriptionStatus.DONE) throw new AwroNoreException(Core.Resources.EntitiesResources.Messages.PrescriptionIsDoneBefore);

                    foreach (var doneItem in doneTreatmentIds)
                    {
                        _dbContext.PharmacyDoneTreatments.Add(new Core.Domain.PharmacyDoneTreatments
                        {
                            PharmacyPrescriptionId = pharmacyPrescriptionId,
                            TreatmentId = doneItem,
                            CreatedAt = DateTime.Now                           
                        }); 
                    }

                    prescription.Status = PrescriptionStatus.DONE;

                    _dbContext.PharmacyPrescriptions.Attach(prescription);

                    _dbContext.Entry(prescription).State = EntityState.Modified;

                    await _dbContext.SaveChangesAsync();

                    transaction.Commit();
                }
            });

            return Json(new { success = true });
        }
    }
}