using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAttendance.Helpers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TakeAttendance
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
           
        }

        private async void loginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(username.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(password.Text);

            if (isEmailEmpty || isPasswordEmpty)
            {
                //Display message to have users fill out fields
                Console.WriteLine("Empty field");

            }
            else 
            {
                //Authenticate
                bool result = await Auth.LoginUser(username.Text, password.Text);

                //Navigate to Home Page
                if (result)
                   await Navigation.PushAsync(new HomePage());
            }
        }

        private void registrationButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationPassword());
        }
    }
}