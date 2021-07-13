using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Models;
using BusinessLayer;
using TourPlanner.Commands;

namespace ViewModels {

    public class MainVM : VMBase {

        private Tour currentItem;
        private TourLog selectedLog;
        private TourHandler tours;
        private TourLogHandler tourLogs;
        private string searchName;
        private readonly string title = "Tour Planner";

        public ICommand AddCommand => new OpenAddTourCommand(this);
        public ICommand EditCommand => new OpenEditTourCommand(this);
        public ICommand DeleteCommand => new DeleteTourCommand(this);
        public ICommand CopyCommand => new CopyTourCommand(this);

        public ICommand SearchTourCommand => new SearchTourCommand(this);
        public ICommand SearchLogCommand => new SearchLogCommand(this);
        public ICommand ClearCommand => new ClearSearchCommand(this);
        public ICommand OptionsCommand => new OpenOptionsCommand(this);

        public ICommand OpenAddTourLogCommand => new OpenAddTourLogCommand(this);
        public ICommand EditTourLogCommand => new OpenEditTourLogCommand(this);
        public ICommand DeleteTourLogCommand => new DeleteTourLogCommand(this);
        public ICommand ExportJsonCommand => new ExportJsonCommand(this);
        public ICommand ImportJsonCommand => new ImportJsonCommand(this);
        public ICommand ReportCommand => new ReportCommand(this);

        public ICommand ExitAppCommand => new ExitAppCommand(this);
        public ObservableCollection<Tour> Items { get; set; }
        public ObservableCollection<TourLog> LogItems { get; set; }

        public string Title {
            get {
                return title;
            }
        }

        public string SearchName {
            get { return searchName; }
            set {
                if ((searchName != value) && (value != null)) {
                    searchName = value;
                    NotifyPropertyChanged(nameof(SearchName));
                }
            }
        }

        public MainVM() {
            this.tours = new TourHandler();
            this.tourLogs = new TourLogHandler();
            InitTours();
            GetAllLogs();
            if (Items.Count != 0) {
                currentItem = Items[0];
            }
        }

        private void InitTours() {
            Items = new ObservableCollection<Tour>();
            GetTours();
        }

        public void GetTours() {
            Items.Clear();
            foreach (Tour item in this.tours.GetItems()) {

                Items.Add(item);
            }
        }

        public void FilterLogs() {

            /*IEnumerable<TourLog> items = GetAllLogs();
            
            IEnumerable foundItems = items.Where(x => x.tourId.Contains(currentItem.id));

            LogItems.Clear();
            
            foreach (TourLog item in foundItems) {
                LogItems.Add(item);
            }
            */
            IEnumerable foundItems = TourLogs.SearchById(CurrentItem.id);
            LogItems.Clear();
            foreach (TourLog item in foundItems) {
                LogItems.Add(item);
            }
            NotifyPropertyChanged(nameof(LogItems));
        }

        public ObservableCollection<TourLog> GetAllLogs() {
            LogItems = new ObservableCollection<TourLog>();
            foreach (TourLog item in this.tourLogs.GetItems()) {
                LogItems.Add(item);
            }
            return LogItems;
        }

        public Tour CurrentItem {
            get { return currentItem; }
            set {
                if ((currentItem != value) && (value != null)) {
                    currentItem = value;
                    NotifyPropertyChanged(nameof(CurrentItem));
                }
            }
        }
        public TourLog SelectedLog {
            get { return selectedLog; }
            set {
                if ((selectedLog != value) && (value != null)) {
                    selectedLog = value;
                    NotifyPropertyChanged(nameof(SelectedLog));
                }
            }
        }

        public TourHandler Tours {
            get { return tours; }
            set {
                if ((tours != value) && (value != null)) {
                    tours = value;
                    NotifyPropertyChanged(nameof(Tours));
                }
            }
        }

        public TourLogHandler TourLogs {
            get { return tourLogs; }
            set {
                if ((tourLogs != value) && (value != null)) {
                    tourLogs = value;
                    NotifyPropertyChanged(nameof(TourLogs));
                }
            }
        }
    }
}
