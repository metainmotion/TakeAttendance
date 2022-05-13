using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAttendance.Helpers;
using Xamarin.Forms;


[assembly: Dependency(typeof(TakeAttendance.iOS.Dependencies.Firestore))]
namespace TakeAttendance.iOS.Dependencies
{
    public class Firestore : IFirestore
    {
        public async Task<bool> Delete(Student student)
        {
            try
            {
                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("students");

                await collection.GetDocument(student.Id).DeleteDocumentAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<List<Student>> Read()
        {
            try 
            {
                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("students");
                //var query = collection.WhereEqualsTo("modifiedby", Firebase.Auth.Auth.DefaultInstance.CurrentUser.Email);

                var query = collection.OrderedBy("lastname");

                var documents = await query.GetDocumentsAsync();

                List<Student> students = new List<Student>();

                students.Clear();

                foreach (var doc in documents.Documents)
                {
                    var studentdict = doc.Data;

                    var student = new Student()
                    {
                        Username = studentdict.ValueForKey(new NSString("username")) as NSString,
                        Phone = studentdict.ValueForKey(new NSString("phone")) as NSString,
                        FirstName = studentdict.ValueForKey(new NSString("firstname")) as NSString,
                        LastName = studentdict.ValueForKey(new NSString("lastname")) as NSString,
                        ModifiedBy = studentdict.ValueForKey(new NSString("modifiedby")) as NSString,
                        Created = studentdict.ValueForKey(new NSString("created")) as NSString,
                        BirthDate = studentdict.ValueForKey(new NSString("birthdate")) as NSString,
                        Parentg1 = studentdict.ValueForKey(new NSString("parentg1")) as NSString,
                        Parentg2 = studentdict.ValueForKey(new NSString("parentg2")) as NSString,
                        AltPhone = studentdict.ValueForKey(new NSString("altphone")) as NSString,
                        Email = studentdict.ValueForKey(new NSString("email")) as NSString,
                        Nganh = studentdict.ValueForKey(new NSString("nganh")) as NSString,
                        ChiDoan = (int)(studentdict.ValueForKey(new NSString("chidoan")) as NSNumber),
                        Medical = studentdict.ValueForKey(new NSString("medical")) as NSString,
                        PaidStat = studentdict.ValueForKey(new NSString("paidstat")) as NSString,
                        Comments = studentdict.ValueForKey(new NSString("comments")) as NSString,
                        Id = doc.Id
                    };

                    students.Add(student);
                }

                return students; 
            }
            catch (Exception ex)
            {
                return new List<Student>();
            }
            
        }

        public bool RegisterStudent(Student student)
        {
            try
            {
                var keys = new[]
                {
                    new NSString("username"),
                    new NSString("phone"),
                    new NSString("firstname"),
                    new NSString("lastname"),
                    new NSString("created"),
                    new NSString("birthdate"),
                    new NSString("parentg1"),
                    new NSString("parentg2"),
                    new NSString("altphone"),
                    new NSString("email"),
                    new NSString("nganh"),
                    new NSString("chidoan"),
                    new NSString("medical"),
                    new NSString("paidstat"),
                    new NSString("comments"),
                    new NSString("modifiedby")
                };

                var values = new NSObject[]
                {
                    new NSString(student.Username),
                    new NSString(student.Phone),
                    new NSString(student.FirstName),
                    new NSString(student.LastName),
                    new NSString(DateTime.Now.ToShortDateString()),
                    new NSString(student.BirthDate),
                    new NSString(student.Parentg1),
                    new NSString(student.Parentg2),
                    new NSString(student.AltPhone),
                    new NSString(student.Email),
                    new NSString(student.Nganh),
                    new NSNumber(student.ChiDoan),
                    new NSString(student.Medical),
                    new NSString(student.PaidStat),
                    new NSString(student.Comments),
                    new NSString(Firebase.Auth.Auth.DefaultInstance.CurrentUser.Email)
                };

                var document = new NSDictionary<NSString, NSObject>(keys, values);

                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("students");

                collection.AddDocument(document);

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
                var keys = new[]
                {
                    new NSString("username"),
                    new NSString("phone"),
                    new NSString("firstname"),
                    new NSString("lastname"),
                    new NSString("created"),
                    new NSString("birthdate"),
                    new NSString("parentg1"),
                    new NSString("parentg2"),
                    new NSString("altphone"),
                    new NSString("email"),
                    new NSString("nganh"),
                    new NSString("chidoan"),
                    new NSString("medical"),
                    new NSString("paidstat"),
                    new NSString("comments"),
                    new NSString("modifiedby")
                };

                var values = new NSObject[]
                {
                    new NSString(student.Username),
                    new NSString(student.Phone),
                    new NSString(student.FirstName),
                    new NSString(student.LastName),
                    new NSString(student.Created),
                    new NSString(student.BirthDate),
                    new NSString(student.Parentg1),
                    new NSString(student.Parentg2),
                    new NSString(student.AltPhone),
                    new NSString(student.Email),
                    new NSString(student.Nganh),
                    new NSNumber(student.ChiDoan),
                    new NSString(student.Medical),
                    new NSString(student.PaidStat),
                    new NSString(student.Comments),
                    new NSString(Firebase.Auth.Auth.DefaultInstance.CurrentUser.Email)
                };

                var document = new NSDictionary<NSObject, NSObject>(keys, values);

                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("students");

                await collection.GetDocument(student.Id).UpdateDataAsync(document);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}