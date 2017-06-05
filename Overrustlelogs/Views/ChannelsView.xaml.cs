﻿using System;
using System.Windows.Controls;
using System.Windows.Input;
using Overrustlelogs.Api.Models;

namespace Overrustlelogs.Views {
    /// <summary>
    ///     Interaction logic for ChannelsView.xaml
    /// </summary>
    public partial class ChannelsView : UserControl {
        public ChannelsView() {
            InitializeComponent();
            ChannelList.SelectionChanged += (sender, args) => { ChannelList.UnselectAll(); };
            ChannelList.PreviewMouseRightButtonDown += (sender, args) => { args.Handled = true; };
        }
        

        private void Filter_OnTextChanged(object sender, TextChangedEventArgs e) {
            var filterTextbox = (TextBox) sender;
            var filter = filterTextbox.Text;
            foreach (var channelListItem in ChannelList.Items) {
                var item = (ChannelModel) channelListItem;
                if (!item.Name.ToLower().Contains(filter.ToLower())) {
                    item.Visibility = false;
                    continue;
                }
                item.Visibility = true;
            }
        }
    }
}