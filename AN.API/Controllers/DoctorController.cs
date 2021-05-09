using AN.BLL.DataRepository.ServiceSupplies;
using AN.Core.DTO.Doctors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AN.WebAPI.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    public class DoctorController : AwroNoreBaseController
    {
        private readonly IServiceSupplyService _supplyService;
        public DoctorController(IServiceSupplyService supplyService)
        {
            _supplyService = supplyService;
        }

        [HttpPost("list", Name = "DoctorsList")]
        [ProducesResponseType(typeof(DoctorsResultDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DoctorsListPaging([FromBody]DoctorFilterDTO filterModel, [FromQuery]int? page = null)
        {
            var all = _supplyService.GetAll().ToList();

            return Ok();
        }
    }
}