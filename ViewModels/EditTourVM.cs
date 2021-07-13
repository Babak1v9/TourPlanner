using TourPlanner.Commands;
using System.Windows.Input;
using TourPlanner.Models;

namespace ViewModels {
    public class EditTourVM : ViewModelbase {

        private string tourName, tourDescription, tourFrom, tourTo;
        private Tour currentItem;
        public TourVM TourVM { get; set; }

        public EditTourVM() { }

        public EditTourVM(Tour selectedTour) {
            currentItem = selectedTour;
        }
        public EditTourVM(EditTour view, TourVM tourVM) {
            view.DataContext = this;
            TourVM = tourVM;
        }

        public ICommand EditCommand => new EditTourCommand(this);
        public ICommand ClearCommand => new ClearTourCommand(this);

        public string TourName {
            get {
                return tourName;
            }
            set {
                if (tourName != value) {
                    tourName = value;
                    NotifyPropertyChanged(nameof(TourName));
                }
            }
        }

        public string TourDescription {
            get {
                return tourDescription;
            }
            set {
                if (tourDescription != value) {
                    tourDescription = value;
                    NotifyPropertyChanged(nameof(TourDescription));
                }
            }
        }

        public string TourFrom {
            get {
                return tourFrom;
            }
            set {
                if (tourFrom != value) {
                    tourFrom = value;
                    NotifyPropertyChanged(nameof(TourFrom));
                }
            }
        }
        public string TourTo {
            get {
                return tourTo;
            }
            set {
                if (tourTo != value) {
                    tourTo = value;
                    NotifyPropertyChanged(nameof(TourTo));
                }
            }
        }
        public Tour CurrentItem {
            get {
                return currentItem;
            }
            set {
                if (currentItem != value) {
                    currentItem = value;
                    NotifyPropertyChanged(nameof(CurrentItem));
                }
            }
        }
    }
}
