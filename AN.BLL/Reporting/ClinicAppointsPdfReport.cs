//using AN.Core.Models;
//using AN.Core.Resources.Global;
//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace AN.BLL.Reporting
//{
//    public class ClinicAppointsPdfReports
//    {
//        private readonly string _fileName;
//        private readonly string _filePath;
//        public string clinicName;
//        public string polyclinicName;
//        public string doctorName;
//        public string fromToDate;

//        private List<ClinicReportModel> appointsList;

//        public ClinicAppointsPdfReport(ClinicAppointsReportModel reportModel)
//        {
//            clinicName = reportModel.ClinicName;
//            polyclinicName = reportModel.PolyclinicName;
//            doctorName = reportModel.DoctorName;
//            fromToDate = reportModel.FromToDate;
//            appointsList = reportModel.Rows;

//            if (File.Exists(_filePath)){
//                File.Delete(_filePath);
//            }

//            _fileName = reportModel.ClinicId.ToString() + ".pdf";
//            _filePath = AppPath.ApplicationPath + "\\Content\\Output\\Reports\\Clinics\\" + _fileName;
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
//                footer.DefaultFooter(clinicName + $" - {Global.Polyclinic} " + polyclinicName + $" {Global.Date} "+ DateTime.Now.ToString("MM/dd/yyyy"));               
//            })
//            .PagesHeader(header =>
//            {
//                header.DefaultHeader(defaultHeader =>
//                {
//                    defaultHeader.ImagePath(AppPath.ApplicationPath + "\\Content\\images\\PdfHeader.png");
//                    defaultHeader.Message(doctorName + " - " + fromToDate);
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
//                dataSource.StronglyTypedList<ClinicReportModel>(appointsList);
//            })
//            .MainTableSummarySettings(summarySettings =>
//            {
//                summarySettings.OverallSummarySettings("All");
//                summarySettings.PreviousPageSummarySettings("From Previews Page");
//                summarySettings.PageSummarySettings("All Pages");
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
//               {
//                   column.PropertyName<ClinicReportModel>(x => x.DayOfWeek);
//                   column.CellsHorizontalAlignment(HorizontalAlignment.Center);
//                   column.IsVisible(true);
//                   column.Order(1);
//                   column.Width(2);
//                   column.HeaderCell(Global.Day);
//               });

//                columns.AddColumn(column =>
//                {
//                    column.PropertyName<ClinicReportModel>(x => x.StartTime);
//                    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
//                    column.IsVisible(true);
//                    column.Order(1);
//                    column.Width(2);
//                    column.HeaderCell(Global.Turn);
//                });

//                columns.AddColumn(column =>
//                {
//                    column.PropertyName<ClinicReportModel>(x => x.PatientName);
//                    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
//                    column.IsVisible(true);
//                    column.Order(2);
//                    column.Width(3);
//                    column.HeaderCell(Global.Patient);
//                });               

//                columns.AddColumn(column =>
//                {
//                    column.PropertyName<ClinicReportModel>(x => x.Mobile);
//                    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
//                    column.IsVisible(true);
//                    column.Order(4);
//                    column.Width(2);
//                    column.HeaderCell(Global.Mobile);                    
//                });

//            })
//            .MainTableEvents(events =>
//            {
//                events.DataSourceIsEmpty(message: "No Turn Found");
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
