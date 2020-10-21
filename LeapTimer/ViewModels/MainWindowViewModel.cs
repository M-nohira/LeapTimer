using Prism.Mvvm;
using Prism.Events;
using System.Windows.Input;
using Prism.Commands;
using System.Runtime.InteropServices;
using System;
using System.Timers;

using System.Windows;

namespace LeapTimer.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public static Views.MainWindow window { get; set; }

        private string _title = "時を掛ける少女時計";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _time = "00:00:00:000";
        public string Time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }


        private DelegateCommand<object> windowClicked;
        public DelegateCommand<object> WindowClicked => windowClicked = windowClicked ?? new DelegateCommand<object>(OnWindowClicked);
        public void OnWindowClicked(object e)
        {
            if ((MouseButton)e == MouseButton.Left)
                window.DragMove();
        }
        public MainWindowViewModel()
        {
            var timer = new Timer();
            timer.Interval = 10;
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;
            Time = now.ToString("HH:MM:ss:fff");
        }
    }
}
