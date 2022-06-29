namespace SOLID.DEMOAPP.SRP_BEFORE
{
    //Single Responsibility Principle Example
    public class ReportProcessor
    {

        public void GenerateReport()
        {
            //Generate Report
        }

        public void ExportReport()
        {
            //Export Report to Excel
        }

        public void PrintReport()
        {
            //Print Report to printer
        }


    }

    public static void main(object[] args)
    {
        ReportProcessor reportProcessor = new ReportProcessor();
        reportProcessor.GenerateReport();
        reportProcessor.ExportReport();
        reportProcessor.PrintReport();
    }
}