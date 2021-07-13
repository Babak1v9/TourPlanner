using System;
using System.Windows.Input;
using ViewModels;

namespace TourPlanner.Commands {
    class OpenAddTourCommand : ICommand {

        public event EventHandler CanExecuteChanged;
        public MainVM MainVM { get; set; }

        public OpenAddTourCommand(MainVM parameter) {
            MainVM = parameter;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {

            var addTourWindow = new AddTour();
            var addTourVM = new AddTourVM(addTourWindow, MainVM);

            if (addTourWindow.ShowDialog() != true) // false or null
                return;
        }
    }

}
