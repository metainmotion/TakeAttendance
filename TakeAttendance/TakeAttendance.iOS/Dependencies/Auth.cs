using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using TakeAttendance.Helpers;
using static TakeAttendance.Helpers.Auth;
using Xamarin.Forms;
using System.Threading.Tasks;
using TakeAttendance.Helpers;

[assembly: Dependency(typeof(TakeAttendance.iOS.Dependencies.Auth))] //Exporting the dependency so the Auth Helpers can reference
namespace TakeAttendance.iOS.Dependencies
{
    internal class Auth : IAuth
    {
        public Auth()
        {

        }

        public string GetCurrentUserId()
        {
            return Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid;
        }

        public bool isAuthenticated()
        {
            return Firebase.Auth.Auth.DefaultInstance.CurrentUser != null;
        }

        public async Task<bool> LoginUser(string username, string password)
        {
            try 
            {
                await Firebase.Auth.Auth.DefaultInstance.SignInWithPasswordAsync(username, password);
                return true;
            }
            catch (NSErrorException error)
            {
                string message = error.Message.Substring(error.Message.IndexOf("NSLocalizedDescription="), (int)StringComparison.CurrentCulture);
                message = message.Replace("NSLocalizedDescription=", "").Split('.')[0];
                throw new Exception(message);
             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<bool> RegisterUser(string username, string password)
        {
            try
            {
                await Firebase.Auth.Auth.DefaultInstance.CreateUserAsync(username, password);
                return true;
            }
            catch (NSErrorException error)
            {
                string message = error.Message.Substring(error.Message.IndexOf("NSLocalizedDescription="), (int)StringComparison.CurrentCulture);
                message = message.Replace("NSLocalizedDescription=", "").Split('.')[0];
                throw new Exception(message);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not register. Please be sure that you are registering with a valid address");
            }
        }
    }
}