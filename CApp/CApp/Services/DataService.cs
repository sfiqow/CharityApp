using CApp.Models;
using Supabase;

namespace CApp.Services;

//providing CRUD for the database
//CREATE, READ, UPDATE and DELETE. 
public class DataService : IDataService
{
    private readonly Client _supabaseClient;

    public DataService(Supabase.Client supabaseClient)
    {
        _supabaseClient = supabaseClient;
    }

    public async Task<IEnumerable<Organisation>> GetOrganisations()
    {
        var response = await _supabaseClient.From<Organisation>().Get();
        return response.Models.OrderByDescending(b => b.CreatedAt);
    }
    
    public async Task CreateOrganisation(Organisation organisation)
    {
        await _supabaseClient.From<Organisation>().Insert(organisation);
    }

    public async Task DeleteOrganisation(int id)
    {
        await _supabaseClient.From<Organisation>()
            .Where(b => b.Id == id).Delete();
    }

    public async Task UpdateOrganisation(Organisation organisation)
    {
        await _supabaseClient.From<Organisation>().Where(b => b.Id == organisation.Id)
            .Set(b => b.Title, organisation.Title)
            .Set(b => b.Needed, organisation.Needed)
            .Set(b => b.Detail, organisation.Detail)
            .Update();
    }
}
