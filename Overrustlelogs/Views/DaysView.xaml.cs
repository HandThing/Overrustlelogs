﻿using System;
using System.Windows.Controls;
using System.Windows.Input;
using Overrustlelogs.Api.Models;

namespace Overrustlelogs.Views {
    /// <summary>
    ///     Interaction logic for DaysView.xaml
    /// </summary>
    public partial class DaysView : UserControl {
        public DaysView() {
            InitializeComponent();
            DayList.SelectionChanged += (sender, args) => { DayList.UnselectAll(); };
            DayList.PreviewMouseDown += DayListOnPreviewMouseDown;
        }

        private void DayListOnPreviewMouseDown(object o, MouseButtonEventArgs mouseButtonEventArgs) {
            if (mouseButtonEventArgs.RightButton == MouseButtonState.Pressed) {
                DayList.UnselectAll();
                mouseButtonEventArgs.Handled = true;
            }
        }

        private void Filter_OnTextChanged(object sender, TextChangedEventArgs e) {
            var filterTextbox = (TextBox) sender;
            var filter = filterTextbox.Text;
            foreach (var dayListItem in DayList.Items) {
                var item = (DayModel) dayListItem;
                if (!item.Name.ToLower().Contains(filter.ToLower())) {
                    item.Visibility = false;
                    continue;
                }
                item.Visibility = true;
            }
        }
    }
}