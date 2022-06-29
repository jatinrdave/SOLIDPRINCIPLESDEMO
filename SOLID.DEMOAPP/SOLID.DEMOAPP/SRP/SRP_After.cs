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

    public static void main(object[] args)
    {
        //Using Excel Exporter
        ReportProcessor reportProcessor1 = new ReportProcessor(new ReportGenerator(), new ExcelReportExporter(), new ReportPrinter());
        reportProcessor1.ProcessReport();

        //Using Doc Exporter
        ReportProcessor reportProcessor2 = new ReportProcessor(new ReportGenerator(), new DocReportExporter(), new ReportPrinter());
        reportProcessor2.ProcessReport();
    }
}