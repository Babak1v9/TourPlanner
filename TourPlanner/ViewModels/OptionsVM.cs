using TourPlanner.Commands;
using System.Windows.Input;
using TourPlanner;

namespace ViewModels {
    public class OptionsVM : VMBase {

        private string unit, routeType, language, selectedUnit, selectedRouteType, selectedLanguage;

        public ICommand SaveCommand => new SaveCommand(this);

        public OptionsVM() {
        }
        public string Unit {
            get { return unit; }
            set {
                if ((unit != value) && (value != null)) {
                    unit = value;
                    NotifyPropertyChanged(nameof(Unit));
                }
            }
        }
        public string Language {
            get { return language; }
            set {
                if ((language != value) && (value != null)) {
                    language = value;
                    NotifyPropertyChanged(nameof(Language));
                }
            }
        }
        public string RouteType {
            get { return routeType; }
            set {
                if ((routeType != value) && (value != null)) {
                    routeType = value;
                    NotifyPropertyChanged(nameof(RouteType));
                }
            }
        }

        public string SelectedUnit {
            get { return selectedUnit; }
            set {
                if ((selectedUnit != value) && (value != null)) {
                    selectedUnit = value;
                    NotifyPropertyChanged(nameof(SelectedUnit));
                }
            }
        }
        public string SelectedLanguage {
            get { return selectedLanguage; }
            set {
                if ((selectedLanguage != value) && (value != null)) {
                    selectedLanguage = value;
                    NotifyPropertyChanged(nameof(SelectedLanguage));
                }
            }
        }
        public string SelectedRouteType {
            get { return selectedRouteType; }
            set {
                if ((selectedRouteType != value) && (value != null)) {
                    selectedRouteType = value;
                    NotifyPropertyChanged(nameof(SelectedRouteType));
                }
            }
        }
    }
}
