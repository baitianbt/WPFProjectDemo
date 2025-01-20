using System.Windows;
using System.Windows.Input;
using HandyControl.Controls;

namespace HandyControlProjectDemo.Views
{
    public partial class UserEditView : HandyControl.Controls.Window
    {
        public UserEditView()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
} 