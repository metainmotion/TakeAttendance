using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static TakeAttendance.Helpers.Auth;

[assembly: Dependency(typeof(TakeAttendance.Droid.Dependencies.Auth))]
namespace TakeAttendance.Droid.Dependencies
{

    internal class Auth : IAuth
    {
        public string GetCurrentUserId()
        {
            throw new NotImplementedException();
        }

        public bool isAuthenticated()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LoginUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}