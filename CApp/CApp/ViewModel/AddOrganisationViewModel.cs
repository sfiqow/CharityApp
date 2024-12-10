using CApp.Models;
using CApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CApp.ViewModel;

public partial class AddOrganisationViewModel : ObservableObject
{
    //injecting dataservice to handle data operations.
    private readonly IDataService _dataService;

    // user input
    [ObservableProperty]
    private string _organisationTitle;
    [ObservableProperty]
    private string _organisationNeeded;
    [ObservableProperty]
    private string _organisationDetail;

    //Idata service as dependency to handle data operations
    //instance of Idataservice injected into viewmodel
    public AddOrganisationViewModel(IDataService dataService)
    {
        _dataService = dataService;
    }


    [RelayCommand]
    private async Task AddOrganisation()
    {
        try
        {
            if (!string.IsNullOrEmpty(OrganisationTitle) || !string.IsNullOrEmpty(OrganisationNeeded) || !string.IsNullOrEmpty(OrganisationDetail))
            {
                Organisation organisation = new()
                {
                    Title = OrganisationTitle,
                    Needed = OrganisationNeeded,
                    Detail = OrganisationDetail,
                };
                await _dataService.CreateOrganisation(organisation);

                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Please add all the information!", "Okay");
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Okay");
        }

        await Shell.Current.GoToAsync("..");

    }
}
