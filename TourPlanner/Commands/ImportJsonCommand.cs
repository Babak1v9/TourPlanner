using System;
using System.Windows.Input;
using System.Collections.Generic;
using Models;
using DataAccessLayer;
using ViewModels;

namespace TourPlanner.Commands {
    class ImportJsonCommand : ICommand {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public event EventHandler CanExecuteChanged;

        public MainVM MainVM { get; set; }
        public ImportJsonCommand(MainVM parameter) {
            MainVM = parameter;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {

            var db = DatabaseController.Instance; //should not access access layer, go over business layer
            List<Tour> importedTours = new List<Tour>();
            var fs = new FileSystemController();
            importedTours = fs.ImportJson();

            //only add if id doesnt exist yet
            //List<Tour> newTours = new List<Tour>();

            foreach (Tour tour in importedTours) {
                if (!MainVM.Items.Contains(tour)) {
                    MainVM.Items.Add(tour);
                    db.CreateTour(tour);
                }
            }

            //logging
            log.Info($"JSON imported successfully.");
        }
    }
}
