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
                    BtnVetPage.IsEnabled = false;
                    AdminPanel.IsEnabled = false;
                    BtnOwner.IsEnabled = false;
                    break;
                case RoleType.Internal:
                    AdminPanel.IsEnabled = false;
                    BtnPetList.IsEnabled = false;
                    BtnOwner.IsEnabled = false;
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

        private async void BtnVetPage_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VetPage());
        }
    }
}