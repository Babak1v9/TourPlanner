using Models;
using System;
using System.Collections;
using System.Windows.Input;
using ViewModels;

namespace TourPlanner.Commands {
    public class SearchLogCommand : ICommand {


        public event EventHandler CanExecuteChanged;

        public MainVM MainVM { get; set; }

        public SearchLogCommand(MainVM parameter) {
            MainVM = parameter;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            IEnumerable foundItems = MainVM.TourLogs.Search(MainVM.SearchName);
            MainVM.LogItems.Clear();
            foreach (TourLog item in foundItems) {
                MainVM.LogItems.Add(item);
            }
        }
    }
}
