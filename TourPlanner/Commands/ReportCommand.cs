using BusinessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using TourPlanner.Reports;
using ViewModels;

namespace TourPlanner.Commands {
    class ReportCommand : ICommand {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public event EventHandler CanExecuteChanged;

        public MainVM MainVM { get; set; }
        public ReportCommand(MainVM parameter) {
            MainVM = parameter;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            var TourLogs = new TourLogHandler();
            var tourLogList = new List<TourLog>();
            var reportGenerator = new PdfReportGenerator();

            //get logs of tour
            var tmp = TourLogs.SearchById(MainVM.CurrentItem.id);
            tourLogList = tmp.ToList();

            //generate reports
            reportGenerator.GenerateReport(MainVM.CurrentItem, tourLogList);
            reportGenerator.GenerateSummaryReport(MainVM.CurrentItem.name, tourLogList);

            //logging
            log.Info($"Report generated successfully.");
        }
    }
}
