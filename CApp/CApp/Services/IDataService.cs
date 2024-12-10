using CApp.Models;

namespace CApp.Services;

//API handling the organisations connected to supabase
//defining data service tasks
public interface IDataService
{
    //working with large collections of data
    Task<IEnumerable<Organisation>> GetOrganisations();
    Task CreateOrganisation(Organisation organisation);
    Task DeleteOrganisation(int id);
    Task UpdateOrganisation(Organisation organisation);


}
