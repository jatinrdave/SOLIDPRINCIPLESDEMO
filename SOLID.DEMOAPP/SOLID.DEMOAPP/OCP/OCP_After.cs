namespace SOLID.DEMOAPP.OCP_AFTER
{
    //Open/Closed Principle Example
    public class ReportGenerator
    {
        public void GenerateReport()
        {
            //Generate Report
        }
    }
    //Solution: Inheritance is only one way to implement the Open Closed Principle.
    //Because inheritance is only allows extension of functionality of an existing class.
    //Implementation : Extend class functionality by interface.
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

    public static void main(object[] args)
    {
        ReportGenerator reportGenerator = new ReportGenerator();
        reportGenerator.GenerateReport();

        ReportPrinter reportPrinter = new ReportPrinter();
        reportPrinter.PrintReport();

        //Using Excel Exporter
        IReportExporter excelReportExporter = new ExcelReportExporter();
        excelReportExporter.ExportReport();

        //Using Document Exporter
        IReportExporter docReportExporter = new DocReportExporter();
        docReportExporter.ExportReport();
    }


    //public static void main(object[] args)
    //{
    //    //Export to Excel
    //    ReportProcessor reportProcessor = new ReportProcessor(new ReportGenerator(), new ExcelReportExporter(), new ReportPrinter());
    //    reportProcessor.ExportReport();

    //    //Export to Document
    //    ReportProcessor reportProcessor1 = new ReportProcessor(new ReportGenerator(), new DocReportExporter(), new ReportPrinter());
    //    reportProcessor1.ExportReport();
    //}
    
    //public class ReportProcessor : IReportProcessor
    //{
    //    private readonly ReportGenerator reportGenerator;
    //    private readonly IReportExporter reportExporter;
    //    private readonly ReportPrinter reportPrinter;

    //    public ReportProcessor(ReportGenerator reportGenerator, IReportExporter reportExporter, ReportPrinter reportPrinter)
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


    //public interface IReportProcessor
    //{
    //    void GenerateReport();
    //    void ExportReport();
    //    void PrintReport();
    //}
    
    
}