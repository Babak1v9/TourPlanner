using System;
using System.Windows.Input;
using ViewModels;

namespace TourPlanner.Commands {
    class ExitAppCommand : ICommand {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public event EventHandler CanExecuteChanged;

        public MainVM MainVM { get; set; }
        public ExitAppCommand(MainVM parameter) {
            MainVM = parameter;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            //logging
            log.Info($"Application shutdown by User.");

            App.Current.Shutdown();
        }
    }
}
