namespace SOLID.DEMOAPP.DEPINJ_AFTER
{
    //Dependency Injection Example

    #region Dependency classes
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

    #endregion

    
    public class ReportProcessor : IReportProcessor
    {

        #region Construction Injection
        private readonly IReportGenerator reportGenerator;
        public ReportProcessor(IReportGenerator reportGenerator)
        {
            this.reportGenerator = reportGenerator ?? throw new ArgumentNullException(nameof(reportGenerator));
            //this.reportExporter = reportExporter ?? throw new ArgumentNullException(nameof(reportExporter));
            //this.reportPrinter = reportPrinter ?? throw new ArgumentNullException(nameof(reportPrinter));
        }

        public void GenerateReport()
        {
            //Generate Report
            reportGenerator.GenerateReport();
        }

        #endregion

        #region Property Injection
        public IReportExporter ReportExporter { get; set; }

        public void ExportReport()
        {
            //Export Report to Excel
            ReportExporter.ExportReport();

        }
        #endregion

        #region Method Injection
        public void PrintReport(IReportPrinter reportPrinter)
        {
            //Print Report
            reportPrinter.PrintReport();
        }
        #endregion

    }

    #region IReportProcessor
    public interface IReportProcessor
    {
        void GenerateReport();
        void ExportReport();
        void PrintReport(IReportPrinter reportPrinter);
    }

    #endregion

    #region Main method
    public class Program
    {
        public static void main(object[] args)
        {
            //Export to Excel
            ReportProcessor reportProcessor = new ReportProcessor(new ReportGenerator());
            reportProcessor.ReportExporter = new ExcelReportExporter();
            reportProcessor.ExportReport();

            //Print Report
            ReportProcessor reportProcessor1 = new ReportProcessor(new ReportGenerator());
            reportProcessor1.PrintReport(new ReportPrinter());
        }
    }
    #endregion

}