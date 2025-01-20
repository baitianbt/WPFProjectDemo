using HandyControl.Controls;
using Stylet;

namespace HandyControlProjectDemo.ViewModels
{
    public class UserEditViewModel : Screen
    {
        private readonly IWindowManager _windowManager;
        private int _id;
        private string _username;
        private string _realName;
        private string _role;
        private string _status;
        private bool _isAdd;

        public int Id
        {
            get => _id;
            set => SetAndNotify(ref _id, value);
        }

        public string Username
        {
            get => _username;
            set => SetAndNotify(ref _username, value);
        }

        public string RealName
        {
            get => _realName;
            set => SetAndNotify(ref _realName, value);
        }

        public string Role
        {
            get => _role;
            set => SetAndNotify(ref _role, value);
        }

        public string Status
        {
            get => _status;
            set => SetAndNotify(ref _status, value);
        }

        public bool IsAdd
        {
            get => _isAdd;
            set => SetAndNotify(ref _isAdd, value);
        }

        public UserEditViewModel(IWindowManager windowManager, UserInfo user = null)
        {
            _windowManager = windowManager;
            IsAdd = user == null;

            if (user != null)
            {
                Id = user.Id;
                Username = user.Username;
                RealName = user.RealName;
                Role = user.Role;
                Status = user.Status;
            }
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(RealName))
            {
                Growl.Warning("用户名和姓名不能为空！");
                return;
            }

            RequestClose(true);
        }

        public void Cancel()
        {
            RequestClose(false);
        }

        public UserInfo GetUserInfo()
        {
            return new UserInfo
            {
                Id = Id,
                Username = Username,
                RealName = RealName,
                Role = Role ?? "普通用户",
                Status = Status ?? "启用"
            };
        }
    }
} 