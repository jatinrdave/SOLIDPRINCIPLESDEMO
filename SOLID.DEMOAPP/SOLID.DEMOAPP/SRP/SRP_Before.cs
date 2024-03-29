﻿namespace SOLID.DEMOAPP.SRP_BEFORE
{
    //Single Responsibility Principle Example

    //Here class have three responsibility
    //- Report Generation
    //- Export Report
    //- Print Report
    //Violation of SRP
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
    public class Program
    {
        public static void main(object[] args)
        {
            ReportProcessor reportProcessor = new ReportProcessor();
            reportProcessor.GenerateReport();
            reportProcessor.ExportReport();
            reportProcessor.PrintReport();
        }
    }
}