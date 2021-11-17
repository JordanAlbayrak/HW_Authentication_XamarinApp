using System;
using multyPage_XamarinAssign.Config;
using multyPage_XamarinAssign.Database;
using multyPage_XamarinAssign.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Views.Owner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OwnerEdit : ContentPage
    {
        DBPetClinic db = new DBPetClinic();

        private readonly Models.Owner owner;

        public OwnerEdit()
        {
            InitializeComponent();
            owner = App.Owner;
            TxtOwnerFirstName.Text = owner.OwnerFirstName;
            TxtOwnerLastName.Text = owner.OwnerLastName;
            TxtOwnerPhone.Text = owner.OwnerPhoneNumber;
        }

        private async void btnOwnerRegistration_Clicked(object sender, EventArgs e)
        {
            string message = null;
            var user = new User();
            if (App.Owner.IsValid(out message))
            {
                owner.OwnerFirstName = TxtOwnerFirstName.Text;
                owner.OwnerLastName = TxtOwnerLastName.Text;
                owner.OwnerPhoneNumber = TxtOwnerPhone.Text;
                await db.UpdateOwnerAsync(owner);
                user = await db.GetUserById(owner.OwnerId);
                user.FirstName = owner.OwnerFirstName;
                user.LastName = owner.OwnerLastName;
                user.Phone = owner.OwnerPhoneNumber;
                await db.UpdateUserAsync(user);
                App.Owner = owner;
                App.User = user;
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Empty Fields", message, "Ok");
            }
        }
    }
}