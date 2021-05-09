using AN.Core;
using AN.Core.MyExceptions;
using AN.Web.AppCode.Extensions;
using AN.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using System.Collections.Generic;

namespace AN.Web.Controllers
{
    public class ViewerController : AwroNoreController
    {
        private readonly IHttpContextAccessor _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IWorkContext _workContext;
        public ViewerController(IHttpContextAccessor context, IHostingEnvironment hostingEnvironment, IWorkContext workContext)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _workContext = workContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PrintToPDF(string reportPath, string dataKey = null)
        {
            if (!string.IsNullOrWhiteSpace(reportPath))
            {
                EnsureAllowAccess(reportPath);

                var report = new StiReport();

                string contentRootPath = _hostingEnvironment.ContentRootPath;
                Stimulsoft.Base.StiLicense.LoadFromFile(contentRootPath + "/Stimulsoft/license.key");

                report.Load(StiNetCoreHelper.MapPath(this, reportPath));
                report.Dictionary.Variables["OrganizationName"].Value = "AwroNore";
                report.Dictionary.Variables["OrganizationLogo"].Value = $"{Request.Scheme}://{Request.Host}{""}";
                if (!string.IsNullOrWhiteSpace(dataKey))
                {
                    var reportDatasource = _context.HttpContext.Session.Get<List<ReportDatasourceModel>>(dataKey);
                    foreach (var item in reportDatasource)
                    {
                        report.RegData(item.Name, item.Name, item.Value);
                    }
                    report.Render();
                }
                return StiNetCoreReportResponse.PrintAsPdf(report);
            }
            else
            {
                //Raise error path is empty;
                return null;
            }
        }

        public IActionResult GetReport(string reportPath, string dataKey = null)
        {         
            if (!string.IsNullOrWhiteSpace(reportPath))
            {
                EnsureAllowAccess(reportPath);

                var report = new StiReport();

                string contentRootPath = _hostingEnvironment.ContentRootPath;
                Stimulsoft.Base.StiLicense.LoadFromFile(contentRootPath + "/Stimulsoft/license.key");

                var fullReportPath = StiNetCoreHelper.MapPath(this, reportPath);

                report.Load(fullReportPath);
                // report.Dictionary.Variables["OrganizationName"].Value = "AwroNore";
                // report.Dictionary.Variables["OrganizationLogo"].Value = $"{Request.Scheme}://{Request.Host}{""}";
                if (!string.IsNullOrWhiteSpace(dataKey))
                {
                    var reportDatasource = _context.HttpContext.Session.Get<List<ReportDatasourceModel>>(dataKey);
                    foreach (var item in reportDatasource)
                    {
                        report.RegData(item.Name, item.Name, item.Value);
                    }
                    report.Render();
                }
                return StiNetCoreViewer.GetReportResult(this, report);
            }
            else
            {
                //Raise error path is empty;
                return null;
            }
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }

        public IActionResult Design(string reportPath, string dataKey = null)
        {
            EnsureAllowAccess(reportPath);

            return RedirectToAction("Index", "Designer", new { reportPath, dataKey, area = "" });
        }

        private void EnsureAllowAccess(string path)
        {
            var pathSegments = path.Split('\\');

            int.TryParse(pathSegments[4], out int shiftCenterId);

            if (shiftCenterId != _workContext.WorkingArea.Id) throw new AccessDeniedException();
        }
    }
}