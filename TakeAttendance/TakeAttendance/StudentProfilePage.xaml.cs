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

            StudentProfileHeader.Text = $"{student.FirstName} {student.LastName}'s Profile";
            firstname.Text = student.FirstName;
            lastname.Text = student.LastName;
            birthdate.Date = DateTime.Parse(student.BirthDate);
            nganh.SelectedItem = student.Nganh;
            chidoan.SelectedItem = student.ChiDoan;
            comments.Text = student.Comments;
            parentg1.Text = student.Parentg1;
            phone.Text = student.Phone;
            parentg2.Text = student.Parentg2;
            altphone.Text = student.AltPhone;
            email.Text = student.Email;
            medical.Text = student.Medical; 
            paidstat.SelectedItem = student.PaidStat;


        }

        private async void updateButton_Clicked(object sender, EventArgs e)
        {
            bool updateConfirm = await App.Current.MainPage.DisplayAlert("Confirm Update", "Are you sure you want to save the changes?", "Update", "Cancel");

            if (updateConfirm)
            {

                student.Username = $"{(firstname.Text.Length >= 2 ? firstname.Text.Substring(0, 2) : firstname.Text)}{(lastname.Text.Length >= 5 ? lastname.Text.Substring(0, 5) : lastname.Text)}{(phone.Text.Length > 0 ? phone.Text.Substring(3, 7) : phone.Text)}";
                student.FirstName = firstname.Text;
                student.LastName = lastname.Text;
                student.BirthDate = birthdate.Date.ToShortDateString();
                student.Nganh = nganh.SelectedItem.ToString();
                student.ChiDoan = (int)chidoan.SelectedItem;
                student.Comments = comments.Text;
                student.Parentg1 = parentg1.Text;
                student.Phone = phone.Text;
                student.Parentg2 = parentg2.Text;
                student.AltPhone = altphone.Text;
                student.Email = email.Text;
                student.Medical = medical.Text;
                student.PaidStat = paidstat.SelectedItem.ToString();

                Task<bool> result = FirestoreHelper.Update(student);

                if(result.Result)
                {
                    await DisplayAlert("Success", "Profile has been updated", "Ok");
                }
                else
                {
                    await DisplayAlert("Error", "Failed to update profile", "Ok");
                }
            }

        }

        private async void deleteButton_Clicked(object sender, EventArgs e)
        {
            bool result = await FirestoreHelper.Delete(student);

            if (result)
                await DisplayAlert("Student Deleted", "You will be navigated back to home page now", "OK");
                await Navigation.PushAsync(new HomePage());
        }

        private void toolbarHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }

    }
}