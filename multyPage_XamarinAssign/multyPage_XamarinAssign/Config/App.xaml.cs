using System;
using System.IO;
using multyPage_XamarinAssign.Database;
using multyPage_XamarinAssign.Models;
using multyPage_XamarinAssign.Views.Authentication;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign.Config
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
                        (Environment.SpecialFolder.LocalApplicationData), "databaseV1.3.1.db3"));
                }
                return database;
            }
        }

        public static User User { get; set; }
        public static Owner Owner { get; set; }
        
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
