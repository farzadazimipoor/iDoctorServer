using AWRO.Helper.UIHelper.Grid;
using AWRO.Helper.UIHelper.Gird;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using static AWRO.Helper.UIHelper.Gird.GridExtension;

namespace AWRO.Helper.UIHelper
{
    public class AwroFramework<TModel>
    {
        private IHtmlHelper<TModel> _html;
        public AwroFramework(IHtmlHelper<TModel> html)
        {
            _html = html;
        }
        public HtmlString Grid<TValue>(string gridName, string url = null, string pagesCountUrl=null, string areaName = null,bool showEdit = true, bool showDelete = true,bool showPaging=true,bool initiateGrid=true,string parentObjectName = null, AwroGridPagingType pagingType = AwroGridPagingType.ServerSide, Dictionary<string, bool> showIfParameters = null)
        {
            return GridExtension.Grid<TModel, TValue>(_html, gridName, url, pagesCountUrl, areaName,showEdit, showDelete, showPaging, initiateGrid, parentObjectName, pagingType, showIfParameters);
        }
        public HtmlString Grid<TValue, TSearch>(string gridName, string url = null, string pagesCountUrl = null, string areaName = null,bool showEdit = true, bool showDelete = true, bool showPaging = true, bool initiateGrid = true,string parentObjectName = null, AwroGridPagingType pagingType = AwroGridPagingType.ServerSide, Dictionary<string, bool> showIfParameters = null)
        {
            return GridExtension.Grid<TModel, TValue>(_html, gridName, url, pagesCountUrl, areaName,showEdit, showDelete, showPaging, initiateGrid, parentObjectName, pagingType, showIfParameters);
        }
        public HtmlString JGrid2<TValue>(string gridName, string objectName=null,bool showPaging=true,bool showFooter=false,bool isReadOnlyGrid=false, Dictionary<string, bool> showIfParameters = null)
        {
            return AWROComponent.JGrid2<TModel, TValue>(_html,gridName: gridName,objectName: objectName, showPaging:showPaging, showFooter: showFooter, isReadOnlyGrid: isReadOnlyGrid, showIfParameters: showIfParameters);
        }
    }
}