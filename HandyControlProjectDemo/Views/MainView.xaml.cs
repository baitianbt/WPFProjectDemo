using System.Windows;
using System.Windows.Controls;
using HandyControlProjectDemo.ViewModels;

namespace HandyControlProjectDemo.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel viewModel)
            {
                viewModel.NavigateToUserManage();
            }
        }
    }
} 