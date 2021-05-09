using AN.BLL.Services;
using AN.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace AN.Web.API.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    public class CmsController : ANBaseApiController
    {
        private readonly ICmsService _cmsService;
        public CmsController(ICmsService cmsService)
        {
            _cmsService = cmsService;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> CmsCategories()
        {
            var result = await _cmsService.GetCmsCategoriesAsync(RequestLang);

            return Ok(result);
        }

        [HttpGet("article/details/{id:int}")]
        public async Task<IActionResult> CmsArticleDetails(int id)
        {
            var result = await _cmsService.GetCmsArticleDetailsAsync(id, RequestLang);

            return Ok(result);
        }

        [HttpPost("articles/{categoryId:int}/{pageIndex:int}/{limit:int}", Name = "ArticlesList")]
        [ProducesResponseType(typeof(CmsArticlesListResultDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PharmaciesListPaging(int categoryId, int pageIndex, int limit)
        {
            var result = await _cmsService.GetArticlesPagingListAsync(categoryId, RequestLang, pageIndex);

            return Ok(result);
        }
    }
}