using System.Windows;
using System.Windows.Controls;

namespace TestWPFSample
{
    public class HotReloadTestControl : Control
    {
        // DependencyProperty
        public static readonly DependencyProperty StatusTextProperty =
            DependencyProperty.Register(
                nameof(StatusText),
                typeof(string),
                typeof(HotReloadTestControl),
                new PropertyMetadata("Default status"));

        public string StatusText
        {
            get => (string)GetValue(StatusTextProperty);
            set => SetValue(StatusTextProperty, value);
        }

        // RoutedEvent
        public static readonly RoutedEvent StatusChangedEvent =
            EventManager.RegisterRoutedEvent(
                nameof(StatusChanged),
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(HotReloadTestControl));

        public event RoutedEventHandler StatusChanged
        {
            add => AddHandler(StatusChangedEvent, value);
            remove => RemoveHandler(StatusChangedEvent, value);
        }

        public void RaiseStatusChanged()
        {
            RaiseEvent(new RoutedEventArgs(StatusChangedEvent));
        }
    }
}