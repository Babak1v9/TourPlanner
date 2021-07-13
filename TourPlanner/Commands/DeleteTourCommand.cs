using DataAccessLayer;
using System;
using System.Windows.Input;
using TourPlanner.UIServices;
using ViewModels;

namespace TourPlanner.Commands {
    public class DeleteTourCommand : ICommand {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private UIService uiService;
        public event EventHandler CanExecuteChanged;

        public MainVM MainVM { get; set; }

        public DeleteTourCommand(MainVM parameter) {
            MainVM = parameter;
            uiService = new UIService();
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {

            uiService.SetBusyState();

            var db = DatabaseController.Instance;

            db.DeleteTour(MainVM.CurrentItem);
            MainVM.Items.Remove(MainVM.CurrentItem);

            //logging
            log.Info($"Tour {MainVM.CurrentItem.name} deleted successfully.");
        }
    }
}
