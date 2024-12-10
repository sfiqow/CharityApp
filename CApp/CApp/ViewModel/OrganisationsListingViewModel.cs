using CApp.Models;
using CApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CApp.ViewModel;

public partial class OrganisationsListingViewModel : ObservableObject
    //with the Idataservice it add organisations to the UI able to CRUD
{
    private readonly IDataService _dataService;

    //Notifyin UI of any changes
    //observer pattern
    //Updating UI with any changes
    public ObservableCollection<Organisation> Organisations { get; set; } = new();

    public OrganisationsListingViewModel(IDataService dataService)
    {
        _dataService = dataService;
    }

    [RelayCommand]
    public async Task GetOrganisations()
    {
        Organisations.Clear();

        try
        {
            var organisations = await _dataService.GetOrganisations();

            //if there are any organisations add them
            if (organisations.Any())
            {
                foreach (var organisation in organisations)
                {
                     Organisations.Add(organisation);
                }
            }
        }
        //error such as network error display this message
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Okay");
        }
    }


    [RelayCommand]
    private async Task AddOrganisation()
    {
        await Shell.Current.GoToAsync("AddOrganisationPage");

    }



    [RelayCommand]
    private async Task DeleteOrganisation(Organisation organisation)
    {
        var info = await Shell.Current.DisplayAlert("Delete", $"Do you want to delete \"{organisation.Title}\"?", "Yes", "No");

        if (info is true)
        {
            try
            {
                await _dataService.DeleteOrganisation(organisation.Id);
                //getting updated organisations
                await GetOrganisations();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }

    //going to organisation listing page however the organisation has now been updated

    [RelayCommand]
    private async Task UpdateOrganisation(Organisation organisation)
    {
        await NavigateToUpdateOrganisationPage(organisation);
    }

    private async Task NavigateToUpdateOrganisationPage(Organisation organisation)
    {
        var navigationParameters = new Dictionary<string, object>
    {
        { "OrganisationObject", organisation }
    };
        await Shell.Current.GoToAsync("UpdateOrganisationPage", navigationParameters);
    }

}
