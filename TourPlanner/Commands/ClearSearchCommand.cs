using System;
using System.Windows.Input;
using ViewModels;

namespace TourPlanner.Commands {

    public class ClearSearchCommand : ICommand {

        public event EventHandler CanExecuteChanged;

        public MainVM mainVM { get; set; }

        public ClearSearchCommand(MainVM parameter) {
            mainVM = parameter;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            mainVM.Items.Clear();
            mainVM.SearchName = "";
            mainVM.GetTours();
        }
    }
}
