using Models;
using System.Windows;
using ViewModels;

namespace TourPlanner {
    public partial class EditTour : Window {
        public EditTour() {
            InitializeComponent();
        }

        public EditTour(Tour selectedTour) {
            InitializeComponent();
            DataContext = new EditTourVM(selectedTour);
        }
    }
}
