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
using Witcher.Model;
using Witcher.ViewModel;

namespace Witcher.View
{
    /// <summary>
    /// Логика взаимодействия для CharacterListWindow.xaml
    /// </summary>
    public partial class CharacterListWindow : Window
    {
        public CharacterListWindow(string chapter, WitcherContext context)
        {
            InitializeComponent();
            this.DataContext = new CharListViewModel(chapter,context);
        }
    }
}
