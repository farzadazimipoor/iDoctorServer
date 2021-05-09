using AN.BLL.DataRepository.Places;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Resources.EntitiesResources;
using AN.Web.App_Code;
using AN.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.Admin.Controllers
{
    public class PlaceController : AdminController
    {
        private readonly IPlaceService _placeService;
        private readonly ICommonUtils _commonUtils;
        public PlaceController(IPlaceService placeService, ICommonUtils commonUtils)
        {
            _placeService = placeService;
            _commonUtils = commonUtils;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Lang = Lng;

            var places = _placeService.GetAllCities().OrderBy(x => x.ProvinceId).Select(x => new PlaceViewModel
            {
                Id = x.Id,
                ProvinceName = Lng == Lang.KU ? x.Province.Name_Ku : Lng == Lang.AR ? x.Province.Name_Ar : x.Province.Name,
                City = Lng == Lang.KU ? x.Name_Ku : Lng == Lang.AR ? x.Name_Ar : x.Name
            }).OrderBy(x => x.ProvinceName).ToList();

            return View(places);
        }

        [HttpGet]
        public async Task<IActionResult> AddCity(int? id)
        {
            var model = new CreateCityViewModel();

            if (id != null)
            {
                var city = await _placeService.GetCityByIdAsync(id.Value);

                if (city == null) throw new AwroNoreException("City Not Found");

                model = new CreateCityViewModel
                {
                    Id = city.Id,
                    Name = city.Name,
                    Name_Ar = city.Name_Ar,
                    Name_Ku = city.Name_Ku,
                    ProvinceId = city.ProvinceId
                };
            }

            model.listProvinces = _commonUtils.PopulateProvincesList();

            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(CreateCityViewModel model)
        {
            var message = model.Id != null ? Messages.ItemUpdatedSuccessFully : Messages.ItemAddedSuccessFully;

            if (model.Id != null)
            {
                var city = await _placeService.GetCityByIdAsync(model.Id.Value);

                if (city == null) throw new AwroNoreException("City Not Found");

                city.Name = model.Name;
                city.Name_Ku = model.Name_Ku;
                city.Name_Ar = model.Name_Ar;
                city.ProvinceId = model.ProvinceId;
                city.UpdatedAt = DateTime.Now;

                _placeService.UpdateCity(city);
            }
            else
            {
                var city = new City
                {
                    Name = model.Name,
                    Name_Ku = model.Name_Ku,
                    Name_Ar = model.Name_Ar,
                    ProvinceId = model.ProvinceId,
                    CreatedAt = DateTime.Now
                };

                _placeService.InsertCity(city);
            }

            return Json(new { success = true, message });
        }

        public async Task<IActionResult> DeleteCity(int id)
        {
            await _placeService.DeleteCityAsync(id);

            return Json(new { success = true, message = Messages.ItemDeletedSuccessFully });
        }
    }
}