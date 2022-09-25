namespace SOLID.DEMOAPP.SRP_AFTER1
{
    //Single Responsibility Principle Example

    //Here class have one responsibility
    //- Report Generation
    public class ReportGenerator
    {
        public void GenerateReport()
        {
            //Generate Report
        }
    }
    //Here class have one responsibility
    //- Export Report
    public class ReportExporter 
    {
        public void ExportReport()
        {
            //Export Report to Excel
        }
    }
    //Here class have one responsibility
    //- Print Report
    public class ReportPrinter
    {
        public void PrintReport()
        {
            //Print Report
        }
    }


    //Call Individually whenever required. 
    public class Program
    {
        public static void main(object[] args)
        {
            ReportGenerator reportGenerator = new ReportGenerator();
            reportGenerator.GenerateReport();

            ReportPrinter reportPrinter = new ReportPrinter();
            reportPrinter.PrintReport();

            //Using Excel Exporter
            ReportExporter docReportExporter = new ReportExporter();
            docReportExporter.ExportReport();
        }
    }
    //Delegate functionality Example.
    //public class ReportProcessor 
    //{
    //    private readonly ReportGenerator reportGenerator;
    //    private readonly ReportExporter reportExporter;
    //    private readonly ReportPrinter reportPrinter;

    //    public ReportProcessor(ReportGenerator reportGenerator, ReportExporter reportExporter, ReportPrinter reportPrinter)
    //    {
    //        this.reportGenerator = reportGenerator ?? throw new ArgumentNullException(nameof(reportGenerator));
    //        this.reportExporter = reportExporter ?? throw new ArgumentNullException(nameof(reportExporter));
    //        this.reportPrinter = reportPrinter ?? throw new ArgumentNullException(nameof(reportPrinter));
    //    }
    //    public void GenerateReport()
    //    {
    //        //Generate Report
    //        reportGenerator.GenerateReport();
    //        //Save in database.
    //        SaveToDB();
    //    }
    //    public void ExportReport()
    //    {
    //        //Export Report to Excel
    //        reportExporter.ExportReport();
            
    //    }
    //    public void PrintReport()
    //    {
    //        //Print Report
    //        reportPrinter.PrintReport();
    //    }
    //    private void SaveToDB()
    //    {
    //        //Save to database
    //    }
    //}
    //public static void main(object[] args)
    //{
    //    ReportProcessor reportProcessor = new ReportProcessor(new ReportGenerator(), new ReportExporter(), new ReportPrinter());

    //    reportProcessor.GenerateReport();

    //    reportProcessor.PrintReport();

    //    //Using Excel Exporter
    //    reportProcessor.ExportReport();


    //}
}