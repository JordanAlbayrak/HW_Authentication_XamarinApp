using System;
using multyPage_XamarinAssign.Config;
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
            userCollectionView.ItemsSource = await App.Database.GetUserAsync();
        }

        private async void Button_Edit_OnClicked(object sender, EventArgs e)
        {
            if (!(sender is Button button)) return;
            var id = int.Parse(button.ClassId);
            var user = await App.Database.GetUserById(id);
            await Navigation.PushAsync(new UserEdit(user));
        }

        private async void Button_Delete_OnClicked(object sender, EventArgs e)
        {
            if (!(sender is Button button)) return;
            var id = int.Parse(button.ClassId);
            var user = await App.Database.GetUserById(id);
            if (user.Username == "admin")
            {
                await DisplayAlert("Error", "You can't delete admin user", "OK");
            }
            else
            {
                var answer = await DisplayAlert("Delete", "Are you sure you want to delete this user?", "Yes", "No");
                if (!answer) return;
                await App.Database.DeleteUserAsync(id);
                await DisplayAlert("Success", "User deleted successfully", "OK");
                await Navigation.PushAsync(new UserList());
            }
        }
    }
}