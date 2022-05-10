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
using Firebase.Auth;
using TakeAttendance.Helpers;

[assembly: Dependency(typeof(TakeAttendance.Droid.Dependencies.Auth))]
namespace TakeAttendance.Droid.Dependencies
{

    internal class Auth : IAuth
    {
        public string GetCurrentUserId()
        {
            return Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid;
        }

        public bool isAuthenticated()
        {
            return FirebaseAuth.Instance.CurrentUser != null;
        }

        public async Task<bool> LoginUser(string username, string password)
        {
            try
            {
               await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(username, password);    
               
               return true;
            }
            catch(FirebaseAuthInvalidCredentialsException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthInvalidUserException ex)
            {
                throw new Exception(ex.Message); 
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error");
            }
        }

        public async Task<bool> RegisterUser(string username, string password)
        {
            try
            {
                await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(username, password);

                return true;
            }
            catch(FirebaseAuthWeakPasswordException ex)
            {
                throw new Exception(ex.Message); 
            }
            catch(FirebaseAuthUserCollisionException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not register. Please be sure that you are registering with a valid address");
            }
        }
    }
}