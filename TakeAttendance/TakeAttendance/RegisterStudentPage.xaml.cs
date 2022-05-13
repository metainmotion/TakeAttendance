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
            try
            {
                var student = new Student()
                {
                    Username = $"{(firstname.Text.Length >= 2 ? firstname.Text.Substring(0, 2) : firstname.Text)}{(lastname.Text.Length >= 5 ? lastname.Text.Substring(0, 5) : lastname.Text)}{(phone.Text.Length > 0 ? phone.Text.Substring(3, 7) : phone.Text)}",
                    FirstName = firstname.Text,
                    LastName = lastname.Text,
                    Phone = phone.Text.Length > 0 ? phone.Text : "",
                    BirthDate = birthdate.Date.ToShortDateString(),
                    Parentg1 = parentg1.Text,
                    Parentg2 = parentg2.Text,
                    AltPhone = phone.Text.Length > 0 ? phone.Text : null,
                    Email = email.Text,
                    Nganh = nganh.SelectedItem.ToString(),
                    ChiDoan = (int)chidoan.SelectedItem,
                    Medical = medical.Text,
                    PaidStat = paidstat.SelectedItem.ToString(),
                    Comments = comments.Text
                };

                bool result = FirestoreHelper.RegisterStudent(student);

                if (result)
                {
                    DisplayAlert("Success", "Student has been registered", "Ok");
                    firstname.Text = "";
                    lastname.Text = "";
                    phone.Text = "";
                    parentg1.Text = "";
                    parentg2.Text = "";
                    altphone.Text = "";
                    email.Text = "";
                    nganh.SelectedIndex = 0;
                    chidoan.SelectedIndex = 0;
                    medical.Text = "";
                    paidstat.SelectedIndex = 0;
                    comments.Text = "";
                }
                else
                {
                    DisplayAlert("Failed", "Student has not been registered", "Ok");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Do not leave fields blank", "Ok");
            }

        }

        private void toolbarHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }
    }
}