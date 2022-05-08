using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TakeAttendance
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPassword : ContentPage
    {
        public RegistrationPassword()
        {
            InitializeComponent();
        }

        private void registrationPassword_Completed(object sender, EventArgs e)
        {
            if(registrationPassword.Text == "jdiscool")
            {
                Navigation.PushAsync(new RegisterPage());
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Incorrect Password", "Please try again", "Got it");
                registrationPassword.Text = "";
            }
        }
        
        private void goBackToLoginButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}