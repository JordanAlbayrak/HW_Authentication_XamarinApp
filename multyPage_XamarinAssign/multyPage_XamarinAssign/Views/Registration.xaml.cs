using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage, INotifyPropertyChanged
    {

        public new event PropertyChangedEventHandler PropertyChanged;

        private User _user;

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(User)));
            }
        }
        public Registration()
        {
            _user = new User();
            InitializeComponent();
            BindingContext = this;
        }

        async public void btnRegister_Clicked(object sender, EventArgs e)
        {
            string message = null;
            if (_user.IsValid(out message))
            {
                bool choice = await DisplayAlert("Create Account", "Are you sure you want to create an account with this username: " + _user.Username, "Yes", "No");
                if (choice == true)
                {
                    if (_user.Username.Equals("admin"))
                    {
                        _user.Role = Models.RoleType.Admin;
                        _user.AddPermissions();
                    }
                    else if (_user.Username == "intern")
                    {
                        _user.Role = Models.RoleType.Intern;
                        _user.AddPermissions();
                    }
                    else
                    {
                        _user.Role = Models.RoleType.Viewer;
                        _user.AddPermissions();
                    }
                    
                    await App.Database.SaveUserAsync(_user);
                    await Navigation.PopAsync();
                }

            }
            else
            {
                await DisplayAlert("Empty Fields or Weak Password", message, "Ok");
            }         
        }
    }
}