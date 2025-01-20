using HandyControl.Controls;
using HandyControlProjectDemo.Services;
using Stylet;

namespace HandyControlProjectDemo.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IWindowManager _windowManager;
        private readonly IUserService _userService;
        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set => SetAndNotify(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetAndNotify(ref _password, value);
        }

        public LoginViewModel(IWindowManager windowManager, IUserService userService)
        {
            _windowManager = windowManager;
            _userService = userService;
        }

        public async void Login()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                Growl.Warning("请输入用户名和密码");
                return;
            }

            var (success, message) = await _userService.LoginAsync(Username, Password);
            if (success)
            {
                Growl.Success(message);
                var mainVm = new MainViewModel(_userService);
                _windowManager.ShowWindow(mainVm);
                RequestClose();
            }
            else
            {
                Growl.Error(message);
            }
        }
    }
} 