using TourPlanner.Commands;
using TourPlanner.Models;
using System.Windows.Input;

namespace ViewModels {
    public class EditTourLogVM : VMBase {

        private string date, report, duration, distance, rating, avg_speed, tourId, logId;
        private TourLog currentItem;
        public TourVM TourVM { get; set; }

        public EditTourLogVM() { }

        public EditTourLogVM(TourLog selectedLog) {
            currentItem = selectedLog;
        }
        public ICommand EditCommand => new EditTourLogCommand(this);
        public ICommand ClearCommand => new ClearTourLogCommand(this);

        public TourLog CurrentItem {
            get { return currentItem; }
            set {
                if ((currentItem != value) && (value != null)) {
                    currentItem = value;
                    NotifyPropertyChanged(nameof(CurrentItem));
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
