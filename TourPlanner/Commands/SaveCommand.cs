using Models;
using System;
using System.Windows;
using System.Windows.Input;
using ViewModels;

namespace TourPlanner.Commands {
    class SaveCommand : ICommand {
        public event EventHandler CanExecuteChanged;

        public OptionsVM OptionsVM { get; set; }
        public SaveCommand(OptionsVM parameter) {
            OptionsVM = parameter;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            var x = Application.Current.Windows;

            var opt = RouteOptions.Instance;
            opt.Routetype = OptionsVM.SelectedRouteType;
            opt.Unit = OptionsVM.SelectedUnit;
            opt.Language = OptionsVM.SelectedLanguage;

            x[1].Close();
        }
    }
}
