using multyPage_XamarinAssign.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using multyPage_XamarinAssign.Config;
using multyPage_XamarinAssign.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Views.Authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserList : ContentPage
    {
        public UserList()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (!(App.User.IsDelete))
            {
                btnDelete.IsEnabled = false;
            }
            userCollectionView.ItemsSource = await App.Database.GetUserAsync();
        }


        private async void Button_Clicked_Get(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("What is the ID", "What's your name?");

            if (result != null)
            {
                await Navigation.PushAsync(new PermissionPage(Convert.ToInt32(result)));
            }
        }

        private async void Button_Clicked_Delete(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("What is the ID", "What's your name?");
            var user = await App.Database.GetUserById(Convert.ToInt32(result));   
            await App.Database.DeleteUserAsync(user);
            userCollectionView.ItemsSource = await App.Database.GetUserAsync();
        }
    }
}