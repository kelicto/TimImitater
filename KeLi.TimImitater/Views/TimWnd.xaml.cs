﻿using System.Windows.Input;

using KeLi.TimImitater.ViewModes;

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