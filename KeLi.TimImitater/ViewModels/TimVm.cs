using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using KeLi.TimImitater.Models;

using Prism.Commands;
using Prism.Mvvm;

namespace KeLi.TimImitater.ViewModels
{
    internal class TimVm : BindableBase
    {
        private BitmapImage _head;

        private string _nickName;

        public TimVm()
        {
            Friends = new ObservableCollection<Friend>
            {
                new Friend { Nickname = "Devil", Head = new BitmapImage(new Uri("pack://application:,,,/Resources/head1.jpg")) },
                new Friend { Nickname = "Sugar Baby", Head = new BitmapImage(new Uri("pack://application:,,,/Resources/head2.jpg")) },
                new Friend { Nickname = "Fat Tiger", Head = new BitmapImage(new Uri("pack://application:,,,/Resources/head3.jpg")) },
                new Friend { Nickname = "Flower", Head = new BitmapImage(new Uri("pack://application:,,,/Resources/head4.jpg")) },
                new Friend { Nickname = "Old Wang", Head = new BitmapImage(new Uri("pack://application:,,,/Resources/head5.jpg")) },
                new Friend { Nickname = "Dog", Head = new BitmapImage(new Uri("pack://application:,,,/Resources/head6.jpg")) }
            };

            CloseCommand = new DelegateCommand(() => { Application.Current.Shutdown(); });

            SelectItemChangedCommand = new DelegateCommand<object>(p =>
            {
                if (!(p is ListView lv))
                    return;

                if (lv.SelectedItem is Friend friend)
                {
                    Head = friend.Head;
                    NickName = friend.Nickname;
                }
            });
        }

        public DelegateCommand<object> SelectItemChangedCommand { get; set; }

        public DelegateCommand CloseCommand { get; set; }

        public ObservableCollection<Friend> Friends { get; set; }

        public BitmapImage Head
        {
            get => _head;
            set => SetProperty(ref _head, value);
        }

        public string NickName
        {
            get => _nickName;
            set => SetProperty(ref _nickName, value);
        }
    }
}