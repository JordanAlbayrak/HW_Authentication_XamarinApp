using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace multyPage_XamarinAssign
{
    public class Bindings : INotifyPropertyChanged
    {
        string nameValue = null;
        public string NameValue
        {
            get => nameValue;
            set
            {
                if (value == nameValue)
                    return;
                nameValue = value;
                OnPropertyChanged(nameof(NameValue));
                OnPropertyChanged(nameof(GetNameValue));

            }
        }
        public string GetNameValue
        {
            get => $"You entered {NameValue}";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}