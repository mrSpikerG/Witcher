using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WitcherServer.ViewModel;

namespace WitcherServer.View {
    /// <summary>
    /// Логика взаимодействия для CreatePageTableWindow.xaml
    /// </summary>
    public partial class CreatePageTableWindow : Window {
        public CreatePageTableWindow() {
            InitializeComponent();
            this.DataContext= new CreatePageTableViewModel();
        }
    }
}
