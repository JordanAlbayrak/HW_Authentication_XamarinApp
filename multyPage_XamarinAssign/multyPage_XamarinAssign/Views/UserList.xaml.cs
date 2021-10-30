using multyPage_XamarinAssign.Views;
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
    public partial class UserPage : ContentPage
    {
        User user;
        public UserPage(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (!(user.IsDelete))
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
            var user = await App.Database.GetItemAsyncById(Convert.ToInt32(result));   
            await App.Database.DeleteUserAsync(user);
            userCollectionView.ItemsSource = await App.Database.GetUserAsync();
        }
    }
}