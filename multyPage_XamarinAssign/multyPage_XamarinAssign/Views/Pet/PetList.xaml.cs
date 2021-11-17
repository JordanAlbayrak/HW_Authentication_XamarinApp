using multyPage_XamarinAssign.Config;
using multyPage_XamarinAssign.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Views.Pet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetList : ContentPage
    {
        DBPetClinic db = new DBPetClinic();
        public PetList()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await db.GetPetsAsync();
        }
    }
}