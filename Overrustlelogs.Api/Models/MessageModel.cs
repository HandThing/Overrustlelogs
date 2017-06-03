﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Overrustlelogs.Api.Interfaces;

namespace Overrustlelogs.Api.Models {
    public class MessageModel : IMessageModel, INotifyPropertyChanged {
        private readonly IApiLogs _apiLogs;
        public string Text { get; set; }
        public string Month { get; set; }
        private string _url { get; set; }

        public MessageModel(string text, string month, string url, IApiLogs apiLogs) {
            _apiLogs = apiLogs;
            Text = text;
            Month = month;
            _url = url;
            GetLogCommand = new ActionCommand(async () => await GetLog());
        }

        public bool GetLogButtonVisibility { get; set; } = true;
        public ICommand GetLogCommand { get; }

        private async Task GetLog() {
            if (Text != null && Text == "Not Found") {
                return;
            }
            var text = await _apiLogs.GetLogString(_url);
            if (text == null) {
                Text = "Error try again";
                return;
            }
            Text = text;
            GetLogButtonVisibility = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
