using System;
using multyPage_XamarinAssign.Config;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Views.Authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var username = TxtUserName.Text;
            var password = TxtPassword.Text;
            try
            {
                var user = await App.Database.GetUserByUsernamePassword(username, password);

                if (user.Username.Equals(username) && user.Password.Equals(password))
                {
                    await DisplayAlert("Login result", "Success", "OK");
                    App.User = user;
                    App.Owner = await App.Database.GetOwnerById(Convert.ToInt32(user.UserId));
                    Console.WriteLine("Name: " + App.Owner.OwnerFirstName);
                    await Navigation.PushAsync(new HomePage());
                }
                else
                {
                    await DisplayAlert("Login result", "Incorrect Username or password", "OK");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Login result", "Incorrect Username or password", "OK");
            }
        }

        private async void BtnReg_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registration());
        }
    }
}