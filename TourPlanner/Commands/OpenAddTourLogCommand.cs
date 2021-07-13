using System;
using System.Windows.Input;
using ViewModels;

namespace TourPlanner.Commands {
    class OpenAddTourLogCommand : ICommand {

        public event EventHandler CanExecuteChanged;
        public TourLogVM TourLogVM { get; set; }
        public MainVM MainVM { get; set; }

        public OpenAddTourLogCommand(TourLogVM parameter) {
            TourLogVM = parameter;
        }

        public OpenAddTourLogCommand(MainVM parameter) {
            MainVM = parameter;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {

            var addTourLogWindow = new AddTourLog(MainVM.CurrentItem);
            addTourLogWindow.ShowDialog();
        }
    }

}
