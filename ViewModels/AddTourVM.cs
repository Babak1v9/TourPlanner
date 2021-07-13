using System.Windows.Input;

namespace ViewModels {
    public class AddTourVM : VMBase {

        private string tourName, tourDescription, tourFrom, tourTo;
        private AddTour addTourWindow;
        public MainVM TourVM { get; set; }

        public AddTourVM() {
        }
        public AddTourVM(AddTour view, MainVM tourVM) {
            view.DataContext = this;
            TourVM = tourVM;
        }

        public ICommand AddCommand => new AddTourCommand(this);
        public ICommand ClearCommand => new ClearTourCommand(this);
        public AddTour AddTourWindow {
            get {
                return addTourWindow;
            }
            set {
                if (addTourWindow != value) {
                    addTourWindow = value;
                    NotifyPropertyChanged(nameof(AddTourWindow));
                }
            }
        }

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
    }
}
