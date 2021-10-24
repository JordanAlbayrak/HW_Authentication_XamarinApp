using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign
{
    public partial class App : Application
    {
        static userDB database;
        public static userDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new userDB
                        (Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "user.db3"));
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
