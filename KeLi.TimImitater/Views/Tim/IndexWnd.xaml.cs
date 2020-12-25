using System.Windows.Input;

using KeLi.TimImitater.Models;
using KeLi.TimImitater.ViewModels;

namespace KeLi.TimImitater.Views.Tim
{
    public partial class IndexWnd : BaseWindow
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