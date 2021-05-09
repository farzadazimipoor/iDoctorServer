using AN.BLL.DataRepository;
using AN.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace AN.Web.API.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    public class PharmaciesController : ANBaseApiController
    {
        private readonly IPharmacyRepository _pharmacyRepository;
        public PharmaciesController(IPharmacyRepository pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }

        [HttpPost("{pageIndex:int}/{limit:int}", Name = "PharmaciesList")]
        [ProducesResponseType(typeof(PharmaciesResultDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PharmaciesListPaging(int pageIndex, int limit)
        {
            var (totalCount, _, offers) = await _pharmacyRepository.GetPharmaciesListAsync(RequestLang, pageIndex);

            var result = new PharmaciesResultDTO
            {
                TotalCount = totalCount,
                Pharmacies = offers
            };

            return Ok(result);
        }

    }
}