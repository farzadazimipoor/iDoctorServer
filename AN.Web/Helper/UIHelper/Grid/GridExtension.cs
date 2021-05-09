using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using AWRO.Helper.UIHelper.Attributes;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWRO.Helper.UIHelper.Gird
{
    public static class GridExtension
    {
        public static HtmlString Grid<TModel, TValue>(this IHtmlHelper<TModel> html, string gridName, string url, string pagesCountUrl, string areaName, bool showEdit, bool ShowDelete, bool showPaging, bool initiateGrid, string parentObjectName, AwroGridPagingType pagingType, Dictionary<string, bool> showIfParameters)
        {
            var properties = typeof(TValue).GetProperties();
            properties = setOrders(properties);
            url = updateUrl(html, url, areaName);
            var countUrl = string.IsNullOrEmpty(pagesCountUrl) ? getPagesCountUrl(html, areaName) : pagesCountUrl;
            var deleteUrl = getDeleteUrl(html, areaName);
            string result = renderGrid(gridName, showEdit, ShowDelete, showPaging, initiateGrid, parentObjectName, null, properties, url, countUrl, deleteUrl);
            return new HtmlString(result);
        }

        private static PropertyInfo[] setOrders(PropertyInfo[] properties)
        {
            if (properties != null)
            {
                var haveOrdersList = properties.Where(c => c.GetCustomAttribute<AwroGridOrder>() != null)
                     .OrderBy(c => c.GetCustomAttribute<AwroGridOrder>().Value).ToList();
                var doNotHaveOrdersList = properties.Where(c => c.GetCustomAttribute<AwroGridOrder>() == null);
                var tempResult = new List<PropertyInfo>();
                tempResult = tempResult.Concat(haveOrdersList).ToList();
                tempResult = tempResult.Concat(doNotHaveOrdersList).ToList();
                properties = tempResult.ToArray();
            }

            return properties;
        }

        private static string updateUrl(IHtmlHelper html, string url, string areaName)
        {
            if (string.IsNullOrEmpty(url))
            {
                var controllerName = html.ViewContext.RouteData.Values["controller"];
                url = "/" + controllerName + "/List";
            }
            url = (!string.IsNullOrEmpty(areaName) && !url.Contains(areaName) ? "/" + areaName : "") + url;
            return url;
        }
        private static string getPagesCountUrl(IHtmlHelper html, string areaName)
        {
            var controllerName = html.ViewContext.RouteData.Values["controller"];
            var url = (!string.IsNullOrEmpty(areaName) ? "/" + areaName : "") + "/" + controllerName + "/GetPagesCount?pageCount=10";
            return url;
        }
        private static string getDeleteUrl(IHtmlHelper html, string areaName)
        {
            var controllerName = html.ViewContext.RouteData.Values["controller"];
            var url = (!string.IsNullOrEmpty(areaName) ? "/" + areaName : "") + "/" + controllerName + "/Delete";
            return url;
        }

        public static HtmlString Grid<TModel, TValue, TSearch>(this IHtmlHelper<TModel> html, string gridName, string url, string pagesCountUrl, string areaName, bool showEdit, bool ShowDelete, bool showPaging, bool initiateGrid, string gridObjectName, AwroGridPagingType pagingType, Dictionary<string, bool> showIfParameters)
        {
            var properties = typeof(TValue).GetProperties().ToArray();
            url = updateUrl(html, url, areaName);
            var countUrl = string.IsNullOrEmpty(pagesCountUrl) ? getPagesCountUrl(html, areaName) : pagesCountUrl;
            var deleteUrl = getDeleteUrl(html, areaName);
            string result = renderGrid(gridName, showEdit, ShowDelete, showPaging, initiateGrid, gridObjectName, typeof(TSearch), properties, url, countUrl, deleteUrl);
            return new HtmlString(result);
        }

        private static string renderGrid(string gridName, bool showEdit, bool ShowDelete, bool showPaging, bool initiateGrid, string parentObjectName, Type searchType, PropertyInfo[] properties, string url, string getPagesCountUrl, string deleteUrl)
        {
            var result = "<div  id='" + gridName + "' class='table-responsive'>";

            result += "<table class='table table-bordered table-hover'>";
            result = renderHead(result, showEdit || ShowDelete, searchType, properties);
            result += "<tbody>";
            result += "</tbody>";
            result += "</table>";
            if (showPaging)
                result += renderPaging(gridName);
            result += "</div>";
            result = renderScript(gridName, showEdit, ShowDelete, initiateGrid, parentObjectName, properties, url, getPagesCountUrl, deleteUrl, result);
            return result;
        }

        private static string renderScript(string gridName, bool showEdit, bool ShowDelete, bool initiateGrid, string parentObjectName, PropertyInfo[] properties, string url, string getPagesCountUrl, string deleteUrl, string result)
        {
            result += "<script>";
            result += "\n" + "var elementsNumberPerPage = 10;";
            result += "\n" + "var " + gridName + ";";
            result += "\n" + "$(function(){";
            result += "\n" + gridName + "=new Awro.Components.Grid('" + gridName + "', '" + url + "', null);";

            result += renderHeadDataSource(gridName, showEdit, ShowDelete, parentObjectName, properties);

            if (initiateGrid)
                result += "\n" + gridName + ".GetPagesCount('" + getPagesCountUrl + "');";
            result += "\n" + gridName + ".DeleteUrl='" + deleteUrl + "';";
            if (initiateGrid)
                result += "\n" + gridName + ".Initial();";
            result += "\n" + gridName + ".BindPaging();";
          
            result += "\n" + "});";
            result += "\n" + "</script>";
            return result;
        }

        private static string renderHead(string result, bool showOperation, Type searchType, PropertyInfo[] properties)
        {
            result += "<thead><tr>";
            if (properties != null)
            {
                result += "<th>" + Resources.AwroGrid.RowIndex + "</th>";
                foreach (var item in properties)
                {
                    if (item.Name != "Id" && item.Name != "RowIndex" && item.Name != "EditCommand" && item.GetCustomAttribute<DoNotShow>() == null)
                    {
                        var width = item.GetCustomAttribute<AwroGridWidth>() != null ? item.GetCustomAttribute<AwroGridWidth>().Value : "";
                        var display = item.GetCustomAttribute<DisplayAttribute>() != null ? item.GetCustomAttribute<DisplayAttribute>().GetName() : item.Name;
                        var printClass = (item.GetCustomAttribute<AwroGridNoPrint>() != null) ? "class='d-print-none text-center'" : "class='text-center'";
                        if (item.PropertyType == typeof(bool) && item.GetCustomAttribute<UIHintAttribute>() == null && item.GetCustomAttribute<AwroGridBooleanToString>() == null)
                            result += "<th class='d-print-none text-center'>" + "<input type='checkbox' data-type='select-all' data-for='" + item.Name.Substring(0, 1).ToLower() + item.Name.Substring(1, item.Name.Length - 1) + "'/>" + "</th>";
                        else if (!string.IsNullOrEmpty(width))                        
                            
                            result += "<th "+ printClass+" style='width:" + width + "'>" + display + "</th>";                                              
                        else
                            result += "<th "+ printClass+">" + display + "</th>";
                    }
                }
                if (showOperation)
                    result += "<th class='d-print-none'></th>";
            }
            result += "</tr><thead>";
            return result;
        }
        private static string renderHeadDataSource(string gridName, bool showEdit, bool showDelete, string parentObjectName, PropertyInfo[] properties)
        {
            var result = "";
            if (properties != null)
            {
                result += "\n" + gridName + ".HeaderSource.push({Name:'ShowEdit',Value:'" + showEdit + "',ParentObjectName:'" + parentObjectName + "'})";
                result += "\n" + gridName + ".HeaderSource.push({Name:'ShowDelete',Value:'" + showDelete + "'})";
                foreach (var item in properties)
                {
                    var width = item.GetCustomAttribute<AwroGridWidth>() != null ? item.GetCustomAttribute<AwroGridWidth>().Value : "";
                    // var propertyName = item.GetCustomAttribute<AwroGridKey>() != null ? "Id" : item.Name;
                    var doNotShow = item.GetCustomAttribute<DoNotShow>() != null;
                    var isKey = item.GetCustomAttribute<AwroGridKey>() != null;
                    var showPrint = (item.GetCustomAttribute<AwroGridNoPrint>() == null)?"True":"False";
                    var propertyType = item.GetCustomAttribute<AwroGridBooleanToString>() == null ?
                        (item.GetCustomAttribute<UIHintAttribute>() != null ? "Custom" : item.PropertyType.Name) : "String";
                    result += "\n" + gridName + ".HeaderSource.push({Name:'" + item.Name.Substring(0, 1).ToLower() + (item.Name.Length >= 2 ? item.Name.Substring(1, item.Name.Length - 1) : "") + "',Width:'" + width +
                        "',Type:'" + propertyType + "',DoNotShow:'" + doNotShow + "',IsKey:'" + isKey + "',ShowPrint:'"+ showPrint + "'})";


                }
            }
            return result;

        }
        public static string renderPaging(string gridName)
        {
            var result = "<nav>";
            result += "<ul class='pagination border'>";
            result += "<li class='page-item'><a class='page-link border-right goToFirst' title='" + Resources.AwroGrid.First + "' href='#'><i class='fa fa fa-angle-double-left'></i></a></li>";
            result += "<li class='page-item'><a class='page-link border-left border-right goToPrevious' title='" + Resources.AwroGrid.Previous + "' href='#'><i class='fa fa-angle-left'></i></a></li>";
            result += "<li class='page-item'><input class='pageNumber border-left border-right page-link' type='text'/></li>";
            result += "<li class='page-item'><a class='page-link border-left border-right goToNext' title='" + Resources.AwroGrid.Next + "' href='#'><i class='fa fa-angle-right'></i></a></li>";
            result += "<li class='page-item'><a class='page-link border-left border-right goToLast' title='" + Resources.AwroGrid.Last + "' href='#'><i class='fa fa fa-angle-double-right'></i></a></li>";
            result += "<li class='page-item'><a class='page-link border-left' href='#' onclick='Awro.Print.OutterArea(\"#" + gridName + " table\")'><i class='fa fa-print'></i></a></li>";
            result += "</ul>";
            result += "</nav>";
            return result;
        }

        public enum AwroGridPagingType
        {
            ClientSide,
            ServerSide
        }
    }
}