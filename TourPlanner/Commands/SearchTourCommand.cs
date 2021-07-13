using Models;
using System;
using System.Collections;
using System.Windows.Input;
using ViewModels;

namespace TourPlanner.Commands {
    public class SearchTourCommand : ICommand {


        public event EventHandler CanExecuteChanged;

        public MainVM MainVM { get; set; }

        public SearchTourCommand(MainVM parameter) {
            MainVM = parameter;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            IEnumerable foundItems = MainVM.Tours.Search(MainVM.SearchName);
            MainVM.Items.Clear();
            foreach (Tour item in foundItems) {
                MainVM.Items.Add(item);
            }
        }
    }
}
