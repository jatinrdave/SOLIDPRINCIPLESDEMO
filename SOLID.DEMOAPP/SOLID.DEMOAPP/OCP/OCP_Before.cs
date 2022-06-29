namespace SOLID.DEMOAPP.OCP_BEFORE
{
    //Open/Closed Principle Example
    public class ReportGenerator
    {
        public void GenerateReport()
        {
            //Generate Report
        }
    }

    public class ReportExporter
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
        private readonly ReportExporter reportExporter;
        private readonly ReportPrinter reportPrinter;

        public ReportProcessor(ReportGenerator reportGenerator, ReportExporter reportExporter, ReportPrinter reportPrinter)
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
        ReportProcessor reportProcessor = new ReportProcessor(new ReportGenerator(), new ReportExporter(), new ReportPrinter());
        reportProcessor.ProcessReport();
    }
}