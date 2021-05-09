//using AN.Core;
//using AN.Core.Models.Reporting;
//using AN.Core.Resources.Global;
//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace AN.BLL.Reporting
//{
//    public class ClinicDoctorsWorkingHoursPdfReport
//    {
//        private readonly string _fileName;
//        private readonly string _filePath;

//        public string clinicName;

//        private List<WorkingHoursModel> workingList;

//        public ClinicDoctorsWorkingHoursPdfReport(ClinicWorkingHoursReportModel reportModel)
//        {
//            clinicName = reportModel.ClinicName;
//            workingList = reportModel.Rows;

//            if (File.Exists(_filePath))
//            {
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
//                footer.DefaultFooter(clinicName + $" {Global.Date} " + DateTime.Now.ToString("MM/dd/yyyy"));
//            })
//            .PagesHeader(header =>
//            {
//                header.DefaultHeader(defaultHeader =>
//                {
//                    defaultHeader.ImagePath(AppPath.ApplicationPath + "\\Content\\images\\PdfHeader.png");
//                    defaultHeader.Message("");
//                });
//            })
//            .MainTableTemplate(template =>
//            {
//                template.BasicTemplate(BasicTemplate.ClassicTemplate);
//            }).MainTablePreferences(table =>
//            {
//                table.ColumnsWidthsType(TableColumnWidthType.Relative);
//                table.NumberOfDataRowsPerPage(Defaults.RowsPerPage);
//            })
//            .MainTableDataSource(dataSource =>
//            {
//                dataSource.StronglyTypedList<WorkingHoursModel>(workingList);
//            })
//            .MainTableColumns(columns =>
//            {               
//                columns.AddColumn(column =>
//                {
//                    column.PropertyName<WorkingHoursModel>(x => x.DoctorName);
//                    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
//                    column.IsVisible(true);
//                    column.Order(1);
//                    column.Width(4);
//                    column.HeaderCell(Global.Doctor);
//                });

//                columns.AddColumn(column =>
//                {
//                    column.PropertyName<WorkingHoursModel>(x => x.Date);
//                    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
//                    column.IsVisible(true);
//                    column.Order(1);
//                    column.Width(2);
//                    column.HeaderCell(Global.Date);
//                });

//                columns.AddColumn(column =>
//                {
//                    column.PropertyName<WorkingHoursModel>(x => x.DayOfWeek);
//                    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
//                    column.IsVisible(true);
//                    column.Order(2);
//                    column.Width(1);
//                    column.HeaderCell(Global.Day);
//                });

//                columns.AddColumn(column =>
//                {
//                    column.PropertyName<WorkingHoursModel>(x => x.FromTime);
//                    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
//                    column.IsVisible(true);
//                    column.Order(2);
//                    column.Width(1);
//                    column.HeaderCell(Global.From);
//                });

//                columns.AddColumn(column =>
//                {
//                    column.PropertyName<WorkingHoursModel>(x => x.ToTime);
//                    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
//                    column.IsVisible(true);
//                    column.Order(4);
//                    column.Width(1);
//                    column.HeaderCell(Global.To);
//                });

//                columns.AddColumn(column =>
//                {
//                    column.PropertyName<WorkingHoursModel>(x => x.Shift);
//                    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
//                    column.IsVisible(true);
//                    column.Order(4);
//                    column.Width(1);
//                    column.HeaderCell(Global.Shift);
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
