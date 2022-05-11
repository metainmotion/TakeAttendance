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
    public partial class StudentDirectoryPage : ContentPage
    {
        public StudentDirectoryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var students = await FirestoreHelper.Read();
            listOfStudents.ItemsSource = students;
        }
    }
}