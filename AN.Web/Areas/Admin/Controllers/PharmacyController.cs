using AN.BLL.DataRepository;
using AN.Core.Domain;
using AN.Core.Models;
using AN.Core.ViewModels;
using AN.Web.App_Code;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Threading.Tasks;

namespace AN.Web.Areas.Admin.Controllers
{
    public class PharmacyController : AdminController
    {
        private readonly IPharmacyRepository _pharmacyRepository;
        private readonly ICommonUtils _commonUtils;
        public PharmacyController(IPharmacyRepository pharmacyRepository, ICommonUtils commonUtils)
        {
            _pharmacyRepository = pharmacyRepository;
            _commonUtils = commonUtils;
        }

        public IActionResult Index()
        {
            ViewBag.Lang = Lng;

            return View(new PharmacyListViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody]DataTablesParameters param)
        {
            try
            {
                HttpContext.Session.SetString(nameof(DataTablesParameters), JsonConvert.SerializeObject(param));

                var results = await _pharmacyRepository.GetDataAsync(param, Lng);

                return new JsonResult(new DataTablesResult<PharmacyListViewModel>
                {
                    Draw = param.Draw,
                    Data = results.Items,
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

        [HttpGet]
        public async Task<IActionResult> CreateUpdate(int? id = null)
        {
            ViewBag.Cities = _commonUtils.PopulateCitiesList();

            var model = new PharmacyCreateUpdateViewModel
            {
                Id = id,
            };

            if (id != null)
            {
                var pharmacy = await _pharmacyRepository.GetByIdAsync(id.Value);

                if (pharmacy == null) throw new Exception("Pharmacy Not Found");

                model.Name = pharmacy.Name;
                model.Name_Ku = pharmacy.Name_Ku;
                model.Name_Ar = pharmacy.Name_Ar;
                model.Address = pharmacy.Address;
                model.Address_Ku = pharmacy.Address_Ku;
                model.Address_Ar = pharmacy.Address_Ar;
                model.Description = pharmacy.Description;
                model.Description_Ku = pharmacy.Description_Ku;
                model.Description_Ar = pharmacy.Description_Ar;
                model.GoogleMap_lat = pharmacy.Location != null && pharmacy.Location?.Y > 0 ? pharmacy.Location?.Y.ToString() : "";
                model.GoogleMap_lng = pharmacy.Location != null && pharmacy.Location?.X > 0 ? pharmacy.Location?.X.ToString() : "";
                model.CityId = pharmacy.CityId;
            }

            return PartialView("CreateUpdate", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpdate(PharmacyCreateUpdateViewModel model)
        {
            try
            {
                if (model.Id != null)
                {
                    var pharmacy = await _pharmacyRepository.GetByIdAsync(model.Id.Value);

                    if (pharmacy == null) throw new Exception("Pharmacy Not Found");

                    pharmacy.Name = model.Name;
                    pharmacy.Name_Ku = model.Name_Ku;
                    pharmacy.Name_Ar = model.Name_Ar;
                    pharmacy.Address = model.Address;
                    pharmacy.Address_Ku = model.Address_Ku;
                    pharmacy.Address_Ar = model.Address_Ar;
                    pharmacy.Description = model.Description;
                    pharmacy.Description_Ku = model.Description_Ku;
                    pharmacy.Description_Ar = model.Description_Ar;
                    pharmacy.CityId = model.CityId;
                    pharmacy.UpdatedAt = DateTime.Now;
                    double.TryParse(model.GoogleMap_lng, out double x_longitude);
                    double.TryParse(model.GoogleMap_lat, out double y_latitude);
                    pharmacy.Location = new NetTopologySuite.Geometries.Point(x_longitude, y_latitude)
                    {
                        SRID = 4326
                    };
                    _pharmacyRepository.UpdatePharmacy(pharmacy);

                    return Json(new { success = true });
                }
                else
                {
                    double.TryParse(model.GoogleMap_lng, out double x_longitude);
                    double.TryParse(model.GoogleMap_lat, out double y_latitude);

                    var pharmacy = new Pharmacy
                    {
                        Name = model.Name,
                        Name_Ku = model.Name_Ku,
                        Name_Ar = model.Name_Ar,
                        Address = model.Address,
                        Address_Ku = model.Address_Ku,
                        Address_Ar = model.Address_Ar,
                        Description = model.Description,
                        Description_Ku = model.Description_Ku,
                        Description_Ar = model.Description_Ar,
                        CityId = model.CityId,
                        Location = new NetTopologySuite.Geometries.Point(x_longitude, y_latitude)
                        {
                            SRID = 4326 // Set the SRID (spatial reference system id) to 4326, which is the spatial reference system used by Google maps (WGS84)
                        }
                    };

                    await _pharmacyRepository.InsertPharmacyAsync(pharmacy);

                    return Json(new { success = true });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}