using DataAccessLayer;
using Models;
using System;
using System.Windows;
using System.Windows.Input;
using TourPlanner.UIServices;
using ViewModels;

namespace TourPlanner.Commands {
    class AddTourLogCommand : ICommand {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public event EventHandler CanExecuteChanged;
        private UIService uiService;
        public TourLogVM TourLogVM { get; set; }
        public MainVM MainVM { get; set; }

        public AddTourLogCommand(TourLogVM parameter, MainVM parameter2) {
            TourLogVM = parameter;
            MainVM = parameter2;
            uiService = new UIService();
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {

            uiService.SetBusyState();

            var x = Application.Current.Windows;

            Guid myuuid = Guid.NewGuid();
            var newTourLog = new TourLog();

            var currentDate = DateTime.Now.ToString("d/M/yyyy");

            newTourLog.logId = myuuid.ToString();
            newTourLog.date = currentDate;
            newTourLog.report = TourLogVM.Report;
            newTourLog.duration = TourLogVM.Duration;
            newTourLog.distance = TourLogVM.Distance;
            newTourLog.rating = TourLogVM.Rating.Substring(38, 1);
            newTourLog.avgSpeed = TourLogVM.Avg_speed;
            newTourLog.tourId = TourLogVM.CurrentTour.id;

            //add tourLog to db
            var db = DatabaseController.Instance;
            db.CreateTourLog(newTourLog);

            //add to view ?

            //logging
            log.Info($"TourLog (ID:{newTourLog.logId}) added successfully.");

            //Info + close window
            MessageBox.Show("TourLog added.");
            x[1].Close();
        }
    }
}
