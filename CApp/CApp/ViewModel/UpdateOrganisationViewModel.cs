using CApp.Models;
using CApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CApp.ViewModel;


[QueryProperty(nameof(Organisation), "OrganisationObject")]
public partial class UpdateOrganisationViewModel : ObservableObject


{
    //private service for data to perfrom CRUD
    private readonly IDataService _dataService;
    

    //UI to change when organisations are updated
    [ObservableProperty]
    private Organisation _organisation;

    //injecting Idata service for data operations
    public UpdateOrganisationViewModel(IDataService dataService)
    {
        _dataService = dataService;
    }

    //updating organisations

    [RelayCommand]
    private async Task UpdateOrganisation()
    {
        try
        {
                await _dataService.UpdateOrganisation(Organisation);

                await Shell.Current.GoToAsync("..");
        }

        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Okay");
        }

    }
}
