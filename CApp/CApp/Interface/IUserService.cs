using CApp.Models;

namespace CApp.Interface;

//user related service
public interface IUserService
{
    //asynchronous method to create, get and update user
    Task<IEnumerable<User>> GetUsers();
    Task CreateUser(string email1, string password1);

    Task UpdateUser(User user);

    Task LoginUser(string email1, string password1);


    private const string AuthKey = "Auth";

    //checking if user is authenticated
    public async Task<bool> isAuthAsync()
    {
        await Task.Delay(1000);

        //if no value consider to be false
        //var auth = Preferences.Default.Get<bool>(AuthKey, false);
        return false;
    }


    public void Logout()
    {
        Preferences.Default.Remove(AuthKey);
    }


}
