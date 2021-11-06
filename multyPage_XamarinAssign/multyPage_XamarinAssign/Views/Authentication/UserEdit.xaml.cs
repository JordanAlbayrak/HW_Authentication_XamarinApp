using System;
using multyPage_XamarinAssign.Config;
using multyPage_XamarinAssign.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Views.Authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserEdit : ContentPage
    {
        public UserEdit(User user)
        {
            InitializeComponent();
            User = user;
            TxtUsername.Text = User.Username;
            TxtRegPassword.Text = User.Password;
            TxtRegEmail.Text = User.Email;
            TxtRegPhone.Text = User.Phone;
            TxtRegFirst.Text = User.FirstName;
            TxtRegLast.Text = User.LastName;
            chkDelete.IsChecked = User.IsDelete;
            chkModify.IsChecked = User.IsWrite;
            chkRead.IsChecked = User.IsRead;

            if (user.Username != "admin") return;
            TxtUsername.IsEnabled = false;
            chkDelete.IsEnabled = false;
            chkDelete.IsVisible = false;
            chkModify.IsEnabled = false;
            chkModify.IsVisible = false;
            chkModify.IsEnabled = false;
            chkRead.IsEnabled = false;
        }

        private User User { get; }

        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
            User.Username = TxtUsername.Text;
            User.Password = TxtRegPassword.Text;
            User.Email = TxtRegEmail.Text;
            User.Phone = TxtRegPhone.Text;
            User.FirstName = TxtRegFirst.Text;
            User.LastName = TxtRegLast.Text;
            User.IsDelete = chkDelete.IsChecked;
            User.IsWrite = chkModify.IsChecked;
            User.IsRead = chkRead.IsChecked;
            await App.Database.UpdateUserAsync(User);
            var owner = await App.Database.GetOwnerById(User.UserId);
            owner.OwnerFirstName = User.FirstName;
            owner.OwnerLastName = User.LastName;
            owner.OwnerPhoneNumber = User.Phone;
            await App.Database.UpdateOwnerAsync(owner);
            await Navigation.PopAsync();
        }
    }
}