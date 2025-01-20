using Stylet;

namespace HandyControlProjectDemo.ViewModels
{
    public class RootViewModel : PropertyChangedBase
    {
        private string _title = "测试DEMO";

        public string Title
        {
            get { return _title; }
            set { SetAndNotify(ref _title, value); }
        }

        public RootViewModel()
        {

        }
    }
}
