using HandyControl.Controls;
using Stylet;

namespace HandyControlProjectDemo.ViewModels
{
    public class ViewModelBase : Screen
    {
        protected void ShowSuccess(string message)
        {
            Growl.Success(message);
        }

        protected void ShowError(string message)
        {
            Growl.Error(message);
        }

        protected void ShowWarning(string message)
        {
            Growl.Warning(message);
        }

        protected void ShowInfo(string message)
        {
            Growl.Info(message);
        }
    }
} 