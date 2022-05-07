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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void loginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(username.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(password.Text);

            if (isEmailEmpty || isPasswordEmpty)
            {
                //Display message to have users fill out fields
                Console.WriteLine("Empty field");

            }
            else //Navigate to Home Page
            {
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}