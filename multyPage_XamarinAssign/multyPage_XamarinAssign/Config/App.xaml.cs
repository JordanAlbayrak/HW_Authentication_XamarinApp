using System;
using System.IO;
using multyPage_XamarinAssign.Database;
using multyPage_XamarinAssign.Models;
using multyPage_XamarinAssign.Views.Authentication;
using Xamarin.Forms;

namespace multyPage_XamarinAssign.Config
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            //MainPage = new MainPage();
            MainPage = new NavigationPage(new LoginPage());
        }

        //public static DBPetClinic Database
        //{
        //    get
        //    {
        //        if (database == null)
        //            database = new DBPetClinic
        //            (Path.Combine(Environment.GetFolderPath
        //                (Environment.SpecialFolder.LocalApplicationData), "databaseV1.3.2.db3"));
        //        return database;
        //    }
        //}

        public static User User { get; set; }
        public static Owner Owner { get; set; }

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