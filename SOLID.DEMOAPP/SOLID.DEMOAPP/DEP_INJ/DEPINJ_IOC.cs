using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace SOLID.DEMOAPP.DEPINJ_IOC
{
    //Dependency Injection IOC Example

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
        public static void main(object[] args, IServiceCollection services)
        {

            var container = RegisterServicesForNetFrameworkApp();

            //RegisterServicesForNetCoreApp(services);

            //Export to Excel
            //Get report Geneerator instance.
            ReportGenerator reportGenerator = container.Resolve<IReportGenerator>();
            ReportProcessor reportProcessor = new ReportProcessor(reportGenerator);
            //reportProcessor.ReportExporter = new ExcelReportExporter();
            reportProcessor.ExportReport();

            //Print Report
            ReportPrinter reportPrinter = container.Resolve<IReportPrinter>();
            ReportProcessor reportProcessor1 = new ReportProcessor(reportGenerator);
            reportProcessor1.PrintReport(reportPrinter);
        }

        private static IContainer RegisterServicesForNetFrameworkApp()
        {
            bool isExcelReport = false;
            var builder = new ContainerBuilder();


            //Scope of instance 
            builder.RegisterType<IReportPrinter>().As<ReportPrinter>().InstancePerLifetimeScope();
            builder.RegisterType<IReportGenerator>().As<ReportGenerator>().SingleInstance();
            if (isExcelReport)
            {

                builder.RegisterType<IReportExporter>().As<ExcelReportExporter>().instanceperrequest();
            }
            else
            {
                builder.RegisterType<IReportExporter>().As<DocReportExporter>().instanceperrequest();
                // Register all dependencies (and dependencies of those dependencies, etc)

                return builder.Build();
            }
        }

        private static void RegisterServicesForNetCoreApp(IServiceCollection services)
        {
            bool isExcelReport = false; 
            services.AddScoped<IReportPrinter, ReportPrinter>();
            services.AddTransient<IReportGenerator, ReportGenerator>();
            if (isExcelReport)
            {
                services.AddSingleton<IReportExporter, ExcelReportExporter>();
            }
            else
            {
                services.AddScoped<IReportExporter, DocReportExporter>();
            }


        }
    }
    #endregion
}
    
    
