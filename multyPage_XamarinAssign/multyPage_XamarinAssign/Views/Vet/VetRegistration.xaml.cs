using System;
using System.ComponentModel;
using multyPage_XamarinAssign.Config;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Views.Vet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VetRegistration : ContentPage, INotifyPropertyChanged
    {
        private Models.Vet _vet;

        //bool isAdded = false;
        //public Vet vet { get; set; }
        public VetRegistration()
        {
            _vet = new Models.Vet();
            InitializeComponent();
            BindingContext = this;
        }

        public Models.Vet Vet
        {
            get => _vet;
            set
            {
                _vet = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Vet)));
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        public async void btnVetRegister_Clicked(object sender, EventArgs e)
        {
            string message = null;
            if (_vet.IsValid(out message))
            {
                Console.WriteLine(_vet.FirstName);
                await App.Database.SaveVetAsync(_vet);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Empty Fields", message, "Ok");
            }

            //var ErrorMessage = vet.IsValid();
            //string FirstName = txtVetRegFirst.Text;
            //string LastName = txtVetRegLast.Text;
            //string Email = txtVetRegEmail.Text;
            //string Phone = txtVetRegPhone.Text;
            //string Special = txtVetRegSpecial.Text;

            //if (!string.IsNullOrWhiteSpace(FirstName) &&
            //    !string.IsNullOrWhiteSpace(LastName) &&
            //    !string.IsNullOrWhiteSpace(Email) &&
            //    !string.IsNullOrWhiteSpace(Phone) &&
            //    !string.IsNullOrWhiteSpace(Special))
            //{

            //    bool choice = await DisplayAlert("Add Vet", "Are you sure you want to add a vet called: " + FirstName, "Yes", "No");
            //    if (choice == false)
            //    {
            //        vet.FirstName = null;
            //        vet.LastName = null;
            //        vet.Email = null;
            //        vet.Phone = null;
            //        vet.Special = null;

            //        txtVetRegFirst.Text = "";
            //        txtVetRegLast.Text = "";
            //        txtVetRegEmail.Text = "";
            //        txtVetRegPhone.Text = "";
            //        txtVetRegSpecial.Text = "";
            //    }
            //    else
            //    {
            //        await App.Database.SaveVetAsync(new Vet
            //        {
            //        FirstName = txtVetRegFirst.Text,
            //        LastName = txtVetRegLast.Text,
            //        Email = txtVetRegEmail.Text,
            //        Phone = txtVetRegPhone.Text,
            //        Special = txtVetRegSpecial.Text,
            //    });
            //        await Navigation.PushAsync(new HomePage());
            //        isAdded = true;
            //    }

            //}
            //else { await DisplayAlert("Empty Fields", "Please fill all fields.", "Ok"); }
        }
    }
}