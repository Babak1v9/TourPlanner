using BusinessLayer;
using DataAccessLayer;
using Models;
using System;
using System.Windows;
using System.Windows.Input;
using ViewModels;
using TourPlanner.UIServices;

namespace TourPlanner.Commands {
    class AddTourCommand : ICommand {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public event EventHandler CanExecuteChanged;
        private UIService uiService;
        public AddTourVM AddTourVM { get; set; }

        public AddTourCommand(AddTourVM parameter) {
            AddTourVM = parameter;
            uiService = new UIService();
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public async void Execute(object parameter) {

            uiService.SetBusyState();

            var windows = Application.Current.Windows;
            Guid myuuid = Guid.NewGuid();

            var newTour = new Tour();
            newTour.name = AddTourVM.TourName;
            newTour.description = AddTourVM.TourDescription;
            newTour.from = AddTourVM.TourFrom;
            newTour.to = AddTourVM.TourTo;
            newTour.id = myuuid.ToString();

            //get tour map
            var mapQuestAPI = new MapQuestAPI();
            var createdTour = await mapQuestAPI.GetTourMap(newTour);

            //add tour to db
            var toursBL = new TourHandler();
            toursBL.CreateTour(createdTour);

            //logging
            log.Info($"Tour {newTour.name} added successfully.");

            //add to view ?
            AddTourVM.TourVM.GetTours();

            //Info + close window
            MessageBox.Show("Tour added.");
            windows[1].Close();
        }
    }
}
