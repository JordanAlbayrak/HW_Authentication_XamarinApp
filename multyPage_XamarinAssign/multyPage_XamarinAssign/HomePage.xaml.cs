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

        public HomePage()
        {
            InitializeComponent();

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

       async private void btnPetList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PetList());
        }

        async private void btnLogout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
