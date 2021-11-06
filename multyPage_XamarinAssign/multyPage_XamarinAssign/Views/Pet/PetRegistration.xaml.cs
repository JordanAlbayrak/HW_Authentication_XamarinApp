using System;
using System.ComponentModel;
using multyPage_XamarinAssign.Config;
using multyPage_XamarinAssign.Views.Owner;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Views.Pet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetRegistration : ContentPage, INotifyPropertyChanged
    {
        private Models.Pet _pet;

        public PetRegistration()
        {
            _pet = new Models.Pet();
            InitializeComponent();
            BindingContext = this;
        }

        public Models.Pet Pet
        {
            get => _pet;
            set
            {
                _pet = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Pet)));
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        private async void btnPetRegister_Clicked(object sender, EventArgs e)
        {
            if (_pet.IsValid(out var message))
            {
                Console.WriteLine(_pet.PetName);
                await App.Database.SavePetAsync(_pet);
                var owner = App.Owner;
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