using DataAccessLayer;
using System;
using System.Windows;
using System.Windows.Input;
using ViewModels;

namespace TourPlanner.Commands {
    class EditTourLogCommand : ICommand {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public event EventHandler CanExecuteChanged;

        public EditTourLogVM EditTourLogVM { get; set; }

        public EditTourLogCommand(EditTourLogVM parameter) {
            EditTourLogVM = parameter;
        }


        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {

            var x = Application.Current.Windows;

            EditTourLogVM.Date = EditTourLogVM.CurrentItem.date;
            EditTourLogVM.Duration = EditTourLogVM.CurrentItem.duration;
            EditTourLogVM.Distance = EditTourLogVM.CurrentItem.distance;
            EditTourLogVM.Rating = EditTourLogVM.CurrentItem.rating;
            EditTourLogVM.Avg_speed = EditTourLogVM.CurrentItem.avgSpeed;

            var db = DatabaseController.Instance;
            db.ModifyTourLog(EditTourLogVM.CurrentItem);

            //logging
            log.Info($"TourLog (ID:{EditTourLogVM.LogId}) edited successfully.");

            //Info + close window
            x[1].Close();
        }
    }
}
