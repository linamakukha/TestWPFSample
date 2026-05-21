using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace TestWPFSample
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;
        private readonly DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();
            
            MyDatePicker.SelectedDate = DateTime.Today;

            _viewModel = new MainViewModel();
            DataContext = _viewModel;

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(2)
            };

            _timer.Tick += Timer_Tick;
            //_timer.Start();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["RotateSquareStoryboard"]).Begin(this, true);
            ((Storyboard)Resources["MoveCircleStoryboard"]).Begin(this, true);
            ((Storyboard)Resources["SkewTextStoryboard"]).Begin(this, true);

            var rotationAnimation = new DoubleAnimation
            {
                From = 0,
                To = 360,
                Duration = TimeSpan.FromSeconds(5),
                RepeatBehavior = RepeatBehavior.Forever
            };

            PlaneRotation.BeginAnimation(System.Windows.Media.Media3D.AxisAngleRotation3D.AngleProperty, rotationAnimation);
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

        private void ThemeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is not ComboBox comboBox)
            {
                return;
            }

            if (comboBox.SelectedItem is not ComboBoxItem selectedItem)
            {
                return;
            }

            var themeName = selectedItem.Content?.ToString();

            if (!string.IsNullOrWhiteSpace(themeName))
            {
                ThemeService.ApplyTheme(themeName);
            }
        }
        
        private void OpenControlsDemo_Click(object sender, RoutedEventArgs e)
        {
            var window = new ControlsDemoWindow
            {
                Owner = this
            };
        
            window.ShowDialog();
        }

        private void CreateDemoDocument()
        {
            var document = new FixedDocument();

            var page = new FixedPage
            {
                Width = 600,
                Height = 800
            };

            var text = new TextBlock
            {
                Text = "Hello from DocumentViewer",
                FontSize = 28,
                Margin = new Thickness(40)
            };

            page.Children.Add(text);

            var pageContent = new PageContent();
            ((IAddChild)pageContent).AddChild(page);

            document.Pages.Add(pageContent);

            DemoDocumentViewer.Document = document;
        }
        
        private void NestedItemButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nested item button clicked" +
                            "New text added");
        }
    }
}