using System;
using System.Windows;
using System.Windows.Threading;
using TestWPFSample;

namespace WpfHotReloadDemo
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;
        private readonly DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainViewModel();
            DataContext = _viewModel;

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(2)
            };

            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            _viewModel.AddTickMessage();
        }

        private void OpenDetails_Click(object sender, RoutedEventArgs e)
        {
            var detailsWindow = new DetailsWindow
            {
                Owner = this
            };

            detailsWindow.ShowDialog();
        }
    }
}