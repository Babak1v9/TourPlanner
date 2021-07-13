using DataAccessLayer;
using System;
using System.Windows.Input;
using TourPlanner.UIServices;
using ViewModels;

namespace TourPlanner.Commands {
    public class DeleteTourLogCommand : ICommand {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private UIService uiService;

        public event EventHandler CanExecuteChanged;

        public MainVM MainVM { get; set; }

        public DeleteTourLogCommand(MainVM parameter) {
            MainVM = parameter;
            uiService = new UIService();
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {

            uiService.SetBusyState();

            var db = DatabaseController.Instance;

            db.DeleteTourLog(MainVM.SelectedLog);
            MainVM.LogItems.Remove(MainVM.SelectedLog);

            //logging
            log.Info($"TourLog (ID:{MainVM.SelectedLog.logId}) deleted successfully.");
        }
    }
}
