using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TakeAttendance.Helpers
{

    public interface IAuth
    {
        Task<bool> RegisterUser(string username, string password);
        Task<bool> LoginUser(string username, string password);
        bool isAuthenticated();
        string GetCurrentUserId();
    }

    public class Auth
    { 

        private static IAuth auth = DependencyService.Get<IAuth>(); //Searching for the exports of the interface

        public Auth()
        {

        }

        public static async Task<bool> RegisterUser(string username, string password)
        {
            try
            {
                return await auth.RegisterUser(username, password);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error Registering", ex.Message, "Ok");
                return false;
            }
            
        }

        public static async Task<bool> LoginUser(string username, string password)
        {
            try
            {
                return await auth.LoginUser(username, password);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error logging in", ex.Message, "Ok");
                return false;
            }
            
        }

        public static bool isAuthenticated()
        {
            return auth.isAuthenticated();
        }

        public static string GetCurrentUserId()
        {
            return auth.GetCurrentUserId();
        }
    }
}
