using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWRO.Helper.UIHelper.Grid
{
    public class AwroJGrid2Builder<TSource, TDestination> : IActionResult
    {
        private List<TSource> _data;
        private List<TDestination> _destData;
        private readonly IMapper _mapper;
        public AwroJGrid2Builder(List<TSource> data, IMapper mapper)
        {
            _data = data;
            _destData = new List<TDestination>();
            _mapper = mapper;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            if (_destData != null)
            {
                //Mapper.Map(_data, _destData);
                _mapper.Map(_data, _destData);
                int rowIndex = 1;
                foreach (var item in _destData)
                {
                    if (item.GetType().GetProperty("RowIndex") != null)
                        item.GetType().GetProperty("RowIndex").SetValue(item, rowIndex++);
                    if (item.GetType().GetProperty("IsDeleted") != null)
                        item.GetType().GetProperty("IsDeleted").SetValue(item, false);
                }
                var objectResult = new ObjectResult(_destData)
                {
                    StatusCode = StatusCodes.Status200OK
                };
                await objectResult.ExecuteResultAsync(context);
            }
        }
    }
    public class AwroJGrid2Builder<TDestination> : IActionResult
    {

        private List<TDestination> _destData;
        public AwroJGrid2Builder(List<TDestination> data)
        {
            _destData = data;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            if (_destData != null)
            {               
                int rowIndex = 1;
                foreach (var item in _destData)
                {
                    if (item.GetType().GetProperty("RowIndex") != null)
                        item.GetType().GetProperty("RowIndex").SetValue(item, rowIndex++);
                    if (item.GetType().GetProperty("IsDeleted") != null)
                        item.GetType().GetProperty("IsDeleted").SetValue(item, false);
                }
                var objectResult = new ObjectResult(_destData)
                {
                    StatusCode = StatusCodes.Status200OK
                };
                await objectResult.ExecuteResultAsync(context);
            }
        }
    }
}
