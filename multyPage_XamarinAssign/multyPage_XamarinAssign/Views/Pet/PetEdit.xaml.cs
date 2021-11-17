using System;
using multyPage_XamarinAssign.Config;
using multyPage_XamarinAssign.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Views.Pet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetEdit : ContentPage
    {
        DBPetClinic db = new DBPetClinic();

        private Models.Pet _pet;
        private readonly int petId;

        public PetEdit(int PetId)
        {
            InitializeComponent();
            petId = PetId;
        }

        protected override async void OnAppearing()
        {
            _pet = await db.GetPetById(petId);
            TxtRegPetName.Text = _pet.PetName;
            TxtRegPetType.Text = _pet.PetType;
        }

        private async void btnPetRegister_Clicked(object sender, EventArgs e)
        {
            string message = null;
            if (_pet.IsValid(out message))
            {
                _pet.PetName = TxtRegPetName.Text;
                _pet.PetType = TxtRegPetType.Text;
                await db.UpdatePetAsync(_pet);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Empty Fields", message, "Ok");
            }
        }
    }
}