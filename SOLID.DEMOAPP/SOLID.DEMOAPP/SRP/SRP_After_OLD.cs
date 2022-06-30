namespace SOLID.DEMOAPP.SRP_AFTER
{
    //Single Responsibility Principle Example
    public class ReportGenerator
    {
        public void GenerateReport()
        {
            //Generate Report
        }
    }

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

    public class ReportPrinter
    {
        public void PrintReport()
        {
            //Export Report to Excel
        }
    }

    
    //Call Individually and not to club. 
    public static void main(object[] args)
    {
        ReportGenerator reportGenerator = new ReportGenerator();
        reportGenerator.GenerateReport();
       
        ReportPrinter reportPrinter = new ReportPrinter();
        reportPrinter.PrintReport();

        //Using Excel Exporter
        IReportExporter docReportExporter = new DocReportExporter();
        docReportExporter.ExportReport();


        //Using Doc Exporter
        IReportExporter excelReportExporter = new ExcelReportExporter();
        excelReportExporter.ExportReport();
        

    }

    //Club functionality.
    public class ReportProcessor
    {
        private readonly ReportGenerator reportGenerator;
        private readonly IReportExporter reportExporter;
        private readonly ReportPrinter reportPrinter;

        public ReportProcessor(ReportGenerator reportGenerator, IReportExporter reportExporter, ReportPrinter reportPrinter)
        {
            this.reportGenerator = reportGenerator ?? throw new ArgumentNullException(nameof(reportGenerator));
            this.reportExporter = reportExporter ?? throw new ArgumentNullException(nameof(reportExporter));
            this.reportPrinter = reportPrinter ?? throw new ArgumentNullException(nameof(reportPrinter));
        }

        public void ProcessReport()
        {
            reportGenerator.GenerateReport();
            reportExporter.ExportReport();
            reportPrinter.PrintReport();
        }
    }
}