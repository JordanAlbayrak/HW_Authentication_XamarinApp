using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace multyPage_XamarinAssign
{
    public partial class HomePage : ContentPage
    {

        public HomePage()
        {
            InitializeComponent();


            OnAppearing();
         }
        protected override async void OnAppearing()
        {

            base.OnAppearing();
            //collectionView.ItemsSource = await App.Database.GetPeopleAsync();
        }

    }
}
