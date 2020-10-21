using System.Windows;
using System.Windows.Interop;

namespace LeapTimer.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModels.MainWindowViewModel.window = this;
        }
    }
}
