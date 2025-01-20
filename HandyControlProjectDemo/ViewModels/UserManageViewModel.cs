using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using HandyControl.Controls;
using Stylet;

namespace HandyControlProjectDemo.ViewModels
{
    public class UserManageViewModel : ViewModelBase
    {
        private readonly IWindowManager _windowManager;
        private ObservableCollection<UserInfo> _users;
        private UserInfo _selectedUser;

        public ObservableCollection<UserInfo> Users
        {
            get => _users;
            set => SetAndNotify(ref _users, value);
        }

        public UserInfo SelectedUser
        {
            get => _selectedUser;
            set => SetAndNotify(ref _selectedUser, value);
        }

        public ICommand AddUserCommand { get; }
        public ICommand EditUserCommand { get; }
        public ICommand DeleteUserCommand { get; }

        public UserManageViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
            AddUserCommand = new ActionCommand(AddUser);
            EditUserCommand = new ActionCommand(EditUser);
            DeleteUserCommand = new ActionCommand(DeleteUser);
            LoadUsers();
        }

        private void LoadUsers()
        {
            // 模拟从数据库加载用户数据
            Users = new ObservableCollection<UserInfo>
            {
                new UserInfo { Id = 1, Username = "admin", RealName = "管理员", Role = "管理员", Status = "启用" },
                new UserInfo { Id = 2, Username = "user1", RealName = "用户1", Role = "普通用户", Status = "启用" },
                new UserInfo { Id = 3, Username = "user2", RealName = "用户2", Role = "普通用户", Status = "禁用" }
            };
        }

        private void AddUser()
        {
            var vm = new UserEditViewModel(_windowManager);
            var result = _windowManager.ShowDialog(vm);

            if (result == true)
            {
                var newUser = vm.GetUserInfo();
                newUser.Id = Users.Max(u => u.Id) + 1;
                Users.Add(newUser);
                Growl.Success("添加用户成功！");
            }
        }

        private void EditUser()
        {
            if (SelectedUser == null)
            {
                Growl.Warning("请先选择要编辑的用户");
                return;
            }

            var vm = new UserEditViewModel(_windowManager, SelectedUser);
            var result = _windowManager.ShowDialog(vm);

            if (result == true)
            {
                var editedUser = vm.GetUserInfo();
                var index = Users.IndexOf(SelectedUser);
                Users[index] = editedUser;
                Growl.Success("编辑用户成功！");
            }
        }

        private void DeleteUser()
        {
            if (SelectedUser == null)
            {
                Growl.Warning("请先选择要删除的用户");
                return;
            }

            if (SelectedUser.Username == "admin")
            {
                Growl.Error("不能删除管理员账号！");
                return;
            }

            Growl.Ask("确定要删除该用户吗？", isConfirmed =>
            {
                if (isConfirmed)
                {
                    Users.Remove(SelectedUser);
                    Growl.Success("删除用户成功！");
                }
                return true;
            });
        }
    }

    public class ActionCommand : ICommand
    {
        private readonly System.Action _execute;

        public ActionCommand(System.Action execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event System.EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }

    public class UserInfo
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string RealName { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
    }
} 