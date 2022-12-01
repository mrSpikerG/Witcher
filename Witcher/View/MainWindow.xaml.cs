using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Witcher.ViewModel;

namespace Witcher {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private MainViewModel ViewModel { get; set; }  
        public MainWindow() {
            InitializeComponent();
            this.ViewModel = new MainViewModel();
            this.DataContext = this.ViewModel;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            this.DragMove();
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e) {
            this.ViewModel.changeSource(true);

        }

        private void Image_MouseLeave(object sender, MouseEventArgs e) {
            this.ViewModel.changeSource(false);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            this.Close();
        }
    }
}
