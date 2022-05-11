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
    public class Firestore : IFirestore, IOnCompleteListener
    {
        List<Student> students;
        bool hasReadStudents = false;

        public Firestore()
        {
            students = new List<Student>();
        }
        public IntPtr Handle => throw new NotImplementedException();

        public int JniIdentityHashCode => throw new NotImplementedException();

        public JniObjectReference PeerReference => throw new NotImplementedException();

        public JniPeerMembers JniPeerMembers => throw new NotImplementedException();

        public JniManagedPeerStates JniManagedPeerState => throw new NotImplementedException();

        public async Task<bool> Delete(Student student)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("students");

                collection.Document(student.Id).Delete();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Disposed()
        {
            throw new NotImplementedException();
        }

        public void DisposeUnlessReferenced()
        {
            throw new NotImplementedException();
        }

        public void Finalized()
        {
            throw new NotImplementedException();
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
                        UserId = doc.Get("userid").ToString(),
                        FirstName = doc.Get("firstname").ToString(),
                        LastName = doc.Get("lastname").ToString(),
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

            var query = collection.WhereEqualTo("modifiedby", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);

            query.Get().AddOnCompleteListener(this);

            for(int i = 0; i < 40; i++)
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
                    {"userid", student.UserId },
                    {"firstname", student.FirstName },
                    {"lastname", student.LastName },
                    {"modifiedby", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid }
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

        public void SetJniIdentityHashCode(int value)
        {
            throw new NotImplementedException();
        }

        public void SetJniManagedPeerState(JniManagedPeerStates value)
        {
            throw new NotImplementedException();
        }

        public void SetPeerReference(JniObjectReference reference)
        {
            throw new NotImplementedException();
        }

        public void UnregisterFromRuntime()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Student student)
        {
            try
            {
                var studentdict = new Dictionary<string, Java.Lang.Object>
                {
                    {"username", student.Username },
                    {"userid", student.UserId },
                    {"firstname", student.FirstName },
                    {"lastname", student.LastName },
                    {"modifiedby", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid }
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