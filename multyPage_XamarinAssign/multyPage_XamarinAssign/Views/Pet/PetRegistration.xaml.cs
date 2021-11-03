using System;
using System.ComponentModel;
using System.IO;
using multyPage_XamarinAssign.Models;
using multyPage_XamarinAssign.Config;
using multyPage_XamarinAssign.Views.Owner;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Views.Pet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetRegistration : ContentPage, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;

        private Models.Pet _pet;

        public Models.Pet Pet
        {
            get => _pet;
            set
            {
                _pet = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Pet)));
            }
        }
        public PetRegistration()
        {
            _pet = new Models.Pet();
            InitializeComponent();
            BindingContext = this;
        }

        private async void btnPetRegister_Clicked(object sender, EventArgs e)
        {
            if (_pet.IsValid(out var message))
            {
                Console.WriteLine(_pet.PetName);
                await App.Database.SavePetAsync(_pet);
                Models.Owner owner = App.Owner;
                if (owner.PetId1 == 0)
                {
                    owner.PetId1 = _pet.PetId;
                    await App.Database.UpdateOwnerAsync(owner);
                    App.Owner = owner;
                    await Navigation.PushAsync(new OwnerPage());
                }
                else if (owner.PetId2 == 0)
                {
                    owner.PetId2 = _pet.PetId;
                    await App.Database.UpdateOwnerAsync(owner);
                    App.Owner = owner;
                    await Navigation.PushAsync(new OwnerPage());
                }
                else
                {
                    await DisplayAlert("Too many pets", "You have to many pets associated with the account", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Empty Fields", message, "Ok");
            }
        }
    }
}