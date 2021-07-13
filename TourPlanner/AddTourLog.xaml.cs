using Models;
using System.Windows;
using ViewModels;

namespace TourPlanner {

    public partial class AddTourLog : Window {
        public TourLogVM TourLogVM { get; set; }
        public AddTourLog() {
            InitializeComponent();
            TourLogVM = new TourLogVM();
            this.DataContext = TourLogVM;
        }
        public AddTourLog(Tour currentTour) {
            InitializeComponent();
            DataContext = new TourLogVM(currentTour);
        }
    }
}
