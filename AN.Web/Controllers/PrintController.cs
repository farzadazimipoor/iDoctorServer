using AN.BLL.DataRepository;
using AN.BLL.DataRepository.TreatmentHistories;
using AN.Core;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Models;
using AN.Core.MyExceptions;
using AN.Web.AppCode.Extensions;
using AN.Web.Helper;
using AN.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Controllers
{
    public class PrintController : CpanelBaseController
    {
        private readonly IHttpContextAccessor _context;
        private readonly ITreatmentHistoryService _treatmentHistoryService;
        private readonly IPharmacyPrescriptionRepository _pharmacyPrescriptionRepository;
        private readonly IWorkContext _workContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        public PrintController(IWorkContext workContext,
                               IHttpContextAccessor httpContextAccessor,
                               ITreatmentHistoryService treatmentHistoryService,
                               IPharmacyPrescriptionRepository pharmacyPrescriptionRepository,
                               IHostingEnvironment hostingEnvironment) : base(workContext)
        {
            _context = httpContextAccessor;
            _treatmentHistoryService = treatmentHistoryService;
            _pharmacyPrescriptionRepository = pharmacyPrescriptionRepository;
            _workContext = workContext;
            _hostingEnvironment = hostingEnvironment;
        }

        private string BuildPrescriptionPrintModel(TreatmentHistory treatmentHistory)
        {
            var polyclinic = treatmentHistory.Patient.ServiceSupply.ShiftCenter;

            var serviceSupply = treatmentHistory.Patient.ServiceSupply;

            var doctor = serviceSupply.Person;

            var person = treatmentHistory.Patient.Person;

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
                    VisitDate = treatmentHistory.VisitDate.ToString("yyy-MM-dd"),
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
                        Name = item.Expertise?.Name,
                        Name_Ku = item.Expertise?.Name_Ku,
                        Name_Ar = item.Expertise?.Name_Ar,
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

            var printTreatments = treatmentHistory.TreatmentsItems.Select(x => new PrintPrescriptTreatmentsModel
            {
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
            }).ToList();

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

            return tempKey;
        }

        [HttpGet]
        [Authorize(Roles = "doctor")]
        public async Task<IActionResult> PrintPreScription(int id)
        {
            var treatmentHistory = await _treatmentHistoryService.GetByIdAsync(id);

            if (treatmentHistory == null) throw new Exception("Treatment Not Found");

            if(_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(treatmentHistory.Patient.ServiceSupplyId ?? 0)) throw new AccessDeniedException();
            }

            var tempKey = BuildPrescriptionPrintModel(treatmentHistory);

            var prescriptPath = treatmentHistory.Patient.ServiceSupply.PrescriptionPath;

            return RedirectToAction("Index", "Viewer", new { reportPath = prescriptPath, dataKey = tempKey, area = "" });
        }

        [HttpGet]
        [Authorize(Roles = "pharmacymanager")]
        public async Task<IActionResult> PrintPharmacyPreScription(int pharmacyId, int treatmentHistoryId)
        {
            var pharmacyPrescript = await _pharmacyPrescriptionRepository.GetPharmacyPrescriptionAsync(pharmacyId, treatmentHistoryId);

            if (pharmacyPrescript == null) throw new AwroNoreException("Pharmacy prescription not found");

            var treatmentHistory = pharmacyPrescript.TreatmentHistory ?? throw new Exception("Treatment Not Found"); ;

            if (_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(treatmentHistory.Patient.ServiceSupplyId.Value)) throw new AccessDeniedException();
            }

            var tempKey = BuildPrescriptionPrintModel(treatmentHistory);

            var prescriptPath = treatmentHistory.Patient.ServiceSupply.PrescriptionPath;

            return RedirectToAction("Index", "Viewer", new { reportPath = prescriptPath, dataKey = tempKey, area = "" });
        }

        public IActionResult QrGenerator(string data)
        {
            var qrCodeBitmap = QrGeneratorHelper.QrBarcodeGenerator(data);

            var bitmapBytes = QrGeneratorHelper.BitmapToByteArray(qrCodeBitmap); //Convert bitmap into a byte array

            return File(bitmapBytes, "image/jpeg"); //Return as            
        }
    }
}