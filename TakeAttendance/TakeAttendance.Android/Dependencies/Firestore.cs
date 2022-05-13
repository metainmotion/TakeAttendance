using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAttendance.Helpers;
using Xamarin.Forms;
using Java.Interop;

[assembly: Dependency(typeof(TakeAttendance.Droid.Dependencies.Firestore))]
namespace TakeAttendance.Droid.Dependencies
{
    public class Firestore : Java.Lang.Object, IFirestore, IOnCompleteListener 
    {
        List<Student> students;
        bool hasReadStudents = false;

        public Firestore()
        {
            students = new List<Student>();
        }

        public async Task<bool> Delete(Student student)
        {
            var deletePrompt = await App.Current.MainPage.DisplayAlert("Delete Student", "Are you sure?", "Yes", "Cancel");

            if (deletePrompt)
            { 
                try
                {
                    var collection = FirebaseFirestore.Instance.Collection("students");

                    collection.Document(student.Id).Delete();
                
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            { 
                return false;
            }
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                var documents = (QuerySnapshot) task.Result;

                students.Clear();

                foreach (var doc in documents.Documents)
                {
                    Student student = new Student()
                    {
                        Username = doc.Get("username").ToString(),
                        Phone = doc.Get("phone").ToString(),
                        FirstName = doc.Get("firstname").ToString(),
                        LastName = doc.Get("lastname").ToString(),
                        Created = doc.Get("created").ToString(),
                        BirthDate = doc.Get("birthdate").ToString(),
                        Parentg1 = doc.Get("parentg1").ToString(),
                        Parentg2 = doc.Get("parentg2").ToString(),
                        AltPhone = doc.Get("altphone").ToString(),
                        Email = doc.Get("email").ToString(),
                        Nganh = doc.Get("nganh").ToString(),
                        ChiDoan = (int)doc.Get("chidoan"),
                        Medical = doc.Get("medical").ToString(),
                        PaidStat = doc.Get("paidstat").ToString(),
                        Comments = doc.Get("comments").ToString(),
                        ModifiedBy = doc.Get("modifiedby").ToString(),
                        Id = doc.Id
                    };

                    students.Add(student);
                }
            }
            else
            {
                students.Clear();  
            }

            hasReadStudents = true;
        }

        public async Task<List<Student>> Read()
        {
            hasReadStudents = false;

            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("students");

            //var query = collection.WhereEqualTo("modifiedby", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Email);
            var query = collection.WhereNotEqualTo("username", "");

            query.Get().AddOnCompleteListener(this);

            for(int i = 0; i < 15; i++)
            {
                await System.Threading.Tasks.Task.Delay(100);
                if (hasReadStudents)
                    break;
            }

            return students;
        }

        public bool RegisterStudent(Student student)
        {
            try
            {
                Dictionary<string, Java.Lang.Object> studentdict = new Dictionary<string, Java.Lang.Object>
                {
                    {"username", student.Username },
                    {"phone", student.Phone },
                    {"firstname", student.FirstName },
                    {"lastname", student.LastName },
                    {"created", DateTime.Now.ToShortDateString()},
                    {"birthdate", student.BirthDate },
                    {"parentg1", student.Parentg1 },
                    {"parentg2", student.Parentg2 },
                    {"altphone", student.AltPhone },
                    {"email", student.Email },
                    {"nganh", student.Nganh },
                    {"chidoan", student.ChiDoan },
                    {"medical", student.Medical },
                    {"paidstat", student.PaidStat },
                    {"comments", student.Comments },
                    {"modifiedby", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Email }
                };

                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("students");

                collection.Add(new HashMap(studentdict));

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    
        public async Task<bool> Update(Student student)
        {
            try
            {
                var studentdict = new Dictionary<string, Java.Lang.Object>
                {
                    {"username", student.Username },
                    {"phone", student.Phone },
                    {"firstname", student.FirstName },
                    {"lastname", student.LastName },
                    {"created" , student.Created},
                    {"birthdate", student.BirthDate },
                    {"parentg1", student.Parentg1 },
                    {"parentg2", student.Parentg2 },
                    {"altphone", student.AltPhone },
                    {"email", student.Email },
                    {"nganh", student.Nganh },
                    {"chidoan", student.ChiDoan },
                    {"medical", student.Medical },
                    {"paidstat", student.PaidStat },
                    {"comments", student.Comments },
                    {"modifiedby", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Email }
                };

                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("students");

                collection.Document(student.Id).Update(studentdict);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}