using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using multyPage_XamarinAssign.Config;
using multyPage_XamarinAssign.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Views.Vet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VetPage : ContentPage
    {
        DBPetClinic db = new DBPetClinic();

        public VetPage()
        {
            InitializeComponent();
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await db.GetVetsAsync();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VetRegistration());
        }

        private async void Button_Edit_OnClicked(object sender, EventArgs e)
        {
            if (!(sender is Button button)) return;
            var id = button.ClassId;
            var vet = await db.GetVetById(id);
            await Navigation.PushAsync(new VetEdit(vet));
        }

        private async void Button_Delete_OnClicked(object sender, EventArgs e)
        {
            if (!(sender is Button button)) return;
            var id = button.ClassId;
            var answer = await DisplayAlert("Delete", "Are you sure you want to delete this vet?", "Yes", "No");
            if (!answer) return;
            await db.DeleteVetAsync(id);
            await DisplayAlert("Success", "Vet deleted successfully", "OK");
            await Navigation.PushAsync(new VetPage());
            
        }
    }
}