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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Overrustlelogs.Views {
    /// <summary>
    /// Interaction logic for UserLogView.xaml
    /// </summary>
    public partial class UserLogView : UserControl {
        public UserLogView() {
            InitializeComponent();
        }

        private void DownArrow_OnClick(object sender, RoutedEventArgs e) {
            TextLog.ScrollToEnd();
        }

        private void UpArrow_OnClick(object sender, RoutedEventArgs e) {
            TextLog.ScrollToHome();
        }
    }
}