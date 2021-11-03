using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using multyPage_XamarinAssign.Config;
using multyPage_XamarinAssign.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Views.Owner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OwnerEdit : ContentPage
    {
        private Models.Owner owner;
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
            User user = new User();
            if (App.Owner.IsValid(out message))
            {
                owner.OwnerFirstName = TxtOwnerFirstName.Text;
                owner.OwnerLastName = TxtOwnerLastName.Text;
                owner.OwnerPhoneNumber = TxtOwnerPhone.Text;
                await App.Database.UpdateOwnerAsync(owner);
                user = await App.Database.GetUserById(owner.OwnerId);
                user.FirstName = owner.OwnerFirstName;
                user.LastName = owner.OwnerLastName;
                user.Phone = owner.OwnerPhoneNumber;
                await App.Database.UpdateUserAsync(user);
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