using CApp.Models;
using Microsoft.Maui.ApplicationModel.Communication;
using Supabase;
using Client = Supabase.Client;

namespace CApp.Interface;

public class UserService : IUserService
{
    private readonly Client _supabaseClient;

    //storing superbase client supabase client instance


    //injecting client dependency
    public UserService(Supabase.Client supabaseClient)
    {
        _supabaseClient = supabaseClient; //initializing client
    }



    //getting list of users
    public async Task<IEnumerable<User>> GetUsers()
    {
        var response = await _supabaseClient.From<User>().Get();
        return response.Models.OrderByDescending(b => b.CreatedAt);
    }


    //registering user

    public async Task CreateUser(string email1, string password1)
    {

        string Email1 = email1;
        string Password1 = password1;
        
        await _supabaseClient.Auth.SignUp(Email1, Password1);

        var user = new User
        {
            Email1 = email1,
            Password1 = password1
        };

        await _supabaseClient.From<User>().Insert(user);

    }



    //logging in user

    public async Task LoginUser(string email1, string password1)
    {

        //await _supabaseClient.From<User>().Insert(user);
        string Email1 = email1;
        string Password1 = password1;


        await _supabaseClient.Auth.SignIn(Email1, Password1);
    }



    public async Task UpdateUser(User user)
    {
        await _supabaseClient.From<User>().Where(b => b.Id == user.Id)
            .Set(b => b.Email1, user.Email1)
            .Set(b => b.Password1, user.Password1)
            .Update();
    }

}
