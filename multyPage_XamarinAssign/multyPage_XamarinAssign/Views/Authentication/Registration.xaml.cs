using System;
using System.ComponentModel;
using multyPage_XamarinAssign.Config;
using multyPage_XamarinAssign.Models;
using multyPage_XamarinAssign.Models.Enums;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Views.Authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage, INotifyPropertyChanged
    {

        public new event PropertyChangedEventHandler PropertyChanged;

        private User _user;
        private Models.Owner _owner;

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
                        _user.Role = RoleType.Admin;
                        _user.AddPermissions();
                    }
                    else if (_user.Username == "intern")
                    {
                        _user.Role = RoleType.Internal;
                        _user.AddPermissions();
                    }
                    else
                    {
                        _user.Role = RoleType.Viewer;
                        _user.AddPermissions();
                    }
                    
                    await App.Database.SaveUserAsync(_user);

                    _owner = new Models.Owner
                    {
                        OwnerId = _user.UserId,
                        OwnerFirstName = _user.FirstName,
                        OwnerLastName = _user.LastName,
                        OwnerPhoneNumber = _user.Phone,
                    };
                    
                    await App.Database.SaveOwnerAsync(_owner);
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