using DataAccessLayer;
using System;
using System.Windows.Input;
using ViewModels;

namespace TourPlanner.Commands {
    class ExportJsonCommand : ICommand {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public event EventHandler CanExecuteChanged;

        public MainVM MainVM { get; set; }
        public ExportJsonCommand(MainVM parameter) {
            MainVM = parameter;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            var fs = new FileSystemController();
            fs.ExportJson(MainVM.CurrentItem);

            //logging
            log.Info($"JSON exported successfully.");
        }
    }
}
