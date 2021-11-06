using System.ComponentModel;

namespace multyPage_XamarinAssign.Config
{
    public class Bindings : INotifyPropertyChanged
    {
        private string _nameValue;

        public string NameValue
        {
            get => _nameValue;
            set
            {
                if (value == _nameValue)
                    return;
                _nameValue = value;
                OnPropertyChanged(nameof(NameValue));
                OnPropertyChanged(nameof(GetNameValue));
            }
        }

        public string GetNameValue => $"You entered {NameValue}";

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}