using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace TestWPFSample
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _userName = "Angelina";
        private string _statusText = "Готово";
        private bool _isHighlightEnabled;
        private int _counter;

        public MainViewModel()
        {
            AddMessageCommand = new RelayCommand(AddMessage);
            IncreaseCounterCommand = new RelayCommand(IncreaseCounter);

            Messages.Add("Приложение запущено");
            Messages.Add("Можно тестировать XAML Hot Reload");
            Messages.Add("Можно тестировать C# Hot Reload");
        }

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
                StatusText = $"Привет, {_userName}";
            }
        }

        public string StatusText
        {
            get => _statusText;
            set
            {
                _statusText = value;
                OnPropertyChanged();
            }
        }

        public bool IsHighlightEnabled
        {
            get => _isHighlightEnabled;
            set
            {
                _isHighlightEnabled = value;
                OnPropertyChanged();
            }
        }

        public int Counter
        {
            get => _counter;
            set
            {
                _counter = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Messages { get; } = new();

        public ICommand AddMessageCommand { get; }

        public ICommand IncreaseCounterCommand { get; }

        public void AddTickMessage()
        {
            Messages.Insert(0, $"Live tick: {DateTime.Now:T}");

            while (Messages.Count > 10)
            {
                Messages.RemoveAt(Messages.Count - 1);
            }
        }

        private void AddMessage()
        {
            Messages.Insert(0, $"Сообщение от {UserName} в {DateTime.Now:T}");
            StatusText = "Добавлено новое сообщение";

            while (Messages.Count > 10)
            {
                Messages.RemoveAt(Messages.Count - 1);
            }
        }

        private void IncreaseCounter()
        {
            Counter++;
            StatusText = $"Counter = {Counter}";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}