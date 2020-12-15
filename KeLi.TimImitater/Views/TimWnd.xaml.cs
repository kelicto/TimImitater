using System.Windows.Input;

using KeLi.TimImitater.ViewModels;

namespace KeLi.TimImitater.Views
{
    public partial class TimWnd
    {
        public TimWnd()
        {
            InitializeComponent();
            DataContext = new TimVm();
        }

        private void NavBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}