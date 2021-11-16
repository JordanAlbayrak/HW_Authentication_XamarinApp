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
    public partial class VetPage : ContentPage
    {
        public VetPage()
        {
            InitializeComponent();
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetVetsAsync();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VetRegistration());
        }

        private async void Button_Edit_OnClicked(object sender, EventArgs e)
        {
            if (!(sender is Button button)) return;
            var id = int.Parse(button.ClassId);
            var vet = await App.Database.GetVetById(id);
            await Navigation.PushAsync(new VetEdit(vet));
        }

        private async void Button_Delete_OnClicked(object sender, EventArgs e)
        {
            if (!(sender is Button button)) return;
            var id = int.Parse(button.ClassId);
            var answer = await DisplayAlert("Delete", "Are you sure you want to delete this vet?", "Yes", "No");
            if (!answer) return;
            await App.Database.DeleteVetAsync(id);
            await DisplayAlert("Success", "Vet deleted successfully", "OK");
            await Navigation.PushAsync(new VetPage());
            
        }
    }
}