using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CApp.Page;
using CApp.Services;
using CApp.Interface;
using CApp.Models;
using Microsoft.Maui.ApplicationModel.Communication;
//using Supabase.Gotrue;


namespace CApp.ViewModel
{
    public partial class SignupViewModel : ObservableObject
    {
        private readonly IUserService _userService;

        //binding the users input to email/password

        [ObservableProperty]
        private string _userEmail;

        [ObservableProperty]
        private string _userPassword;


        // Constructor to injects IUserService to interact with the backend for user operations.
        public SignupViewModel(IUserService userService)
        {
            _userService = userService;
        }

        //go back to login page

        [RelayCommandAttribute]
        async Task Login()
        {
            await Shell.Current.GoToAsync("..");

            UserEmail = string.Empty;
            UserPassword = string.Empty;
        }


        //Making sure that they sign up correctly
        //adding a new user to the database

        [RelayCommandAttribute]
       private async Task SignupNow()
        {
            try
            {
                if (!string.IsNullOrEmpty(UserEmail) || !string.IsNullOrWhiteSpace(UserPassword))
                  {


                    await _userService.CreateUser(UserEmail, UserPassword);


                    await Shell.Current.DisplayAlert("Great!", "An account has been created", "Login now!");

                    UserEmail = string.Empty;
                    UserPassword = string.Empty;
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Email and password needed!", "try again");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }

        }

    }
}
