using TourPlanner.BusinessLayer;
using TourPlanner.Commands;
using TourPlanner.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModels {
    public class TourLogVM : ViewModelbase {

        private TourLog currentItem;
        private TourLogs tourLogs;
        private string logId, date, report, duration, distance, rating, avg_speed, tourId;
        private TourVM tourVM;
        private Tour currentTour;

        public ICommand AddTourLogCommand => new AddTourLogCommand(this, tourVM);
        public ICommand OpenAddTourLogCommand => new OpenAddTourLogCommand(this);
        //public ICommand ClearTourLogCommand => new ClearTourLogCommand(this);
        //public ICommand EditTourLogCommand => new EditTourLogCommand(this, currentItem);
        //public ICommand DeleteTourLogCommand => new DeleteTourLogCommand(this);

        public ObservableCollection<TourLog> Items { get; set; }
        public ObservableCollection<TourLog> LogItems { get; set; }

        public TourLogVM(TourVM TourVM) {
            this.tourLogs = new TourLogs();
            //InitTours();
            tourVM = TourVM;
        }

        public TourLogVM(Tour selectedTour) {
            currentTour = selectedTour;
        }

        public TourLogVM() {
            this.tourLogs = new TourLogs();
        }

        private void InitTours() {
            Items = new ObservableCollection<TourLog>();
            //GetTours();
        }

        /*public void GetTours() {
            foreach (TourLog item in this.tourLogs.GetItems(CurrentItem)) {
                Items.Add(item);
            }
        }*/

        public TourLog CurrentItem {
            get { return currentItem; }
            set {
                if ((currentItem != value) && (value != null)) {
                    currentItem = value;
                    NotifyPropertyChanged(nameof(CurrentItem));
                }
            }
        }

        public Tour CurrentTour {
            get { return currentTour; }
            set {
                if ((currentTour != value) && (value != null)) {
                    currentTour = value;
                    NotifyPropertyChanged(nameof(CurrentTour));
                }
            }
        }

        public TourLogs TourLogs {
            get { return tourLogs; }
            set {
                if ((tourLogs != value) && (value != null)) {
                    tourLogs = value;
                    NotifyPropertyChanged(nameof(TourLogs));
                }
            }
        }

        public string LogId {
            get {
                return logId;
            }
            set {
                if (logId != value) {
                    logId = value;
                    NotifyPropertyChanged(nameof(LogId));
                }
            }
        }

        public string Date {
            get {
                return date;
            }
            set {
                if (date != value) {
                    date = value;
                    NotifyPropertyChanged(nameof(Date));
                }
            }
        }
        public string Report {
            get {
                return report;
            }
            set {
                if (report != value) {
                    report = value;
                    NotifyPropertyChanged(nameof(Report));
                }
            }
        }
        public string Duration {
            get {
                return duration;
            }
            set {
                if (duration != value) {
                    duration = value;
                    NotifyPropertyChanged(nameof(Duration));
                }
            }
        }
        public string Distance {
            get {
                return distance;
            }
            set {
                if (distance != value) {
                    distance = value;
                    NotifyPropertyChanged(nameof(Distance));
                }
            }
        }
        public string Rating {
            get {
                return rating;
            }
            set {
                if (rating != value) {
                    rating = value;
                    NotifyPropertyChanged(nameof(Rating));
                }
            }
        }
        public string Avg_speed {
            get {
                return avg_speed;
            }
            set {
                if (avg_speed != value) {
                    avg_speed = value;
                    NotifyPropertyChanged(nameof(Avg_speed));
                }
            }
        }
        public string TourId {
            get {
                return tourId;
            }
            set {
                if (tourId != value) {
                    tourId = value;
                    NotifyPropertyChanged(nameof(TourId));
                }
            }
        }
    }
}
