using System.Threading.Tasks;

namespace HandyControlProjectDemo.Services
{
    public interface IUserService
    {
        Task<(bool success, string message)> LoginAsync(string username, string password);
        void Logout();
    }

    public class UserService : IUserService
    {
        private static string CurrentUsername { get; set; }

        public async Task<(bool success, string message)> LoginAsync(string username, string password)
        {
            // 模拟异步登录过程
            await Task.Delay(500);

            // TODO: 实现实际的登录逻辑，比如调用API或数据库验证
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return (false, "用户名和密码不能为空！");
            }

            if (username == "admin" && password == "123456")
            {
                CurrentUsername = username;
                return (true, "登录成功！");
            }

            return (false, "用户名或密码错误！");
        }

        public void Logout()
        {
            CurrentUsername = null;
        }

        public static string GetCurrentUsername()
        {
            return CurrentUsername;
        }
    }
} 