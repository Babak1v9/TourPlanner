using System;
using System.Windows.Input;
using ViewModels;

namespace TourPlanner.Commands {
    class OpenEditTourCommand : ICommand {
        public event EventHandler CanExecuteChanged;

        public MainVM MainVM { get; set; }

        public OpenEditTourCommand(MainVM parameter) {
            MainVM = parameter;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {

            var editTourWindow = new EditTour(MainVM.CurrentItem);
            editTourWindow.ShowDialog();
        }
    }
}
