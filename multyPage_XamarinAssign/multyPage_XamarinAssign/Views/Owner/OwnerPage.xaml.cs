using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using multyPage_XamarinAssign.Config;
using multyPage_XamarinAssign.Views.Pet;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Views.Owner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OwnerPage : ContentPage
    {
        private Models.Pet _pet1;
        private Models.Pet _pet2;

        public OwnerPage()
        {
            InitializeComponent();
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (App.Owner.PetId1 != 0)
            {
                _pet1 = await App.Database.GetPetById(App.Owner.PetId1);
                PetName1.Text = _pet1.PetName;
                PetType1.Text = _pet1.PetType;
            }
            if (App.Owner.PetId2 != 0)
            {
                _pet2 = await App.Database.GetPetById(App.Owner.PetId2);
                PetName2.Text = _pet2.PetName;
                PetType2.Text = _pet2.PetType;
            }
            
            OwnerFirstName.Text = App.Owner.OwnerFirstName;
            OwnerLastName.Text = App.Owner.OwnerLastName;
            OwnerPhoneNumber.Text = App.Owner.OwnerPhoneNumber;

        }
    
    private async void Button_OnClicked(object sender, EventArgs e)
        {
            if ((App.Owner.PetId1 == 0) || (App.Owner.PetId2 == 0))
            {
                await Navigation.PushAsync(new PetRegistration());
            }
            else
            {
                await DisplayAlert("Too many pets", "You have to many pets associated with the account", "Ok");
            }
           
        }
    }
}