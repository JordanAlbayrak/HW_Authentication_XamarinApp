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
        private DBPetClinic db = new DBPetClinic();

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

        private async void EditTap_Tapped(object sender, EventArgs e)
        {
            //DisplayAlert("Edit", "Wanna edit", "OK");
            string sID = ((TappedEventArgs) e).Parameter.ToString();
            var vet = await db.GetVetById(sID);
            if (vet == null)
            {
                await DisplayAlert("Warning", "Vet not found", "OK");
            }
            else
            {
                vet.VetId = sID;
                await Navigation.PushModalAsync(new VetEdit(vet));
                OnAppearing();
            }
        }

        private async void DeleteTap_Tapped(object sender, EventArgs e)
        {

            var response = await DisplayAlert("Delete", "Wanna delete", "Yes", "No");
            string sID = ((TappedEventArgs) e).Parameter.ToString();

            if (response)
            {
                bool isDelete = await db.DeleteVetAsync(sID);
                if (isDelete)
                {
                    await DisplayAlert("Info", "Vet is deleted", "OK");
                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("Warning", "Deletion failed", "OK");
                }
            }
        }
    }
}