using System;
using System.Windows.Input;
using ViewModels;

namespace TourPlanner.Commands {
    class ClearTourLogCommand : ICommand {
        public event EventHandler CanExecuteChanged;

        public EditTourLogVM EditTourLogVM { get; set; }


        public ClearTourLogCommand(EditTourLogVM parameter) {
            EditTourLogVM = parameter;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            //if (!object.ReferenceEquals(TourLogVM, null)) {

            EditTourLogVM.CurrentItem.date = String.Empty;
            EditTourLogVM.CurrentItem.duration = String.Empty;
            EditTourLogVM.CurrentItem.distance = String.Empty;
            EditTourLogVM.CurrentItem.rating = String.Empty;
            EditTourLogVM.CurrentItem.avgSpeed = String.Empty;
            EditTourLogVM.Date = String.Empty;
            EditTourLogVM.Duration = String.Empty;
            EditTourLogVM.Distance = String.Empty;
            EditTourLogVM.Rating = String.Empty;
            EditTourLogVM.Avg_speed = String.Empty;

        }
    }
}
