using System;
using System.Windows.Input;
using ViewModels;

namespace TourPlanner.Commands {
    class OpenEditTourLogCommand : ICommand {
        public event EventHandler CanExecuteChanged;

        public MainVM MainVM { get; set; }

        public OpenEditTourLogCommand(MainVM parameter) {
            MainVM = parameter;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {

            var editTourLogWindow = new EditTourLog(MainVM.SelectedLog);
            editTourLogWindow.ShowDialog();
        }
    }
}
