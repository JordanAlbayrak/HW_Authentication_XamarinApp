using System;
using multyPage_XamarinAssign.Config;
using multyPage_XamarinAssign.Models.Enums;
using multyPage_XamarinAssign.Views.Authentication;
using multyPage_XamarinAssign.Views.Owner;
using multyPage_XamarinAssign.Views.Pet;
using multyPage_XamarinAssign.Views.Vet;
using Xamarin.Forms;

namespace multyPage_XamarinAssign.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            switch (App.User.Role)
            {
                case RoleType.Viewer:
                    BtnVetList.IsEnabled = false;
                    BtnVet.IsEnabled = false;
                    AdminPanel.IsEnabled = false;
                    break;
                case RoleType.Internal:
                    AdminPanel.IsEnabled = false;
                    break;
                case RoleType.Admin:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private async void btnVet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VetRegistration());
        }

        private async void btnPet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PetRegistration());
        }

        private async void btnVetList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VetList());
        }

        private async void BtnPetList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PetList());
        }

        private async void UserList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserList());
        }

        private async void BtnOwner_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OwnerPage());
        }

        private async void BtnLogout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}