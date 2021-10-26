using multyPage_XamarinAssign.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string PassWord = txtPassword.Text;
            try { User u = await App.Database.GetItemAsync(PassWord, userName); 

            if (u.Username.Equals(userName) && u.Password.Equals(PassWord))
            {
                await DisplayAlert("Login result", "Success", "OK");
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Login result", "Incorrect Username or password", "OK");
            }
            } catch (Exception ex) { await DisplayAlert("Login result", "Incorrect Username or password", "OK"); }
        }

        private async void btnReg_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserRegistration());
        }
    }
}