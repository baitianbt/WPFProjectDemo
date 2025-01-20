using HandyControl.Tools;
using HandyControlProjectDemo.Services;
using HandyControlProjectDemo.ViewModels;
using Stylet;
using StyletIoC;

namespace HandyControlProjectDemo
{
    public class Bootstrapper : Bootstrapper<LoginViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            // 注册服务
            builder.Bind<IUserService>().To<UserService>().InSingletonScope();
            
            base.ConfigureIoC(builder);
        }

        protected override void Configure()
        {
            // 配置HandyControl
            ConfigHelper.Instance.SetLang("zh-cn");
            
            base.Configure();
        }
    }
}
