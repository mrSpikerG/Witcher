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
using System.Windows.Shapes;
using WitcherServer.Model;
using WitcherServer.ViewModel;

namespace WitcherServer.View {
    /// <summary>
    /// Логика взаимодействия для CreateCharacterWindow.xaml
    /// </summary>
    public partial class CreateCharacterWindow : Window {
        public CreateCharacterWindow( WitcherContext context) {
            InitializeComponent();
            this.DataContext = new CreateCharacterViewModel(context);
        }
    }
}
