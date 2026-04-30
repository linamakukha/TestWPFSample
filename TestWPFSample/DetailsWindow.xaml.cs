using System;
using System.Windows;
using System.Windows.Media;
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

            var subtitleFade = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(1.4)
            };

            SlidingSubtitle.BeginAnimation(OpacityProperty, subtitleFade);

            var ellipseBrush = new SolidColorBrush(Colors.MediumPurple);
            ColorChangingEllipse.Fill = ellipseBrush;

            var colorAnimation = new ColorAnimation
            {
                From = Colors.MediumPurple,
                To = Colors.DeepPink,
                Duration = TimeSpan.FromSeconds(1.2),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };

            ellipseBrush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);

            var translateTransform = new TranslateTransform();
            JumpingRect.RenderTransform = translateTransform;

            var jumpAnimation = new DoubleAnimation
            {
                From = 0,
                To = -25,
                Duration = TimeSpan.FromSeconds(0.65),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever,
                EasingFunction = new BounceEase
                {
                    Bounces = 2,
                    Bounciness = 2
                }
            };

            translateTransform.BeginAnimation(TranslateTransform.YProperty, jumpAnimation);
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