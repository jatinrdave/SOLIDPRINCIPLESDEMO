namespace SOLID.DEMOAPP.DIP_AFTER
{
    //Dependency Inversion Principle Example
    public interface IReportGenerator
    {
        void GenerateReport();
    }
    public class ReportGenerator : IReportGenerator
    {
        public void GenerateReport()
        {
            //Generate Report
        }
    }
    #region Report Exporter
    public interface IReportExporter
    {
        void ExportReport();
    }
    public class ExcelReportExporter : IReportExporter
    {
        public void ExportReport()
        {
            //Export Report to Excel
        }
    }
    public class DocReportExporter : IReportExporter
    {
        public void ExportReport()
        {
            //Export Report to Excel
        }
    }
    #endregion

    #region Report Printer
    public interface IReportPrinter
    {
        void PrintReport();
    }

    public class ReportPrinter : IReportPrinter
    {
        public void PrintReport()
        {
            //Export Report to Excel
        }
    }
    #endregion
    public static void main(object[] args)
    {
        //Export to Excel
        ReportProcessor reportProcessor = new ReportProcessor(new ReportGenerator(), new ExcelReportExporter(), new ReportPrinter());
        reportProcessor.ExportReport();

        //Export to Document
        ReportProcessor reportProcessor1 = new ReportProcessor(new ReportGenerator(), new DocReportExporter(), new ReportPrinter());
        reportProcessor1.ExportReport();
    }
    
    public class ReportProcessor : IReportProcessor
    {
        private readonly IReportGenerator reportGenerator;
        private readonly IReportExporter reportExporter;
        private readonly IReportPrinter reportPrinter;

        public ReportProcessor(IReportGenerator reportGenerator, IReportExporter reportExporter, IReportPrinter reportPrinter)
        {
            this.reportGenerator = reportGenerator ?? throw new ArgumentNullException(nameof(reportGenerator));
            this.reportExporter = reportExporter ?? throw new ArgumentNullException(nameof(reportExporter));
            this.reportPrinter = reportPrinter ?? throw new ArgumentNullException(nameof(reportPrinter));
        }

        public void GenerateReport()
        {
            //Generate Report
            reportGenerator.GenerateReport();
            //Save in database.
            SaveToDB();
        }
        public void ExportReport()
        {
            //Export Report to Excel
            reportExporter.ExportReport();

        }
        public void PrintReport()
        {
            //Print Report
            reportPrinter.PrintReport();
        }
        private void SaveToDB()
        {
            //Save to database
        }
    }


    public interface IReportProcessor
    {
        void GenerateReport();
        void ExportReport();
        void PrintReport();
    }
    
    
}