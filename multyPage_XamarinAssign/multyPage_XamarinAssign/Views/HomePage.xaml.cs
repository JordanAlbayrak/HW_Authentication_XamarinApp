using multyPage_XamarinAssign.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            if (App.User.Role == RoleType.Viewer)
            {
                btnVetList.IsEnabled = false;
                btnVet.IsEnabled = false;
                UserList.IsEnabled = false;
            }
            else if (App.User.Role == RoleType.Internal)
            {
                UserList.IsEnabled = false;           
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
