using System;
using multyPage_XamarinAssign.Config;
using multyPage_XamarinAssign.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Views.Authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserList : ContentPage
    {
        DBPetClinic db = new DBPetClinic();
        public UserList()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            userCollectionView.ItemsSource = await db.GetUserAsync();
        }

        private async void Button_Edit_OnClicked(object sender, EventArgs e)
        {
            if (!(sender is Button button)) return;
            var id = button.ClassId;
            var user = await db.GetUserById(id);
            await Navigation.PushAsync(new UserEdit(user));
        }

        private async void Button_Delete_OnClicked(object sender, EventArgs e)
        {
            if (!(sender is Button button)) return;
            var id = button.ClassId;
            var user = await db.GetUserById(id);
            if (user.Username == "admin")
            {
                await DisplayAlert("Error", "You can't delete admin user", "OK");
            }
            else
            {
                var answer = await DisplayAlert("Delete", "Are you sure you want to delete this user?", "Yes", "No");
                if (!answer) return;
                await db.DeleteUserAsync(id);
                await DisplayAlert("Success", "User deleted successfully", "OK");
                await Navigation.PushAsync(new UserList());
            }
        }
    }
}