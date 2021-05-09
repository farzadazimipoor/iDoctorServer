using AN.BLL.Core.Services.Messaging.Notifications;
using AN.BLL.DataRepository;
using AN.BLL.DataRepository.Appointments;
using AN.BLL.DataRepository.Drugs;
using AN.BLL.DataRepository.Patients;
using AN.BLL.DataRepository.Persons;
using AN.BLL.DataRepository.Polyclinics;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.BLL.DataRepository.TreatmentHistories;
using AN.BLL.Helpers;
using AN.Core;
using AN.Core.Domain;
using AN.Core.DTO;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Extensions;
using AN.Core.Models;
using AN.Core.Resources.EntitiesResources;
using AN.Core.ViewModels;
using AN.DAL;
using AN.Web.AppCode.Extensions;
using AN.Web.Areas.PolyClinicManager.Models;
using AN.Web.Helper;
using AN.Web.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AWRO.Helper.UIHelper.Grid;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shared.Constants.LabratoryNeeds;
using Shared.Constants.SonarNeeds;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.PolyClinicManager.Controllers
{
    public class TreatmentHistoryController : PolyclinicManagerController
    {
        #region Fields
        private readonly IHttpContextAccessor _context;
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IPersonService _personService;
        private readonly ITreatmentHistoryService _treatmentHistoryService;
        private readonly IDrugsService _drugsService;
        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly INotificationService _notificationService;
        private readonly IPharmacyRepository _pharmacyRepository;
        private readonly IShiftCenterService _shiftCenterService;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ISonarNeedsProvider _sonarNeedsProvider;
        private readonly ILabratoryNeedsProvider _labratoryNeedsProvider;
        private readonly BanobatDbContext _dbContext;
        #endregion

        #region Ctor
        public TreatmentHistoryController(IHttpContextAccessor context,
                                          IAppointmentService appointmentService,
                                          IPatientService patientService,
                                          IPersonService personService,
                                          ITreatmentHistoryService treatmentHistoryService,
                                          IDrugsService drugsService,
                                          IServiceSupplyService serviceSupplyService,
                                          INotificationService notificationService,
                                          IPharmacyRepository pharmacyRepository,
                                          IShiftCenterService shiftCenterService,
                                          IMapper mapper,
                                          IHostingEnvironment hostingEnvironment,
                                          ISonarNeedsProvider sonarNeedsProvider,
                                          ILabratoryNeedsProvider labratoryNeedsProvider,
                                          BanobatDbContext dbContext,
                                          IWorkContext workContext) : base(workContext)
        {
            _context = context;
            _appointmentService = appointmentService;
            _patientService = patientService;
            _personService = personService;
            _treatmentHistoryService = treatmentHistoryService;
            _drugsService = drugsService;
            _serviceSupplyService = serviceSupplyService;
            _notificationService = notificationService;
            _pharmacyRepository = pharmacyRepository;
            _shiftCenterService = shiftCenterService;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
            _sonarNeedsProvider = sonarNeedsProvider;
            _labratoryNeedsProvider = labratoryNeedsProvider;
            _dbContext = dbContext;
        }
        #endregion

        [Authorize(Roles = "doctor")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Lang = Lng;

            ViewBag.Doctors = await _serviceSupplyService.GetSelectListAsync(CurrentPolyclinic.Id, CurrentPolyclinic.ServiceSupplyIds);

            ViewBag.Patients = await _patientService.GetSelectListItemsAsync(CurrentPolyclinic.Id, CurrentPolyclinic.ServiceSupplyIds, Lng);

            return View(new TreatmentHistoryListItemViewModel());
        }

        [Authorize(Roles = "doctor")]
        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] DataTablesParameters param)
        {
            try
            {
                var filtersModel = JsonConvert.DeserializeObject<TreatmentHistoryFilterViewModel>(param.FiltersObject);

                filtersModel.ServiceSupplyIds = CurrentPolyclinic.ServiceSupplyIds;

                var results = await _treatmentHistoryService.GetDataTableAsync(CurrentPolyclinic.Id, param, filtersModel, Lng);

                var treatmentHistories = await Task.WhenAll(results.Items.Select(async (x) => new TreatmentHistoryListItemViewModel
                {
                    Id = x.Id,
                    Patient = x.Patient,
                    Pharmacy = x.Pharmacy,
                    Gender = x.Gender,
                    VisitDate = x.VisitDate,
                    Doctor = x.Doctor,
                    Avatar = x.Avatar,
                    IsDoneByPharmacy = x.IsDoneByPharmacy,
                    AvatarHtml = await this.RenderViewToStringAsync("_TreatmentHistoryPatientAvatar", x.Avatar),
                    ActionsHtml = await this.RenderViewToStringAsync("_TreatmentHistoryActions", (x.Id, x.IsDoneByPharmacy))
                }).ToList());

                return new JsonResult(new DataTablesResult<TreatmentHistoryListItemViewModel>
                {
                    Draw = param.Draw,
                    Data = treatmentHistories.ToList(),
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

        [Authorize(Roles = "doctor")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var treatmentHistory = await _dbContext.TreatmentHistories.FirstOrDefaultAsync(x => x.Id == id);
            if (treatmentHistory != null)
            {
                EnsureAllowAccess(treatmentHistory.Patient.ServiceSupplyId ?? 0);

                var isDone = treatmentHistory.PharmacyPrescriptions.Any(p => p.Status == PrescriptionStatus.DONE) || treatmentHistory.Prescriptions.Any(p => p.Status == PrescriptionStatus.DONE);

                if (isDone) throw new AwroNoreException("You can not remove done prescription");

                var pharmacyPresciptions = await _dbContext.PharmacyPrescriptions.Where(x => x.TreatmentHistoryId == id).ToListAsync();
                if (pharmacyPresciptions.Any())
                {
                    _dbContext.PharmacyPrescriptions.RemoveRange(pharmacyPresciptions);
                }

                var prescriptions = await _dbContext.SonarPrescriptions.Where(x => x.TreatmentHistoryId == id).ToListAsync();
                if (prescriptions.Any())
                {
                    _dbContext.SonarPrescriptions.RemoveRange(prescriptions);
                }

                var treatmentItems = await _dbContext.TreatmentsItems.Where(x => x.TreatmentHistoryId == id).ToListAsync();
                if (treatmentItems.Any())
                {
                    _dbContext.TreatmentsItems.RemoveRange(treatmentItems);
                }

                _dbContext.TreatmentHistories.Remove(treatmentHistory);

                await _dbContext.SaveChangesAsync();
            }

            return Json(new { success = true, message = Core.Resources.EntitiesResources.Messages.ItemDeletedSuccessFully });
        }

        [Authorize(Roles = "doctor")]
        [HttpGet]
        public async Task<IActionResult> Create(int? id, int? appointmentId, int? patientId)
        {
            if (appointmentId != null && patientId != null) throw new AwroNoreException("Can not create prescription for appointment & patient");

            var polyclinic = await _shiftCenterService.GetByIdAsync(CurrentPolyclinic.Id);

            if (polyclinic == null) throw new AwroNoreException(Core.Resources.EntitiesResources.Messages.PolyclinicNotFound);

            ViewBag.Doctors = await _serviceSupplyService.GetSelectListAsync(CurrentPolyclinic.Id, CurrentPolyclinic.ServiceSupplyIds);

            var pharmaciesList = new List<SelectListItem>
            {
                new SelectListItem { Text = "...", Value = null}
            };
            var pharmacies = await _pharmacyRepository.GetSelectListItemsAsync(Lng, polyclinic.CityId);
            pharmaciesList.AddRange(pharmacies);
            ViewBag.Pharmacies = pharmaciesList;

            if (id != null)
            {
                var treatmentHistory = await _treatmentHistoryService.GetByIdAsync(id.Value);

                if (treatmentHistory == null || treatmentHistory.Patient.ServiceSupply.ShiftCenterId != CurrentPolyclinic.Id) throw new AwroNoreException("Treatment Not Found");

                var isDone = treatmentHistory.PharmacyPrescriptions.Any(x => x.Status == PrescriptionStatus.DONE) || treatmentHistory.Prescriptions.Any(x => x.Status == PrescriptionStatus.DONE);

                if (isDone) throw new AwroNoreException("This prescription is done, You can not edit it.");

                var pharmacyPrescript = treatmentHistory.PharmacyPrescriptions?.FirstOrDefault();

                var model = new CreateTreatmentHistoryViewModel
                {
                    Id = treatmentHistory.Id,
                    VisitDate = treatmentHistory.VisitDate.ToString("yyyy/MM/dd"),
                    DoctorId = treatmentHistory.Patient.ServiceSupplyId.Value,
                    PersonId = treatmentHistory.Patient.PersonId,
                    PharmacyId = pharmacyPrescript?.PharmacyId,
                    Problems_Ku = treatmentHistory.Problems,
                    Description_Ku = treatmentHistory.Description,
                    PatientVisitAge = pharmacyPrescript?.PatientVisitAge,
                    PatientVisitWeight = pharmacyPrescript?.PatientVisitWeight,
                    PatientVisitHeight = pharmacyPrescript?.PatientVisitHeight,
                    PatientHistory = treatmentHistory.PastMedicalHistory != null ? _mapper.Map<PatientHistoryInfoModel>(treatmentHistory.PastMedicalHistory) : new PatientHistoryInfoModel()
                };

                return PartialView(model);
            }
            else
            {
                var (person, serviceSupplyId) = await GetPersonAndServiceSupplyIdAsync(appointmentId, patientId);

                if (person == null) throw new AwroNoreException("Person Not Found");

                ViewBag.PersonInfo = CollectPersonInfo(person);

                var model = new CreateTreatmentHistoryViewModel
                {
                    AppointmentId = appointmentId,
                    PatientId = patientId,
                    PersonId = person.Id,
                    DoctorId = serviceSupplyId,
                    VisitDate = DateTime.Now.ToShortDateString(),
                    PatientHistory = new PatientHistoryInfoModel()
                };

                return PartialView(model);
            }
        }

        [Authorize(Roles = "doctor")]
        public async Task<IActionResult> ListTreatmentsGridItemRows(int? id = null)
        {
            var list = new List<TreatmentsItemsGridViewModel>();

            if (id != null)
            {
                var treatmentHistory = await _treatmentHistoryService.GetByIdAsync(id.Value);

                if (treatmentHistory == null || treatmentHistory.Patient.ServiceSupply.ShiftCenterId != CurrentPolyclinic.Id) throw new AwroNoreException("Treatment Not Found");

                list = treatmentHistory.TreatmentsItems.Select(x => new TreatmentsItemsGridViewModel
                {
                    Id = x.Id,
                    DrugId = x.DrugId,
                    CustomDrugName = x.CustomDrugName,
                    Dose = x.Dosage,
                    Quantity = x.Quantity,
                    Frequency = x.Frequency,
                    Description = x.Description
                }).ToList();
            }

            return new AwroJGrid2Builder<TreatmentsItemsGridViewModel>(list);
        }

        [Authorize(Roles = "doctor")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateTreatmentHistoryViewModel model, TreatmentsItemsGridViewModel[] treatments, PatientHistoryInfoModel patientHistory)
        {
            if (model.AppointmentId != null && model.PatientId != null) throw new AwroNoreException("Can not create prescription for appointment & patient");

            if (model.PharmacyId != null)
            {
                if (treatments == null || !treatments.Any()) throw new AwroNoreException("Please enter at least one treatment");

                if (treatments.Any(x => (x.DrugId == null || x.DrugId <= 0) && string.IsNullOrEmpty(x.CustomDrugName))) throw new AwroNoreException("Please select drug for all items");
            }

            bool success = false;
            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        if (model.Id != null)
                        {
                            var treatmentHistory = await _dbContext.TreatmentHistories.FindAsync(model.Id);

                            if (treatmentHistory == null || treatmentHistory.Patient.ServiceSupply.ShiftCenterId != CurrentPolyclinic.Id) throw new AwroNoreException("Treatment Not Found");

                            var isDone = treatmentHistory.PharmacyPrescriptions.Any(x => x.Status == PrescriptionStatus.DONE) || treatmentHistory.Prescriptions.Any(x => x.Status == PrescriptionStatus.DONE);

                            if (isDone) throw new AwroNoreException("This prescription is done, You can not update it.");

                            var pharmacyPrscriptions = await _dbContext.PharmacyPrescriptions.Where(x => x.TreatmentHistoryId == treatmentHistory.Id).ToListAsync();

                            if (pharmacyPrscriptions.Any())
                            {
                                var pharmacyPrescript = pharmacyPrscriptions.FirstOrDefault();

                                if (model.PharmacyId != null)
                                {
                                    if (pharmacyPrescript.PharmacyId != model.PharmacyId) throw new AwroNoreException("You can not change pharmacy");
                                }
                            }
                            else
                            {
                                if (model.PharmacyId != null)
                                {
                                    await _dbContext.PharmacyPrescriptions.AddAsync(new PharmacyPrescription
                                    {
                                        PharmacyId = model.PharmacyId.Value,
                                        Status = PrescriptionStatus.PENDING,
                                        PatientVisitAge = model.PatientVisitAge,
                                        PatientVisitWeight = model.PatientVisitWeight,
                                        PatientVisitHeight = model.PatientVisitHeight,
                                        CreatedAt = DateTime.Now,
                                        TreatmentHistoryId = treatmentHistory.Id
                                    });
                                    await _dbContext.SaveChangesAsync();
                                }
                            }

                            var treatmentItems = await _dbContext.TreatmentsItems.Where(x => x.TreatmentHistoryId == treatmentHistory.Id).ToListAsync();

                            if (treatmentItems.Any())
                            {
                                _dbContext.TreatmentsItems.RemoveRange(treatmentItems);

                                await _dbContext.SaveChangesAsync();
                            }

                            if (treatments != null && treatments.Any())
                            {
                                var newDrugs = new List<Drug>();

                                foreach (var item in treatments)
                                {
                                    if (item.DrugId == null && !string.IsNullOrEmpty(item.CustomDrugName))
                                    {
                                        var existAlready = await _dbContext.Drugs.AnyAsync(x => x.GenericName == item.CustomDrugName);

                                        if (!existAlready)
                                        {
                                            newDrugs.Add(new Drug
                                            {
                                                GenericName = item.CustomDrugName,
                                                GenericName_Ar = item.CustomDrugName,
                                                GenericName_Ku = item.CustomDrugName,
                                                TradeName = item.CustomDrugName
                                            });
                                        }
                                    }
                                }

                                if (newDrugs.Any())
                                {
                                    await _dbContext.Drugs.AddRangeAsync(newDrugs);

                                    await _dbContext.SaveChangesAsync();
                                }

                                var treats = treatments.Where(x => !x.IsDeleted && (x.DrugId != null && x.DrugId > 0) || !string.IsNullOrEmpty(x.CustomDrugName)).Select(x => new TreatmentsItems
                                {
                                    TreatmentHistoryId = treatmentHistory.Id,
                                    DrugId = x.DrugId,
                                    CustomDrugName = x.CustomDrugName,
                                    Dosage = x.Dose,
                                    Frequency = x.Frequency,
                                    Quantity = x.Quantity,
                                    Description = x.Description,
                                    CreatedAt = DateTime.Now,
                                }).ToList();

                                _dbContext.TreatmentsItems.AddRange(treats);

                                await _dbContext.SaveChangesAsync();
                            }

                            treatmentHistory.VisitDate = DateTime.Parse(model.VisitDate);
                            treatmentHistory.Problems = model.Problems_Ku ?? "";
                            treatmentHistory.Problems_Ar = model.Problems_Ku ?? "";
                            treatmentHistory.Problems_Ku = model.Problems_Ku ?? "";
                            treatmentHistory.Description = model.Description_Ku ?? "";
                            treatmentHistory.Description_Ku = model.Description_Ku ?? "";
                            treatmentHistory.Description_Ar = model.Description_Ku ?? "";

                            _dbContext.TreatmentHistories.Attach(treatmentHistory);

                            _dbContext.Entry(treatmentHistory).State = EntityState.Modified;

                            // Update past medical history
                            if (patientHistory != null)
                            {
                                var pastMedicalHistory = await _dbContext.PastMedicalHistories.FirstOrDefaultAsync(x => x.TreatmentHistoryId == treatmentHistory.Id);
                                if (pastMedicalHistory != null)
                                {
                                    pastMedicalHistory.UpdatedAt = DateTime.Now;
                                    pastMedicalHistory.DifferentialDiagnosis = patientHistory.DifferentialDiagnosis;
                                    pastMedicalHistory.DrugHistory = patientHistory.DrugHistory;
                                    pastMedicalHistory.ExaminationHistory = patientHistory.ExaminationHistory;
                                    pastMedicalHistory.FamilyHistory = patientHistory.FamilyHistory;
                                    pastMedicalHistory.FinalDiagnosis = patientHistory.FinalDiagnosis;
                                    pastMedicalHistory.PastMedical = patientHistory.PastMedical;
                                    pastMedicalHistory.PresentIllness = patientHistory.PresentIllness;
                                    pastMedicalHistory.SignsAndSymptomsHistory = patientHistory.SignsAndSymptomsHistory;
                                    pastMedicalHistory.SocialHistory = patientHistory.SocialHistory;
                                    pastMedicalHistory.SurgicalHistory = patientHistory.SurgicalHistory;
                                    pastMedicalHistory.SystemicReview = patientHistory.SystemicReview;

                                    _dbContext.PastMedicalHistories.Attach(pastMedicalHistory);

                                    _dbContext.Entry(pastMedicalHistory).State = EntityState.Modified;
                                }
                                else
                                {
                                    pastMedicalHistory = _mapper.Map<PastMedicalHistory>(patientHistory);
                                    pastMedicalHistory.CreatedAt = DateTime.Now;
                                    await _dbContext.PastMedicalHistories.AddAsync(pastMedicalHistory);
                                }
                            }
                            await _dbContext.SaveChangesAsync();
                        }
                        else
                        {
                            Appointment appointment = null;
                            Patient patient = null;
                            if (model.AppointmentId != null)
                            {
                                appointment = await _dbContext.Appointments.FindAsync(model.AppointmentId);

                                if (appointment == null) throw new AwroNoreException("Appointment Not Found");

                                EnsureAllowAccess(appointment.ServiceSupplyId);

                                patient = await _dbContext.Patients.FirstOrDefaultAsync(x => x.ServiceSupplyId == appointment.ServiceSupplyId && x.PersonId == appointment.PersonId);

                                if (patient == null)
                                {
                                    patient = new Patient
                                    {
                                        ServiceSupplyId = appointment.ServiceSupplyId,
                                        PersonId = appointment.PersonId,
                                        CreatedAt = DateTime.Now
                                    };

                                    await _dbContext.Patients.AddAsync(patient);

                                    await _dbContext.SaveChangesAsync();
                                }
                            }
                            else if (model.PatientId != null)
                            {
                                patient = await _dbContext.Patients.FindAsync(model.PatientId.Value) ?? throw new AwroNoreException("Patient Not Found");

                                EnsureAllowAccess(patient.ServiceSupplyId.Value);
                            }

                            var pastMedicalHistory = _mapper.Map<PastMedicalHistory>(patientHistory);
                            pastMedicalHistory.CreatedAt = DateTime.Now;

                            var treatment = new TreatmentHistory
                            {
                                PatientId = patient.Id,
                                AppointmentId = model.AppointmentId,
                                CreatedAt = DateTime.Now,
                                Description = model.Description_Ku ?? "",
                                Description_Ku = model.Description_Ku ?? "",
                                Description_Ar = model.Description_Ku ?? "",
                                Problems = model.Problems_Ku ?? "",
                                Problems_Ku = model.Problems_Ku ?? "",
                                Problems_Ar = model.Problems_Ku ?? "",
                                Treatments = "",
                                Treatments_Ku = "",
                                Treatments_Ar = "",
                                VisitDate = DateTime.Parse(model.VisitDate),
                                PastMedicalHistory = pastMedicalHistory
                            };

                            if (model.PharmacyId != null)
                            {
                                treatment.PharmacyPrescriptions = new List<PharmacyPrescription>
                            {
                                new PharmacyPrescription
                                {
                                    PharmacyId = model.PharmacyId.Value,
                                    Status = PrescriptionStatus.PENDING,
                                    PatientVisitAge = model.PatientVisitAge,
                                    PatientVisitHeight = model.PatientVisitHeight,
                                    PatientVisitWeight = model.PatientVisitWeight,
                                    CreatedAt = DateTime.Now
                                }
                            };
                            }

                            _dbContext.TreatmentHistories.Add(treatment);

                            await _dbContext.SaveChangesAsync();

                            if (treatments != null && treatments.Any())
                            {
                                var newDrugs = new List<Drug>();

                                foreach (var item in treatments)
                                {
                                    if (item.DrugId == null && !string.IsNullOrEmpty(item.CustomDrugName))
                                    {
                                        var existAlready = await _dbContext.Drugs.AnyAsync(x => x.GenericName == item.CustomDrugName);

                                        if (!existAlready)
                                        {
                                            newDrugs.Add(new Drug
                                            {
                                                GenericName = item.CustomDrugName,
                                                GenericName_Ar = item.CustomDrugName,
                                                GenericName_Ku = item.CustomDrugName,
                                                TradeName = item.CustomDrugName,
                                            });
                                        }
                                    }
                                }

                                if (newDrugs.Any())
                                {
                                    await _dbContext.Drugs.AddRangeAsync(newDrugs);

                                    await _dbContext.SaveChangesAsync();
                                }

                                var treats = treatments.Where(x => !x.IsDeleted && (x.DrugId != null && x.DrugId > 0) || !string.IsNullOrEmpty(x.CustomDrugName)).Select(x => new TreatmentsItems
                                {
                                    TreatmentHistoryId = treatment.Id,
                                    DrugId = x.DrugId,
                                    CustomDrugName = x.CustomDrugName,
                                    Dosage = x.Dose,
                                    Frequency = x.Frequency,
                                    Quantity = x.Quantity,
                                    Description = x.Description,
                                    CreatedAt = DateTime.Now,
                                }).ToList();

                                var oldTreats = await _dbContext.TreatmentsItems.Where(x => x.TreatmentHistoryId == treatment.Id).ToListAsync();

                                if (oldTreats.Any()) _dbContext.TreatmentsItems.RemoveRange(oldTreats);

                                _dbContext.TreatmentsItems.AddRange(treats);

                                await _dbContext.SaveChangesAsync();
                            }

                            if (appointment != null)
                            {
                                _dbContext.Entry(appointment).State = EntityState.Modified;
                                appointment.Status = AppointmentStatus.Done;
                                await _dbContext.SaveChangesAsync();
                                await SendDoneAppointmentNotificationAsync(appointment, patient);
                            }
                        }

                        transaction.Commit();

                        success = true;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw e;
                    }
                }
            });

            return Json(new { success, message = success ? Core.Resources.EntitiesResources.Messages.ActionDoneSuccesfully : Core.Resources.EntitiesResources.Messages.ErrorOccuredWhileDoneAction });
        }

        [Authorize(Roles = "doctor,secretary")]
        [HttpGet]
        public async Task<IActionResult> CreateSonarRequest(int? appointmentId, int? patientId)
        {
            if (appointmentId != null && patientId != null) throw new AwroNoreException("Can not create prescription for appointment & patient");

            var (person, serviceSupplyId) = await GetPersonAndServiceSupplyIdAsync(appointmentId, patientId);

            if (person == null) throw new AwroNoreException("Person Not Found");

            ViewBag.PersonInfo = CollectPersonInfo(person);

            ViewBag.Doctors = await _serviceSupplyService.GetSelectListAsync(CurrentPolyclinic.Id, CurrentPolyclinic.ServiceSupplyIds);

            var sonarsList = await _shiftCenterService.GetSelectListAsync(Lng, new List<ShiftCenterType> { ShiftCenterType.Sonography });
            ViewBag.Sonars = sonarsList;

            var sonarNeedsList = _sonarNeedsProvider.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = Lng == Lang.KU ? x.Title_Ku : Lng == Lang.AR ? x.Title_Ar : x.Title
            }).ToList();
            ViewBag.SonarNeeds = sonarNeedsList;

            var model = new CreateSonarTreatmentHistoryViewModel
            {
                AppointmentId = appointmentId,
                PatientId = patientId,
                DoctorId = serviceSupplyId,
                PersonId = person.Id,
                VisitDate = DateTime.Now.ToShortDateString()
            };

            return PartialView(model);
        }

        [Authorize(Roles = "doctor,secretary")]
        [HttpPost]
        public async Task<IActionResult> CreateSonarRequest(CreateSonarTreatmentHistoryViewModel model)
        {
            if (model.AppointmentId != null && model.PatientId != null) throw new AwroNoreException("Can not create prescription for appointment & patient");

            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        Appointment appointment = null;
                        Patient patient = null;
                        if (model.AppointmentId != null)
                        {
                            appointment = await _dbContext.Appointments.FindAsync(model.AppointmentId);

                            if (appointment == null) throw new AwroNoreException("Appointment Not Found");

                            EnsureAllowAccess(appointment.ServiceSupplyId);

                            patient = await _dbContext.Patients.FirstOrDefaultAsync(x => x.ServiceSupplyId == appointment.ServiceSupplyId && x.PersonId == appointment.PersonId);

                            if (patient == null)
                            {
                                patient = new Patient
                                {
                                    ServiceSupplyId = appointment.ServiceSupplyId,
                                    PersonId = appointment.PersonId,
                                    CreatedAt = DateTime.Now
                                };

                                await _dbContext.Patients.AddAsync(patient);

                                await _dbContext.SaveChangesAsync();
                            }
                        }
                        else if (model.PatientId != null)
                        {
                            patient = await _dbContext.Patients.FindAsync(model.PatientId.Value) ?? throw new AwroNoreException("Patient Not Found");

                            EnsureAllowAccess(patient.ServiceSupplyId.Value);
                        }

                        var treatment = new TreatmentHistory
                        {
                            PatientId = patient.Id,
                            AppointmentId = model.AppointmentId,
                            CreatedAt = DateTime.Now,
                            Description = model.Description_Ku ?? "",
                            Description_Ku = model.Description_Ku ?? "",
                            Description_Ar = model.Description_Ku ?? "",
                            Problems = model.Problems_Ku ?? "",
                            Problems_Ku = model.Problems_Ku ?? "",
                            Problems_Ar = model.Problems_Ku ?? "",
                            Treatments = "",
                            Treatments_Ku = "",
                            Treatments_Ar = "",
                            VisitDate = DateTime.Parse(model.VisitDate),
                            Prescriptions = new List<CenterPrescription>
                            {
                                new CenterPrescription
                                {
                                    CenterId = model.SonarCenterId,
                                    Status = PrescriptionStatus.PENDING,
                                    SonarNeedIds = model.SonarNeeds,
                                    PatientVisitAge = model.PatientVisitAge,
                                    PatientVisitHeight = model.PatientVisitHeight,
                                    PatientVisitWeight = model.PatientVisitWeight,
                                    CreatedAt = DateTime.Now
                                }
                            }
                        };

                        _dbContext.TreatmentHistories.Add(treatment);

                        await _dbContext.SaveChangesAsync();

                        if (appointment != null)
                        {
                            _dbContext.Entry(appointment).State = EntityState.Modified;
                            appointment.Status = AppointmentStatus.Done;
                            await _dbContext.SaveChangesAsync();
                            await SendDoneAppointmentNotificationAsync(appointment, patient);
                        }

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

        [Authorize(Roles = "doctor")]
        [HttpGet]
        public async Task<IActionResult> CreateLabRequest(int? appointmentId, int? patientId)
        {
            if (appointmentId != null && patientId != null) throw new AwroNoreException("Can not create prescription for appointment & patient");

            var (person, serviceSupplyId) = await GetPersonAndServiceSupplyIdAsync(appointmentId, patientId);

            if (person == null) throw new AwroNoreException("Person Not Found");

            ViewBag.PersonInfo = CollectPersonInfo(person);

            ViewBag.Doctors = await _serviceSupplyService.GetSelectListAsync(CurrentPolyclinic.Id, CurrentPolyclinic.ServiceSupplyIds);

            ViewBag.Labs = await _shiftCenterService.GetSelectListAsync(Lng, new List<ShiftCenterType> { ShiftCenterType.Laboratory });

            ViewBag.LabratoryNeeds = _labratoryNeedsProvider.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = Lng == Lang.KU ? x.Title_Ku : Lng == Lang.AR ? x.Title_Ar : x.Title
            }).ToList();

            var model = new CreateLabTreatmentHistoryViewModel
            {
                AppointmentId = appointmentId,
                PatientId = patientId,
                DoctorId = serviceSupplyId,
                PersonId = person.Id,
                VisitDate = DateTime.Now.ToShortDateString()
            };

            return PartialView(model);
        }

        [Authorize(Roles = "doctor")]
        [HttpPost]
        public async Task<IActionResult> CreateLabRequest(CreateLabTreatmentHistoryViewModel model)
        {
            if (model.AppointmentId != null && model.PatientId != null) throw new AwroNoreException("Can not create prescription for appointment & patient");
            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        Appointment appointment = null;
                        Patient patient = null;
                        if (model.AppointmentId != null)
                        {
                            appointment = await _dbContext.Appointments.FindAsync(model.AppointmentId);

                            if (appointment == null) throw new AwroNoreException("Appointment Not Found");

                            EnsureAllowAccess(appointment.ServiceSupplyId);

                            patient = await _dbContext.Patients.FirstOrDefaultAsync(x => x.ServiceSupplyId == appointment.ServiceSupplyId && x.PersonId == appointment.PersonId);

                            if (patient == null)
                            {
                                patient = new Patient
                                {
                                    ServiceSupplyId = appointment.ServiceSupplyId,
                                    PersonId = appointment.PersonId,
                                    CreatedAt = DateTime.Now
                                };

                                await _dbContext.Patients.AddAsync(patient);

                                await _dbContext.SaveChangesAsync();
                            }
                        }
                        else if (model.PatientId != null)
                        {
                            patient = await _dbContext.Patients.FindAsync(model.PatientId.Value) ?? throw new AwroNoreException("Patient Not Found");

                            EnsureAllowAccess(patient.ServiceSupplyId.Value);
                        }

                        var treatment = new TreatmentHistory
                        {
                            PatientId = patient.Id,
                            AppointmentId = model.AppointmentId,
                            CreatedAt = DateTime.Now,
                            Description = model.Description_Ku ?? "",
                            Description_Ku = model.Description_Ku ?? "",
                            Description_Ar = model.Description_Ku ?? "",
                            Problems = model.Problems_Ku ?? "",
                            Problems_Ku = model.Problems_Ku ?? "",
                            Problems_Ar = model.Problems_Ku ?? "",
                            Treatments = "",
                            Treatments_Ku = "",
                            Treatments_Ar = "",
                            VisitDate = DateTime.Parse(model.VisitDate),
                            Prescriptions = new List<CenterPrescription>
                            {
                                new CenterPrescription
                                {
                                    CenterId = model.LabCenterId,
                                    Status = PrescriptionStatus.PENDING,
                                    PatientVisitAge = model.PatientVisitAge,
                                    PatientVisitHeight = model.PatientVisitHeight,
                                    PatientVisitWeight = model.PatientVisitWeight,
                                    SonarNeedIds = model.LabratoryNeeds,
                                    CreatedAt = DateTime.Now
                                }
                            }
                        };

                        _dbContext.TreatmentHistories.Add(treatment);

                        await _dbContext.SaveChangesAsync();

                        if (appointment != null)
                        {
                            _dbContext.Entry(appointment).State = EntityState.Modified;
                            appointment.Status = AppointmentStatus.Done;
                            await _dbContext.SaveChangesAsync();
                            await SendDoneAppointmentNotificationAsync(appointment, patient);
                        }

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

        [Authorize(Roles = "doctor")]
        public async Task<IActionResult> DirectPrint(string data, string items)
        {
            var model = JsonConvert.DeserializeObject<PrintTreatmentHistoryViewModel>(data);

            var treatments = JsonConvert.DeserializeObject<List<TreatmentsItemsGridViewModel>>(items);

            if (treatments == null || !treatments.Any()) throw new AwroNoreException("Please enter at least one treatment");

            Person person = null;
            ServiceSupply serviceSupply = null;
            if (model.Id != null)
            {
                var treatmentHistory = await _dbContext.TreatmentHistories.FindAsync(model.Id);
                if (treatmentHistory == null || treatmentHistory.Patient.ServiceSupply.ShiftCenterId != CurrentPolyclinic.Id) throw new AwroNoreException("Treatment Not Found");
                person = treatmentHistory.Patient.Person;
                serviceSupply = treatmentHistory.Patient.ServiceSupply;
            }
            else if (model.AppointmentId != null)
            {
                var appointment = await _appointmentService.GetAppointmentByIdAsync(model.AppointmentId.Value);

                if (appointment == null) throw new AwroNoreException("Appointment Not Found");

                EnsureAllowAccess(appointment.ServiceSupplyId);

                serviceSupply = appointment.ServiceSupply;

                person = appointment.Person;
            }
            else if (model.PatientId != null)
            {
                var patient = await _patientService.GetByIdAsync(model.PatientId.Value);

                if (patient == null || patient.ServiceSupply.ShiftCenterId != CurrentPolyclinic.Id) throw new AwroNoreException("Patient Not Found");

                EnsureAllowAccess(patient.ServiceSupplyId.Value);

                serviceSupply = patient.ServiceSupply;

                person = patient.Person;
            }

            if (person == null) throw new AwroNoreException("Person Not Found");

            if (serviceSupply == null) throw new AwroNoreException("Doctor Not Found");

            var doctor = serviceSupply.Person;

            var polyclinic = serviceSupply.ShiftCenter;

            byte[] centerLogo = null;

            if (!string.IsNullOrEmpty(polyclinic.Logo))
            {
                var logoPath = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", polyclinic.Logo.Substring(1).Replace('/', '\\'));

                centerLogo = StaticHelpers.ImageToByteArray(logoPath);
            }

            var printData = new List<PrintPrescriptModel>
            {
                new PrintPrescriptModel
                {
                    DoctorName = doctor.FullName,
                    DoctorName_Ku = doctor.FullName_Ku,
                    DoctorName_Ar = doctor.FullName_Ar,
                    DoctorMedicalCounsilNumber = serviceSupply?.ServiceSupplyInfo?.MedicalCouncilNumber,
                    HealthCenterName = polyclinic.Name,
                    HealthCenterName_Ku = polyclinic.Name_Ku,
                    HealthCenterName_Ar = polyclinic.Name_Ar,
                    HealthCenterPhone = polyclinic.PhoneNumbers[0].PhoneNumber,
                    HealthCenterAddress = polyclinic.Address,
                    HealthCenterAddress_Ku = polyclinic.Address_Ku,
                    HealthCenterAddress_Ar = polyclinic.Address_Ar,
                    HealthCenterLogo = centerLogo,
                    PatientName =  person.FullName,
                    PatientName_Ku =  person.FullName_Ku,
                    PatientName_Ar =  person.FullName_Ar,
                    PatientAge = person.Age ?? 0,
                    VisitDate = model.VisitDate,
                    PatientGender = person.Gender == Gender.Female ? "Female" : "Male",
                    PatientGender_Ar = person.Gender == Gender.Female ? "أنثى" : "ذكر",
                    PatientGender_Ku = person.Gender == Gender.Female ? "مێ" : "نێر",
                }
            };

            var doctorSpecialities = new List<PrintPrescriptSpecialitiesModel>();
            if (serviceSupply.ServiceSupplyInfo != null && serviceSupply.DoctorExpertises.Any())
            {
                foreach (var item in serviceSupply.DoctorExpertises)
                {
                    doctorSpecialities.Add(new PrintPrescriptSpecialitiesModel
                    {
                        Name = item.Expertise.Name,
                        Name_Ku = item.Expertise.Name_Ku,
                        Name_Ar = item.Expertise.Name_Ar,
                    });
                }
            }

            var doctorGrades = new List<PrintPrescriptSpecialitiesModel>();
            if (serviceSupply.ServiceSupplyInfo != null && serviceSupply.ServiceSupplyInfo.DoctorScientificCategories.Any())
            {
                foreach (var item in serviceSupply.ServiceSupplyInfo.DoctorScientificCategories)
                {
                    doctorGrades.Add(new PrintPrescriptSpecialitiesModel
                    {
                        Name = item.ScientificCategory?.Name,
                        Name_Ku = item.ScientificCategory?.Name_Ku,
                        Name_Ar = item.ScientificCategory?.Name_Ar,
                    });
                }
            }

            var printTreatments = new List<PrintPrescriptTreatmentsModel>();
            var validTreatments = treatments.Where(x => !x.IsDeleted && (x.DrugId != null || !string.IsNullOrEmpty(x.CustomDrugName))).ToList();
            foreach (var item in validTreatments)
            {
                PrintPrescriptTreatmentsModel treatmentItem;

                if (item.DrugId != null)
                {
                    treatmentItem = await _dbContext.Drugs.Where(x => x.Id == item.DrugId).ProjectTo<PrintPrescriptTreatmentsModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
                    if (treatmentItem == null) throw new AwroNoreException("Drug Not Found");
                }
                else
                {
                    treatmentItem = new PrintPrescriptTreatmentsModel
                    {
                        TradeName = item.CustomDrugName
                    };
                }
                treatmentItem.Dose = item.Dose;
                treatmentItem.Frequency = item.Frequency;
                treatmentItem.Quantity = item.Quantity;
                treatmentItem.Description = item.Description;
                printTreatments.Add(treatmentItem);
            }

            var tempKey = Guid.NewGuid().RemoveLines();
            var dataSourceList = new List<ReportDatasourceModel>
            {
                new ReportDatasourceModel
                {
                    Name = "PrescriptionContent",
                    Value = StaticHelpers.CreateDataTable(printData)
                },
                new ReportDatasourceModel
                {
                    Name = "PrescriptionSpecialities",
                    Value = StaticHelpers.CreateDataTable(doctorSpecialities)
                },
                new ReportDatasourceModel
                {
                    Name = "PrescriptionGrades",
                    Value = StaticHelpers.CreateDataTable(doctorGrades)
                },
                new ReportDatasourceModel
                {
                    Name = "PrescriptionTreatments",
                    Value = StaticHelpers.CreateDataTable(printTreatments)
                }
            };

            _context.HttpContext.Session.Set(tempKey, dataSourceList);

            var prescriptPath = serviceSupply.PrescriptionPath;

            return RedirectToAction("Index", "Viewer", new { reportPath = prescriptPath, dataKey = tempKey, area = "" });
        }

        [Authorize(Roles = "doctor,secretary")]
        [HttpGet]
        public async Task<IActionResult> PatientTreatments(int personId, int serviceSupplyId)
        {
            var patient = await _dbContext.Patients.FirstOrDefaultAsync(x => x.ServiceSupplyId == serviceSupplyId && x.PersonId == personId);

            if (patient == null) throw new AwroNoreException("Patient Not Found");

            EnsureAllowAccess(serviceSupplyId);

            var person = patient.Person ?? throw new AwroNoreException("Person Not Found");

            ViewBag.PersonInfo = CollectPersonInfo(person);

            ViewBag.Lang = Lng;

            ViewBag.PatientId = patient.Id;

            var result = await _treatmentHistoryService.GetByPatientAsync(patient.Id, CurrentPolyclinic.Id);

            return PartialView(result);
        }

        public async Task<IActionResult> PatientPastHistory(int treatmentHistoryId)
        {
            var result = new PatientHistoryInfoModel();

            var treatmentHistory = await _treatmentHistoryService.GetByIdAsync(treatmentHistoryId);

            if (treatmentHistory != null)
            {
                result = _mapper.Map<PatientHistoryInfoModel>(treatmentHistory.PastMedicalHistory);
            }

            ViewBag.VisitDate = treatmentHistory.VisitDate;

            return PartialView(result ?? new PatientHistoryInfoModel());
        }

        [Authorize(Roles = "doctor")]
        public async Task<List<SelectListItem>> GetDrugsSelectList()
        {
            var result = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "",
                    Text = "..."
                }
            };
            var drugs = await _drugsService.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = Lng == Lang.KU ? x.GenericName_Ku : Lng == Lang.AR ? x.GenericName_Ar : x.GenericName
            }).ToListAsync();

            result.AddRange(drugs);

            return result;
        }

        [Authorize(Roles = "doctor")]
        [HttpGet]
        public async Task<DrugDTO> GetDrugData(int id)
        {
            var result = new DrugDTO();

            var drug = await _dbContext.Drugs.FindAsync(id);

            if (drug != null)
            {
                result = _mapper.Map<DrugDTO>(drug);
            }

            return result;
        }

        private async Task<(Person, int)> GetPersonAndServiceSupplyIdAsync(int? appointmentId, int? patientId)
        {
            Person person = null;
            int serviceSupplyId = 0;
            if (appointmentId != null)
            {
                var appointment = await _appointmentService.GetAppointmentByIdAsync(appointmentId.Value);

                if (appointment == null) throw new AwroNoreException("Appointment Not Found");

                EnsureAllowAccess(appointment.ServiceSupplyId);

                serviceSupplyId = appointment.ServiceSupplyId;

                person = appointment.Person;
            }
            else if (patientId != null)
            {
                var patient = await _patientService.GetByIdAsync(patientId.Value);

                if (patient == null || patient.ServiceSupply.ShiftCenterId != CurrentPolyclinic.Id) throw new AwroNoreException("Patient Not Found");

                EnsureAllowAccess(patient.ServiceSupplyId.Value);

                serviceSupplyId = patient.ServiceSupplyId.Value;

                person = patient.Person;
            }

            return (person, serviceSupplyId);
        }

        private PersonInfoViewModel CollectPersonInfo(Person person)
        {
            var personInfo = new PersonInfoViewModel
            {
                Id = person.Id,
                UniqueId = person.UniqueId,
                FirstName = Lng == Lang.KU ? person.FirstName_Ku : Lng == Lang.AR ? person.FirstName_Ar : person.FirstName,
                SecondName = Lng == Lang.KU ? person.SecondName_Ku : Lng == Lang.AR ? person.SecondName_Ar : person.SecondName,
                ThirdName = Lng == Lang.KU ? person.ThirdName_Ku : Lng == Lang.AR ? person.ThirdName_Ar : person.ThirdName,
                Address = person.Address,
                Age = person.Age ?? 0,
                Birthdate = person.Birthdate != null ? person.Birthdate.Value.ToString("yyyy-MM-dd") : "",
                Height = person.Height ?? 0,
                IdNumber = person.IdNumber,
                Language = person.Language != null ? person.Language.GetLocalizedDisplayName() : "",
                MarriageStatus = person.MarriageStatus != null ? person.MarriageStatus.GetLocalizedDisplayName() : "",
                MobileNumber = person.Mobile,
                Sex = person.Gender.GetLocalizedDisplayName(),
                Weight = person.Weight ?? 0,
                Avatar = person.RealAvatar
            };
            return personInfo;
        }

        private async Task SendDoneAppointmentNotificationAsync(Appointment appointment, Patient patient)
        {
            if (appointment.Person.FcmInstanceIds != null && appointment.Person.FcmInstanceIds.Any())
            {
                var donePayload = new DoneAppointmentNotificationPayload
                {
                    AppointmentId = appointment.Id,
                    NotificationType = NotificationType.AppointmentDone,
                    UserTurnItem = new Core.DTO.Turn.UserTurnItemDTO
                    {
                        Id = appointment.Id,
                        ServiceSupplyId = appointment.ServiceSupplyId,
                        Date = appointment.Start_DateTime.ToShortDateString(),
                        StartTime = appointment.Start_DateTime.ToShortTimeString(),
                        EndTime = appointment.End_DateTime.ToShortTimeString(),
                        Status = appointment.Status,
                        DoctorName = Lng == Lang.KU ? appointment.ServiceSupply.Person.FullName_Ku : Lng == Lang.AR ? appointment.ServiceSupply.Person.FullName_Ar : appointment.ServiceSupply.Person.FullName,
                        DayOfWeek = Utils.ConvertDayOfWeek(appointment.Start_DateTime.DayOfWeek.ToString()),
                        IsRated = appointment.Rate != null,
                        AverageRating = (appointment.Rate != null) ? appointment.Rate.Rating : 5,
                        TrackingCode = appointment.UniqueTrackingCode,
                        CenterServiceId = appointment.ShiftCenterServiceId,
                        Service = Lng == Lang.KU ? appointment.ShiftCenterService.Service.Name_Ku : Lng == Lang.AR ? appointment.ShiftCenterService.Service.Name_Ar : appointment.ShiftCenterService.Service.Name
                    }
                };
                var enCulture = new CultureInfo(SupportedLangs.EN);
                var arCulture = new CultureInfo(SupportedLangs.AR);
                var kuCulture = new CultureInfo(SupportedLangs.KU);               
                var basePayload = new BaseNotificationPayload
                {
                    Title = Messages.ResourceManager.GetString("AppointmentDoneNotificationTitle", enCulture),
                    TitleKu = Messages.ResourceManager.GetString("AppointmentDoneNotificationTitle", kuCulture),
                    TitleAr = Messages.ResourceManager.GetString("AppointmentDoneNotificationTitle", arCulture),
                    Body = Messages.ResourceManager.GetString("AppointmentDoneNotificationBody", enCulture),
                    BodyKu = Messages.ResourceManager.GetString("AppointmentDoneNotificationBody", kuCulture),
                    BodyAr = Messages.ResourceManager.GetString("AppointmentDoneNotificationBody", arCulture)
                };
                foreach (var item in patient.Person.FcmInstanceIds)
                {
                    await _notificationService.SendDoneAppointmentNotificationAsync(item.InstanceId, basePayload, donePayload);
                }
            }
        }

        private List<string> GetTreatmentExtraNotes()
        {
            var result = new List<string>
            {
                "a.c",
                "p.c",
                "tabs",
                "caps",
                "p.o",
                "I.V",
                "i.m",
                "s.c",
                "q.d",
                "b.i.d",
                "t.i.d",
                "q.i.d",
                "q.h",
                "q.2h",
                "q.3h",
                "q.4h"
            };

            return result;
        }
    }
}