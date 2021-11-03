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
    public partial class VetList : ContentPage
    {
        public VetList()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {

            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetVetsAsync();
        }
    }
}