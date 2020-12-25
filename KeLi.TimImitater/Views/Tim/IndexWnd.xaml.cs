using System.Windows.Input;

using KeLi.TimImitater.ViewModels;

namespace KeLi.TimImitater.Views.Tim
{
    public partial class IndexWnd
    {
        public IndexWnd()
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