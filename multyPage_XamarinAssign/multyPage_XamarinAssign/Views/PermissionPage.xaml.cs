using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PermissionPage : ContentPage
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
        int userId;
        public PermissionPage(int id)
        {
            _user = new User();
            userId = id;
            InitializeComponent();   
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _user = await App.Database.GetItemAsyncById(Convert.ToInt32(userId));

            if (_user.IsRead == true)
            {
                chkRead.IsChecked = true;
                chkRead.IsEnabled = false;
            }

            if (_user.IsDelete == true)
            {
                chkDelete.IsChecked = true;
                chkDelete.IsEnabled = false;
            }

            if (_user.IsWrite == true)
            {
                chkModify.IsChecked = true;
                chkModify.IsEnabled = false;
            }
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            string message = null;
            if (_user.IsValid(out message))
            {
                bool choice = await DisplayAlert("Create Account", "Are you sure you want to update an account with this username: " + _user.Username, "Yes", "No");
                if (choice == true)
                {
                    _user.UserId = Convert.ToInt32(userId);

                    if (chkRead.IsChecked == true)
                    {
                        _user.IsRead = true;
                    }

                    if (chkDelete.IsChecked == true)
                    {
                        _user.IsDelete = true;
                    }

                    if (_user.IsWrite == true)
                    {
                        chkModify.IsChecked = true;
                    }

                    await App.Database.UpdateUserAsync(_user);
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