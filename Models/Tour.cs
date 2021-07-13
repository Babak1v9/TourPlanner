using System.Collections.ObjectModel;

namespace Models {
    public class Tour {

        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public string distance { get; set; }

        public string from { get; set; }
        public string to { get; set; }
        public string routeInfo { get; set; }
        public ObservableCollection<TourLog> Logs {
            get { return Logs; }
            set { Logs = value; }
        }
    }
}
