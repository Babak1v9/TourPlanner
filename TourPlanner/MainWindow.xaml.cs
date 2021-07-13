using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ViewModels;

namespace TourPlanner {
    public partial class MainWindow : Window {
        public MainVM MainVM { get; set; }
        public TourLogVM TourLogVM { get; set; }
        public MainWindow() {
            InitializeComponent();
            MainVM = new MainVM();
            TourLogVM = new TourLogVM(MainVM);
            this.DataContext = MainVM;
        }
        private void PlaceholdersListBox_OnPreviewMouseDown(object sender, MouseButtonEventArgs e) {
            var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null) {
                // ListBox item clicked - do some cool things here
                MainVM.FilterLogs();
            }
        }
    }
}
