using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign
{
    public partial class App : Application
    {
        static DBPetClinic database;
        public static DBPetClinic Database
        {
            get
            {
                if (database == null)
                {
                    database = new DBPetClinic
                        (Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "databaseV1.2.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            //MainPage = new MainPage();
            MainPage = new NavigationPage((new LoginPage()));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
