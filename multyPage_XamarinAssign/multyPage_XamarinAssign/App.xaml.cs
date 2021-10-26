using multyPage_XamarinAssign.Pet;
using multyPage_XamarinAssign.Vet;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multyPage_XamarinAssign
{
    public partial class App : Application
    {
        static userDB userDB;
        static VetDB vetDB;
        static PetDB petDB;
        public static userDB Database
        {
            get
            {
                if (userDB == null)
                {
                    userDB = new userDB
                        (Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "user.db3"));
                }
                return userDB;
            }
        }
        public static VetDB VetDatabase
        {
            get
            {
                if (vetDB == null)
                {
                    vetDB = new VetDB
                        (Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "vet.db3"));
                }
                return vetDB;
            }
        }
        public static PetDB PetDatabase
        {
            get
            {
                if (petDB == null)
                {
                    petDB = new PetDB
                        (Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "pet.db3"));
                }
                return petDB;
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
