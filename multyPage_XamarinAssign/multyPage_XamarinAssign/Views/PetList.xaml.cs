using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetList : ContentPage
    {
        public PetList()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {

            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetPetsAsync();
        }
    }
}