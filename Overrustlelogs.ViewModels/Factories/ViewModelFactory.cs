﻿using System;
using Overrustlelogs.ViewModels.Interfaces;
using Overrustlelogs.ViewModels.Utils;
using Overrustlelogs.ViewModels.ViewModels;
using Overrustlelogs.ViewModels.ViewModels.Directory;
using Overrustlelogs.ViewModels.ViewModels.Stalk;

namespace Overrustlelogs.ViewModels.Factories {
    public class ViewModelFactory : IViewModelFactory {
        private readonly IApiFactory _apiFactory;
        private readonly Action<string> _snackbarMessageQueue;
        private readonly CurrentState _currentState;

        public ViewModelFactory(IApiFactory apiFactory, Action<string> snackbarMessageQueue, CurrentState currentState) {
            _apiFactory = apiFactory;
            _snackbarMessageQueue = snackbarMessageQueue;
            _currentState = currentState;
        }

        public MainWindowViewModel CreateMainWindowViewModel => new MainWindowViewModel(this, _snackbarMessageQueue, _currentState);
        public ChannelsViewModel CreateChannelsViewModel => new ChannelsViewModel(_apiFactory.GetApiChannels(), _currentState);

        public MonthsViewModel CreateMonthsViewModel(Action<string, string> changeTitle) {
            return new MonthsViewModel(_apiFactory.GetApiMonths(), changeTitle, _currentState);
        }

        public DaysViewModel CreateDaysViewModel(Action<string, string> changeTitle) {
            return new DaysViewModel(changeTitle, _apiFactory.GetApiDayss(), _currentState);
        }

        public StalkViewModel CreateStalkViewModel() {
            return new StalkViewModel(this);
        }
        public StalkSingleViewModel CreateStalkSingleViewModel() {
            return new StalkSingleViewModel(_apiFactory.GetApiLogss(), _apiFactory.GetApiChannels(), _currentState);
        }
        public StalkMultiViewModel CreateStalkMultiViewModel() {
            return new StalkMultiViewModel(_apiFactory.GetApiLogss(), _apiFactory.GetApiChannels() , _currentState);
        }

        public UserlogsViewModel CreateUserlogsViewModel(Action<string, string> changeTitle) {
            return new UserlogsViewModel(changeTitle, _apiFactory.GetApiUserlogs(), _currentState);
        }

        public MentionsViewModel CreateMentionsViewModel() {
            return new MentionsViewModel(_apiFactory.GetApiChannels(), _apiFactory.GetApiMentions(), _currentState);
        }
    }
}