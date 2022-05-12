using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TakeAttendance.Helpers
{
   public interface IFirestore
    {
        Task<List<Student>> Read();
        bool RegisterStudent(Student student);
        Task<bool> Update(Student student); 
        Task<bool> Delete(Student student);
    }
   public class FirestoreHelper
    {
        public static IFirestore firestore = DependencyService.Get<IFirestore>();

        public static async Task<List<Student>> Read()
        {
            return await firestore.Read();
        }

        public static bool RegisterStudent(Student student)
        {
            return firestore.RegisterStudent(student);
        }

        public static async Task<bool> Update(Student student)
        {
            return await firestore.Update(student);
        }

        public static async Task<bool> Delete(Student student)
        {
            return await firestore.Delete(student); 
        }
    }
}
