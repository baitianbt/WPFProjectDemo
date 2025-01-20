using System.Collections.ObjectModel;
using HandyControl.Controls;
using Stylet;

namespace HandyControlProjectDemo.ViewModels
{
    public class UserManageViewModel : ViewModelBase
    {
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

        public UserManageViewModel()
        {
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

        public void AddUser()
        {
            Growl.Info("添加用户功能待实现");
        }

        public void EditUser()
        {
            if (SelectedUser == null)
            {
                Growl.Warning("请先选择要编辑的用户");
                return;
            }
            Growl.Info("编辑用户功能待实现");
        }

        public void DeleteUser()
        {
            if (SelectedUser == null)
            {
                Growl.Warning("请先选择要删除的用户");
                return;
            }
            Growl.Info("删除用户功能待实现");
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