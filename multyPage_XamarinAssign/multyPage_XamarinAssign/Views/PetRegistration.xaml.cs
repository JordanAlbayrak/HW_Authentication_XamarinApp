using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetRegistration : ContentPage, INotifyPropertyChanged
    {

        public new event PropertyChangedEventHandler PropertyChanged;

        private Pet _pet;

        public Pet Pet
        {
            get => _pet;
            set
            {
                _pet = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Pet)));
            }
        }
        //bool isAdded = false;
       //public Pet pet { get; set; }
        public PetRegistration()
        {
            _pet = new Pet();
            InitializeComponent();
            BindingContext = this;
        }

        async public void btnPetRegister_Clicked(object sender, EventArgs e)
        {

            string message = null;
            if (_pet.IsValid(out message))
            {
                Console.WriteLine(_pet.PetName);
                await App.Database.SavePetAsync(_pet);
                await Navigation.PopAsync();
            }
            else
            {

                await DisplayAlert("Empty Fields", message, "Ok");
            }

            //var ErrorMessage = pet.IsValid();
            //string PetName = txtRegPetName.Text;
            //string PetType = txtRegPetType.Text;

            //if (!string.IsNullOrWhiteSpace(PetName) &&
            //    !string.IsNullOrWhiteSpace(PetType))
            //{

            //    bool choice = await DisplayAlert("Resgiter Pet", "Are you sure you want to register a pet called: " + PetName, "Yes", "No");
            //    if (choice == false)
            //    {
            //        pet.PetName = null;
            //        pet.PetType = null;
            //        txtRegPetName.Text = "";
            //        txtRegPetType.Text = "";
            //    }
            //    else
            //    {
            //        await App.Database.SavePetAsync(new Pet
            //        {
            //            PetName = txtRegPetName.Text,
            //            PetType = txtRegPetType.Text,
            //        });
            //        await Navigation.PushAsync(new HomePage());
            //        isAdded = true;
            //    }

            //}
            //else { await DisplayAlert("Empty Fields", "Please fill all fields.", "Ok"); }

        }

    }
}