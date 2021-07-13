using DataAccessLayer;
using System;
using System.Windows;
using System.Windows.Input;
using ViewModels;

namespace TourPlanner.Commands {
    class EditTourCommand : ICommand {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public event EventHandler CanExecuteChanged;

        public EditTourVM EditTourVM { get; set; }

        public EditTourCommand(EditTourVM parameter) {
            EditTourVM = parameter;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {

            var x = Application.Current.Windows;

            EditTourVM.TourName = EditTourVM.CurrentItem.name;
            EditTourVM.TourDescription = EditTourVM.CurrentItem.description;
            EditTourVM.TourFrom = EditTourVM.CurrentItem.from;
            EditTourVM.TourTo = EditTourVM.CurrentItem.to;

            var db = DatabaseController.Instance;
            db.ModifyTour(EditTourVM.CurrentItem);

            //logging
            log.Info($"Tour (Name:{EditTourVM.CurrentItem.name}) edited successfully.");

            //Info + close window
            x[1].Close();
        }
    }
}
