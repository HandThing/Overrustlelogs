﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Overrustlelogs.Api.Interfaces;
using Overrustlelogs.ViewModels.ViewModels;

namespace Overrustlelogs.ViewModels {
    public class ViewModelFactory {
        private readonly IApiChannels _apiChannels;
        private readonly IApiMonths _apiMonths;
        private readonly IApiDays _apiDays;
        private readonly IApiLogs _apiLogs;

        public ViewModelFactory(IApiChannels apiChannels, IApiMonths apiMonths, IApiDays apiDays, IApiLogs apiLogs) {
            _apiChannels = apiChannels;
            _apiMonths = apiMonths;
            _apiDays = apiDays;
            _apiLogs = apiLogs;
        }

        public MainWindowViewModel CreateMainWindowViewModel => new MainWindowViewModel(this);
        public ChannelsViewModel CreateChannelsViewModel => new ChannelsViewModel(_apiChannels);
        public MonthsViewModel CreateMonthsViewModel(Action<string, string, string, string> changeTitle) => new MonthsViewModel(_apiMonths, changeTitle);
        public DaysViewModel CreateDaysViewModel( Action<string, string, string, string> changeTitle) => new DaysViewModel(changeTitle, _apiDays);
        public UserLogViewModel CreateLogsViewModel() => new UserLogViewModel(_apiLogs, _apiChannels);
    }
}
