using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace TestWPFSample
{
    public partial class DetailsWindow : Window
    {
        private int _localCounter = 0;

        public DetailsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var fadeAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(1.0)
            };

            AnimatedHeader.BeginAnimation(OpacityProperty, fadeAnimation);
        }

        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            // СТАВЬ BREAKPOINT ЗДЕСЬ
            _localCounter++;

            ResultText.Text = $"Нажатий: {_localCounter}. Время: {DateTime.Now:T}";
            DetailsStatus.Text = _localCounter % 2 == 0
                ? "Статус: четное нажатие"
                : "Статус: нечетное нажатие";
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
