using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Registration
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class petRegistration : ContentPage
    {
        async public void btnRegister_Clicked(object sender, EventArgs e)
        {
            var ErrorMessage = Pet.Pet.IsValid();
            string petName = txtPetName.Text;
            string petType = txtPetType.Text;

            if (!string.IsNullOrWhiteSpace(petName) &&
                !string.IsNullOrWhiteSpace(petType))
            {

                bool choice = await DisplayAlert("Create Account", "Are you sure you want to create an account with this username: " + Pet.Pet.petName, "Yes", "No");
                if (choice == false)
                {
                    Pet.Pet.petName = null;
                    pet.petType = null;
    
                    txtPetName.Text = "";
                    txtPetType.Text = "";

                else
                {
                    await App.PetDatabase.SavePetAsync(new Pet.Pet
                    {
                        PetName = txtPetName
                    });
                    await Navigation.PushAsync(new LoginPage());
                    isAdded = true;
                }

            }
            else { await DisplayAlert("Empty Fields", "Please fill all fields.", "Ok"); }

        }
    }
}