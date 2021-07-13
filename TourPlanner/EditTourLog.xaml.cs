using Models;
using System.Windows;
using ViewModels;

namespace TourPlanner {
    public partial class EditTourLog : Window {
        public EditTourLog() {
            InitializeComponent();
        }
        public EditTourLog(TourLog selectedLog) {
            InitializeComponent();
            DataContext = new EditTourLogVM(selectedLog);
        }
    }
}
