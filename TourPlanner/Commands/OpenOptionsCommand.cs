using System;
using System.Windows.Input;
using ViewModels;

namespace TourPlanner.Commands {
    class OpenOptionsCommand : ICommand {

        public event EventHandler CanExecuteChanged;
        public MainVM MainVM { get; set; }

        public OpenOptionsCommand(MainVM parameter) {
            MainVM = parameter;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {

            var OptionsWindow = new Options();
            OptionsWindow.ShowDialog();
        }
    }

}
