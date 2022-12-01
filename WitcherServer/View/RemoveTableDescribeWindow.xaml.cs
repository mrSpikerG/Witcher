using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WitcherServer.ViewModel;


namespace WitcherServer.View {
    /// <summary>
    /// Логика взаимодействия для RemoveTableDescribeWindow.xaml
    /// </summary>
    public partial class RemoveTableDescribeWindow : Window {
        public RemoveTableDescribeWindow() {
            InitializeComponent();
            this.DataContext = new DeletePageTableViewModel();
        }
    }
}
