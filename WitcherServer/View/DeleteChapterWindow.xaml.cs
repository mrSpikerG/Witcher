﻿using System;
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
    /// Логика взаимодействия для DeleteChapterWindow.xaml
    /// </summary>
    public partial class DeleteChapterWindow : Window {
        public DeleteChapterWindow(WitcherContext context) {
            InitializeComponent();
            this.DataContext = new DeleteChapterViewModel(context);
        }
    }
}