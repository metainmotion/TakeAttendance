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
    internal class Firestore : IFirestore
    {
        public Task<bool> Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> Read()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}