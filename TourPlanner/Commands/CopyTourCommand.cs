using DataAccessLayer;
using System;
using System.Windows.Input;
using TourPlanner.UIServices;
using ViewModels;

namespace TourPlanner.Commands {

    class CopyTourCommand : ICommand {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private UIService uiService;

        public event EventHandler CanExecuteChanged;

        public MainVM MainVM { get; set; }

        public CopyTourCommand(MainVM parameter) {
            MainVM = parameter;
            uiService = new UIService();
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {

            uiService.SetBusyState();

            var db = DatabaseController.Instance;

            db.CopyTour(MainVM.CurrentItem);

            MainVM.Items.Add(MainVM.CurrentItem);

            //logging
            log.Info($"Tour (Name:{MainVM.CurrentItem.name}) copied successfully.");
        }
    }
}
