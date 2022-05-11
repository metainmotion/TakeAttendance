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
    public partial class RegisterStudentPage : ContentPage
    {
        public RegisterStudentPage()
        {
            InitializeComponent();
        }

        public void registerStudentButton_Clicked(object sender, EventArgs e)
        {
            var student = new Student()
            {
                Id = "fdafdsafdsa",
                UserId = "4543543",
                Username = "Jodangggg",
                FirstName = "johnny",
                LastName = "Dangggg"
            };

            bool result = FirestoreHelper.RegisterStudent(student);

            if(result)
            {
                DisplayAlert("Success", "Student has been registered", "Ok");
            }
            else
            {
                DisplayAlert("Failed", "Student has not been registered", "Ok");
            }
        }
    }
}