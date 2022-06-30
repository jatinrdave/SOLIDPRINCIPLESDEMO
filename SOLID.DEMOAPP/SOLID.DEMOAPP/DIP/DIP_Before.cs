namespace SOLID.DEMOAPP.DIP_BEFORE
{
    //Open/Closed Principle Example

    //New Requirement : Export report in document format along with excel format. 
    public class ReportGenerator
    {
        public void GenerateReport()
        {
            //Generate Report
        }
    }

    //Problem : Class should be closed for modification.
    public class ReportExporter
    {
        bool isExcelType = false;
        public ReportExporter(bool isExcelType) { }
        public void ExportReport()
        {
            if (isExcelType)
            {
                //Export Report to Excel
            }
            else
            {
                //Export Report to Document
            }
        }
    }
    public class ReportPrinter
    {
        public void PrintReport()
        {
            //Print Report
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

    public static void main(object[] args)
    {
        //Export to Excel
        ReportProcessor reportProcessor = new ReportProcessor(new ReportGenerator(), new ReportExporter(true), new ReportPrinter());
        reportProcessor.ExportReport();

        //Export to Document
        ReportProcessor reportProcessor1 = new ReportProcessor(new ReportGenerator(), new ReportExporter(false), new ReportPrinter());
        reportProcessor1.ExportReport();
    }
}