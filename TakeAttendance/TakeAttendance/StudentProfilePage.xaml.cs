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
    public partial class StudentProfilePage : ContentPage
    {
        Student student;

        public StudentProfilePage(Student student)
        {
            InitializeComponent();

            this.student = student;
        }

        private void updateButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void deleteButton_Clicked(object sender, EventArgs e)
        {
            bool result = await FirestoreHelper.Delete(student);

            if (result)
                await DisplayAlert("Student Deleted", "You will be navigated back to home page now", "OK");
                await Navigation.PushAsync(new HomePage());
        }
    }
}