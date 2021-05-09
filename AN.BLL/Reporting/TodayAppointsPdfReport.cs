//using AN.Core;
//using AN.Core.Models;
//using AN.Core.Resources.Global;
//using PdfRpt.Core.Contracts;
//using PdfRpt.FluentInterface;
//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace AN.BLL.Reporting
//{
//    public class TodayAppointsPdfReport
//    {
//        private readonly string _fileName;
//        private readonly string _filePath;

//        private List<PolyclinicTodayAppointsReportModel> appointsList;
        
//        public TodayAppointsPdfReport(List<PolyclinicTodayAppointsReportModel> _appointsList, int polyclinicId)
//        {
//            appointsList = _appointsList;

//            if (File.Exists(_filePath)){
//                File.Delete(_filePath);
//            }

//            _fileName = polyclinicId.ToString() + ".pdf";
//            _filePath = AppPath.ApplicationPath + "\\Content\\Output\\Reports\\" + _fileName;
//        }

//        public IPdfReportData CreatePdfReport()
//        {
//            return new PdfReport().DocumentPreferences(doc =>
//            {
//                doc.RunDirection(PdfRunDirection.RightToLeft);
//                doc.Orientation(PageOrientation.Portrait);
//                doc.PageSize(PdfPageSize.A4);
//                doc.DocumentMetadata(new DocumentMetadata { Author = "FarzadAzimipoor", Application = "PdfRpt", Keywords = "Test", Subject = "Test Rpt", Title = "Test" });
//            }).DefaultFonts(fonts =>
//            {
//                fonts.Path(Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\tahoma.ttf",
//                                  Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\verdana.ttf");
//            }).PagesFooter(footer =>
//            {
//                footer.DefaultFooter(DateTime.Now.ToString("MM/dd/yyyy"));
//            })
//            .PagesHeader(header =>
//            {
//                header.DefaultHeader(defaultHeader =>
//                {
//                    defaultHeader.ImagePath(AppPath.ApplicationPath + "\\Content\\images\\PdfHeader.png");
//                    defaultHeader.Message("Polyclinic Turns");
//                });
//            })
//            .MainTableTemplate(template =>
//            {
//                template.BasicTemplate(BasicTemplate.ClassicTemplate);
//            }).MainTablePreferences(table =>
//            {
//                table.ColumnsWidthsType(TableColumnWidthType.Relative);
//                table.NumberOfDataRowsPerPage(30);
//            })
//            .MainTableDataSource(dataSource =>
//            {               
//                dataSource.StronglyTypedList<PolyclinicTodayAppointsReportModel>(appointsList);
//            })
//            .MainTableSummarySettings(summarySettings =>
//            {
//                summarySettings.OverallSummarySettings("All");
//                summarySettings.PreviousPageSummarySettings("From Previews Pages");
//                summarySettings.PageSummarySettings("All Page");
//            })
//            .MainTableColumns(columns =>
//            {
//                columns.AddColumn(column =>
//                {
//                    column.PropertyName("rowNo");
//                    column.IsRowNumber(true);
//                    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
//                    column.IsVisible(true);
//                    column.Order(0);
//                    column.Width(1);
//                    column.HeaderCell("#");
//                });

//                columns.AddColumn(column =>
//                {
//                    column.PropertyName<PolyclinicTodayAppointsReportModel>(x => x.DoctorName);
//                    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
//                    column.IsVisible(true);
//                    column.Order(1);
//                    column.Width(2);
//                    column.HeaderCell(Global.Doctor);
//                });

//                columns.AddColumn(column =>
//                {
//                    column.PropertyName<PolyclinicTodayAppointsReportModel>(x => x.AppointStartTime);
//                    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
//                    column.IsVisible(true);
//                    column.Order(2);
//                    column.Width(3);
//                    column.HeaderCell(Global.Turn);
//                });

//                columns.AddColumn(column =>
//                {
//                    column.PropertyName<PolyclinicTodayAppointsReportModel>(x => x.PatientName);
//                    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
//                    column.IsVisible(true);
//                    column.Order(3);
//                    column.Width(3);
//                    column.HeaderCell(Global.Patient);
//                });

//                columns.AddColumn(column =>
//                {
//                    column.PropertyName<PolyclinicTodayAppointsReportModel>(x => x.PatientMobile);
//                    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
//                    column.IsVisible(true);
//                    column.Order(4);
//                    column.Width(2);
//                    column.HeaderCell(Global.Mobile);                    
//                });

//            })
//            .MainTableEvents(events =>
//            {
//                events.DataSourceIsEmpty(message: "No Item Found");
//            })
//            .Export(export =>
//            {
//                export.ToExcel();
//                export.ToCsv();
//                export.ToXml();
//            })
//            .Generate(data => data.AsPdfFile(_filePath));
//        }
       
//    }

//}
