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
    public partial class Registration : ContentPage
    {
        bool isAdded = false;

        public User user { get; set; }
        public Registration()
        {
            user = new User();
            InitializeComponent();
            BindingContext = this;
        }

        async public void btnRegister_Clicked(object sender, EventArgs e)
        {
            var errorMessage = user.IsValid();
            string userName = txtRegUserName.Text;
            string email = txtRegEmail.Text;
            string PassWord = txtRegPassword.Text;

            if (!string.IsNullOrWhiteSpace(txtRegUserName.Text) &&
                !string.IsNullOrWhiteSpace(txtRegPassword.Text) &&
                !string.IsNullOrWhiteSpace(txtRegEmail.Text))
            {

                bool choice = await DisplayAlert("Create Account", "Are you sure you want to create an account with this username: " + user.username, "Yes", "No");
                if (choice == false)
                {
                    user.username = null;
                    user.email = null;
                    user.password = null;
                    txtRegUserName.Text = "";
                    txtRegPassword.Text = "";
                    txtRegEmail.Text = "";
                }
                else
                {
                    await App.Database.SavePersonAsync(new User
                    {
                        username = txtRegUserName.Text,
                        email = txtRegEmail.Text,
                        password = txtRegPassword.Text,
                    });
                    await Navigation.PushAsync(new LoginPage());
                    isAdded = true;
                }

            }
            else { await DisplayAlert("Empty Fields", "Please fill all fields.", "Ok"); }
          
        }
    }
}