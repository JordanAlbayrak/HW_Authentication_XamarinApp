using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using multyPage_XamarinAssign.Config;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Views.Vet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VetEdit : ContentPage
    {
        Models.Vet _vet;
        public VetEdit(Models.Vet vet)
        {
            InitializeComponent();
            _vet = vet;
            txtVetRegFirst.Text = vet.FirstName;
            txtVetRegLast.Text = vet.LastName;
            txtVetRegPhone.Text = vet.Phone;
            txtVetRegEmail.Text = vet.Email;
            txtVetRegSpecial.Text = vet.Special;
        }

        private void BtnUpdateVet_OnClicked(object sender, EventArgs e)
        {
            _vet.FirstName = txtVetRegFirst.Text;
            _vet.LastName = txtVetRegLast.Text;
            _vet.Phone = txtVetRegPhone.Text;
            _vet.Email = txtVetRegEmail.Text;
            _vet.Special = txtVetRegSpecial.Text;
            App.Database.UpdateVetAsync(_vet);
            Navigation.PopAsync();

        }
    }
}