using AN.BLL.DataRepository;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.Core;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Extensions;
using AN.Core.ViewModels;
using AN.DAL;
using AN.Web.App_Code;
using AN.Web.Areas.SonarManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shared.Constants.SonarNeeds;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.SonarManager.Controllers
{
    public class PrescriptionController : SonarManagerController
    {
        private readonly ISonarNeedsProvider _sonarNeedsProvider;
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly BanobatDbContext _dbContext;
        public PrescriptionController(IWorkContext workContext, ISonarNeedsProvider sonarNeedsProvider, IPrescriptionRepository prescriptionRepository, IServiceSupplyService serviceSupplyService, BanobatDbContext dbContext) : base(workContext)
        {
            _sonarNeedsProvider = sonarNeedsProvider;
            _prescriptionRepository = prescriptionRepository;
            _serviceSupplyService = serviceSupplyService;
            _dbContext = dbContext;
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

                filtersModel.CenterId = CurrentSonar.Id;

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

        public async Task<IActionResult> SetStatus(int id, int sonarId, int treatmentId, PrescriptionStatus status)
        {
            var prescription = await _dbContext.SonarPrescriptions.FirstOrDefaultAsync(x => x.Id == id && x.CenterId == CurrentSonar.Id && x.TreatmentHistoryId == treatmentId);

            if (prescription == null) throw new AwroNoreException(Core.Resources.EntitiesResources.Messages.PrescriptionNotFound);

            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    _dbContext.SonarPrescriptions.Attach(prescription);

                    _dbContext.Entry(prescription).State = EntityState.Modified;

                    prescription.Status = status;

                    if (status == PrescriptionStatus.DONE)
                    {
                        var treatmentHistory = await _dbContext.TreatmentHistories.FindAsync(treatmentId);

                        if (treatmentHistory == null) throw new AwroNoreException("Treatment not found");

                        var sonarPatientExist = await _dbContext.Patients.AnyAsync(x => x.CenterId == CurrentSonar.Id && x.PersonId == treatmentHistory.Patient.PersonId);

                        if (!sonarPatientExist)
                        {
                            var sonarPatient = new Patient
                            {
                                PersonId = treatmentHistory.Patient.PersonId,
                                CenterId = CurrentSonar.Id,
                                CreatedAt = DateTime.Now
                            };

                            await _dbContext.Patients.AddAsync(sonarPatient);
                        }

                        await _dbContext.SaveChangesAsync();
                    }

                    transaction.Commit();
                }
            });

            return Json(new { success = true, message = Core.Resources.EntitiesResources.Messages.ActionDoneSuccesfully });
        }

        public async Task<IActionResult> DeletePrescription(int id, int sonarId, int treatmentId)
        {
            await _prescriptionRepository.DeletePrescriptionAsync(id, sonarId, treatmentId);

            return Json(new { success = true, message = Core.Resources.EntitiesResources.Messages.ActionDoneSuccesfully });
        }

        [HttpPost]
        public async Task<IActionResult> ViewPrescription(int prescriptionId)
        {
            var prescription = await _prescriptionRepository.GetByIdAsync(prescriptionId);

            if (prescription == null || prescription.CenterId != CurrentSonar.Id) throw new AwroNoreException(Core.Resources.EntitiesResources.Messages.PrescriptionNotFound);

            var treatmentHistory = prescription.TreatmentHistory;

            var polyclinic = treatmentHistory.Patient.ServiceSupply.ShiftCenter;

            var doctor = treatmentHistory.Patient.ServiceSupply.Person;

            var person = treatmentHistory.Patient.Person;

            var expertise = treatmentHistory.Patient.ServiceSupply.DoctorExpertises.FirstOrDefault();

            var viewModel = new SonarPrescriptionDetailsViewModel
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
                SonarNeedIds = prescription.SonarNeedIds ?? new List<int>(),
                SonarNeeds = prescription.SonarNeedIds != null ? prescription.SonarNeedIds.Select(x => _sonarNeedsProvider.GetById(x)?.Title).ToList() : new List<string>()
            };

            ViewBag.SonarCenterId = CurrentSonar.Id;

            return PartialView(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CreateUpdate(int prescriptionId)
        {
            var prescription = await _prescriptionRepository.GetByIdAsync(prescriptionId);

            if (prescription == null || prescription.CenterId != CurrentSonar.Id) throw new AwroNoreException(Core.Resources.EntitiesResources.Messages.PrescriptionNotFound);

            ViewBag.Doctors = await _serviceSupplyService.GetSelectListAsync(CurrentSonar.Id, CurrentSonar.ServiceSupplyIds);
                    
            ViewBag.SonarNeeds = _sonarNeedsProvider.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = Lng == Lang.KU ? x.Title_Ku : Lng == Lang.AR ? x.Title_Ar : x.Title
            }).ToList();

            var model = new CreateUpdateSonarPrescriptionViewModel
            {
                Id = prescription.Id,
                SonarCenterId = prescription.CenterId,
                Problems = prescription.TreatmentHistory.Problems,
                Description = prescription.TreatmentHistory.Description,
                DoctorId = prescription.TreatmentHistory.Patient.ServiceSupplyId.Value,
                PersonId = prescription.TreatmentHistory.Patient.PersonId,
                VisitDate = prescription.TreatmentHistory.VisitDate.ToString("yyyy-MM-dd"),
                PatientVisitAge = prescription.PatientVisitAge,
                PatientVisitHeight = prescription.PatientVisitHeight,
                PatientVisitWeight = prescription.PatientVisitWeight,
                SonarNeeds = prescription.SonarNeedIds
            };

            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpdate(CreateUpdateSonarPrescriptionViewModel model)
        {
            var prescription = await _dbContext.SonarPrescriptions.FirstOrDefaultAsync(x => x.CenterId == CurrentSonar.Id && x.Id == model.Id);

            if (prescription == null) throw new AwroNoreException(Core.Resources.EntitiesResources.Messages.PrescriptionNotFound);

            var treatmentHistory = await _dbContext.TreatmentHistories.FindAsync(prescription.TreatmentHistoryId);

            if (treatmentHistory == null) throw new AwroNoreException("Patient treatment history not found");

            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        // Update prescription
                        _dbContext.SonarPrescriptions.Attach(prescription);

                        _dbContext.Entry(prescription).State = EntityState.Modified;

                        prescription.PatientVisitAge = model.PatientVisitAge;

                        prescription.PatientVisitHeight = model.PatientVisitHeight;

                        prescription.PatientVisitWeight = model.PatientVisitWeight;

                        prescription.SonarNeedIds = model.SonarNeeds;

                        // Update treatment history
                        _dbContext.TreatmentHistories.Attach(treatmentHistory);

                        _dbContext.Entry(treatmentHistory).State = EntityState.Modified;

                        treatmentHistory.VisitDate = DateTime.Parse(model.VisitDate);

                        treatmentHistory.Description = model.Description;

                        treatmentHistory.Description_Ar = model.Description;

                        treatmentHistory.Description_Ku = model.Description;

                        // Save changes
                        await _dbContext.SaveChangesAsync();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            });

            return Json(new { success = true });
        }
    }
}