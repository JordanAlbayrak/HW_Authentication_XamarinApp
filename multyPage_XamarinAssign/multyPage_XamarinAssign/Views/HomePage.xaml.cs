using multyPage_XamarinAssign.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace multyPage_XamarinAssign
{
    public partial class HomePage : ContentPage
    {
        private readonly User user;

        public HomePage(User user)
        {
            InitializeComponent();
            this.user = user;

            if (user.Role == RoleType.Viewer)
            {
                btnVetList.IsEnabled = false;
                btnVet.IsEnabled = false;
                UserList.IsEnabled = false;
            }
            else if (user.Role == RoleType.Intern)
            {
                UserList.IsEnabled = false;           
            }
        }

        async private void btnVet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VetRegistration());
        }

        async private void btnPet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PetRegistration());
        }

       async private void btnVetList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VetList());
        }

       async private void BtnPetList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PetList());
        }

        private async void UserList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserPage(user));
        }

        async private void BtnLogout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
