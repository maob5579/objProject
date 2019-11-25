using System;
using System.Collections.Generic;
using System.Text;
using MoodFull.Views;
using MoodFull.Mocks;
using Xamarin.Forms;

namespace MoodFull.ViewModels
{
    /*klase kuri sukurs nauja vartotojo paskyra.  Paspaudus register sugrazins kontrole
      i login langa*/
    public class RegisterViewModel
    {
        string username;
        string password;
        string confirmPassword;
        string name;
        string lastName;
        Services.UserService _userService = new Services.UserService();
        Models.User _user = new Models.User();

        

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }

        //public delegate bool PasswordMatches(string Password, string ConfirmPassword );
        Func<string, string, bool> PasswordMatches = delegate (string Password, string ConfirmPassword) { return Password.Equals(ConfirmPassword);};
        public RegisterViewModel()
        {

        }

        public Command LauchLoginWindowCommand
        {
            get
            {
                return new Command(Register);
            }
        }

        private async void Register()
        {
            if (!PasswordMatches(Password,ConfirmPassword))
            {
               await Application.Current.MainPage.DisplayAlert("Error", "Password doesn't match", "OK");
                return;
            }
            if (IsEmptyFields())
            {
               await Application.Current.MainPage.DisplayAlert("Error", "Fields cannot be empty", "OK");
                return;
            }

            _user.Username = Username;
            _user.Password = Password;
            _user.FirstName = Name;
            _user.LastName = LastName;

           await _userService.PostUserAsync(_user);

          await  Application.Current.MainPage.DisplayAlert("Success", "", "OK");

          await  Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        public bool IsEmptyFields()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName))
            {
                return true;
            }
            return false;
        }

    }
}
