using System;
using System.Windows.Input;
using ViewModels;

namespace TourPlanner.Commands {
    class ClearTourCommand : ICommand {
        public event EventHandler CanExecuteChanged;

        public AddTourVM AddTourVM { get; set; }

        public EditTourVM EditTourVM { get; set; }

        public ClearTourCommand(EditTourVM parameter) {
            EditTourVM = parameter;
        }

        public ClearTourCommand(AddTourVM parameter) {
            AddTourVM = parameter;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            if (object.ReferenceEquals(AddTourVM, null)) {
                EditTourVM.TourName = String.Empty;
                EditTourVM.TourDescription = String.Empty;
                EditTourVM.TourFrom = String.Empty;
                EditTourVM.TourTo = String.Empty;
            } else {
                AddTourVM.TourName = String.Empty;
                AddTourVM.TourDescription = String.Empty;
                AddTourVM.TourFrom = String.Empty;
                AddTourVM.TourTo = String.Empty;
            }

        }
    }
}
