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
                    Console.WriteLine(_user.Username);
                    Console.WriteLine(_user.Password);

                    await App.Database.SavePersonAsync(_user);
                    await Navigation.PopAsync();
                }

            }
            else
            {

                await DisplayAlert("Empty Fields or Weak Password", message, "Ok");
            }
            //    string UserName = txtRegUserName.Text;
            //    string FirstName = txtRegUserName.Text;
            //    string LastName = txtRegUserName.Text;
            //    string Phone = txtRegUserName.Text;
            //    string Email = txtRegEmail.Text;
            //    string PassWord = txtRegPassword.Text;

            //    if (!string.IsNullOrWhiteSpace(UserName) &&
            //        !string.IsNullOrWhiteSpace(FirstName) &&
            //        !string.IsNullOrWhiteSpace(LastName) &&
            //        !string.IsNullOrWhiteSpace(Phone) &&
            //        !string.IsNullOrWhiteSpace(LastName) &&
            //        !string.IsNullOrWhiteSpace(PassWord))
            //    {
            //        if (PassWord.Length >= 10)
            //        {
            //            bool choice = await DisplayAlert("Create Account", "Are you sure you want to create an account with this username: " + UserName, "Yes", "No");
            //            if (choice == false)
            //            {
            //                user.Username = null;
            //                user.FirstName = null;
            //                user.LastName = null;
            //                user.Email = null;
            //                user.Phone = null;
            //                user.Password = null;
            //                txtRegUserName.Text = "";
            //                txtRegFirst.Text = "";
            //                txtRegLast.Text = "";
            //                txtRegPhone.Text = "";
            //                txtRegPassword.Text = "";
            //                txtRegEmail.Text = "";
            //            }
            //            else
            //            {
            //                await App.Database.SavePersonAsync(new User
            //                {
            //                    Username = txtRegUserName.Text,
            //                    FirstName = txtRegFirst.Text,
            //                    LastName = txtRegLast.Text,
            //                    Phone = txtRegPhone.Text,
            //                    Email = txtRegEmail.Text,
            //                    Password = txtRegPassword.Text,
            //                });
            //                await Navigation.PushAsync(new LoginPage());
            //                isAdded = true;
            //            }
            //        }
            //        else
            //        {
            //            await DisplayAlert("Password Error", "Password must be atleast 10 characters", "Ok");
            //        }

            //    }
            //    else { await DisplayAlert("Empty Fields", "Please fill all fields.", "Ok"); }

        }
    }
}