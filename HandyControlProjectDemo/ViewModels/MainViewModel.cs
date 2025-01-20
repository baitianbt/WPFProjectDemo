using System;
using System.Windows.Threading;
using HandyControlProjectDemo.Services;
using Stylet;

namespace HandyControlProjectDemo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IUserService _userService;
        private readonly IWindowManager _windowManager;
        private string _currentUser;
        private string _currentTime;
        private ViewModelBase _currentView;

        public string CurrentUser
        {
            get => _currentUser;
            set => SetAndNotify(ref _currentUser, value);
        }

        public string CurrentTime
        {
            get => _currentTime;
            set => SetAndNotify(ref _currentTime, value);
        }

        public ViewModelBase CurrentView
        {
            get => _currentView;
            set => SetAndNotify(ref _currentView, value);
        }

        public MainViewModel(IWindowManager windowManager, IUserService userService)
        {
            _windowManager = windowManager;
            _userService = userService;
            CurrentUser = UserService.GetCurrentUsername();

            // 初始化时钟更新
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += Timer_Tick;
            timer.Start();

            UpdateTime();

            // 默认显示用户管理页面
            NavigateToUserManage();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            CurrentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public void NavigateToUserManage()
        {
            if (CurrentView is UserManageViewModel) return;
            CurrentView = new UserManageViewModel(_windowManager);
        }

        public void Exit()
        {
            _userService.Logout();
            RequestClose();
        }
    }
} 