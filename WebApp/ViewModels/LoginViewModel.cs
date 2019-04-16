using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Maak class en Maak variables voor username, wachtwoord, rememberme, returnurl, error.
/// </summary>
namespace OrderFoodApp.WebApp.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
        public bool NotFound { get; set; }
    }
}