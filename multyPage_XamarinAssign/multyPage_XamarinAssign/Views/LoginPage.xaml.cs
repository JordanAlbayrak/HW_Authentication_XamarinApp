using multyPage_XamarinAssign;
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
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            try
            {
                User u = await App.Database.GetItemAsync(username, password);
     

                Console.WriteLine("UserDatabase = " + u.Username);
                Console.WriteLine("PasswordDatabase = " + u.Password);


                if (u.Username.Equals(username) && u.Password.Equals(password))
                {
                    await DisplayAlert("Login result", "Success", "OK");
                    await Navigation.PushAsync(new HomePage(u));
                }
                else
                {
                    await DisplayAlert("Login result", "Incorrect Username or password", "OK");
                }
            }
            catch (Exception ex) { await DisplayAlert("Login result", "Incorrect Username or password", "OK"); }
        }

        private async void btnReg_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registration());
        }

   
    }
}