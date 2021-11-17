using System;
using multyPage_XamarinAssign.Config;
using multyPage_XamarinAssign.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Views.Authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        DBPetClinic db = new DBPetClinic();
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
                var user = await db.GetUserByUsernamePassword(username, password);

                if (user.Username.Equals(username) && user.Password.Equals(password))
                {
                    await DisplayAlert("Login result", "Success", "OK");
                    App.User = user;
                    App.Owner = await db.GetOwnerById(user.UserId);
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