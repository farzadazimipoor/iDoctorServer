using AN.BLL.Services.Search;
using AN.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AN.Web.API.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    public class SearchController : ANBaseApiController
    {
        private readonly ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] SearchDTO model)
        {
            var result = await _searchService.DoSearchAsync(RequestLang, model);

            return Ok(result);
        }
    }
}
