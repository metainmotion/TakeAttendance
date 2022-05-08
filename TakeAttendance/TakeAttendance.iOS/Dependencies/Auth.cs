﻿using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using TakeAttendance.Helpers;
using static TakeAttendance.Helpers.Auth;
using Xamarin.Forms;
using System.Threading.Tasks;

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
                throw new Exception(error.Message);
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
                throw new Exception(error.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}