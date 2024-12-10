using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CApp.Page;
using CApp.Services;
using CApp.Interface;
using CApp.ViewModel;
using CApp.Models;
using Supabase.Interfaces;
using static Supabase.Postgrest.Constants;
using System.Diagnostics.Metrics;
using Supabase.Gotrue;
//using Supabase.Gotrue;


namespace CApp.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        //initializing user service
        private readonly IUserService _userService; 

        public LoginViewModel(IUserService userService)
        {
            _userService = userService;
        }

        //binding user input to email/password
        [ObservableProperty]
        private string _namer;

        [ObservableProperty]
        private string _encryption;

        //going to singup page

        [RelayCommandAttribute]
        async Task SignupNow()
        {
            await Shell.Current.GoToAsync(nameof(SignupPage));


            Namer = string.Empty;
            Encryption = string.Empty;
        }

        //loggin in

        [RelayCommandAttribute]
        async Task LogginIn()
        {

            if (string.IsNullOrWhiteSpace(Namer) || string.IsNullOrWhiteSpace(Encryption))
            {
                await Shell.Current.DisplayAlert("Error", "Email and password needed", "try again");

                return;
            }

            if (!string.IsNullOrWhiteSpace(Namer) || !string.IsNullOrWhiteSpace(Encryption))
            {

                try
                {
                    //user authenticated
                    //loggin in
                    await _userService.LoginUser(Namer, Encryption);

                    if (true)
                    {

                        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");

                        Namer = string.Empty;
                        Encryption = string.Empty;

                    }


                }
                // User is not authenticated
                catch (Exception ex) 
                {
                    await Shell.Current.DisplayAlert("Error",ex.Message , "Okay");

                }
                
            }

            }


        }

    }
    



