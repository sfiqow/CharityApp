
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CApp.Page;
using CApp.Services;
using CApp.Models;



namespace CApp.ViewModel
{

    public partial class DetailViewModel : ObservableObject
    {
        //getting the charity data

        private readonly CharityService _charityService;

        //adding all the charities
        public DetailViewModel(CharityService charityService)
        {
            _charityService = charityService;
            Charitiess = new(_charityService.GetAllCharitiess());
        }
        public ObservableCollection<Charitiee> Charitiess { get; set; }

        //checking when search is in progress

        [ObservableProperty]
        private bool _searching;

        //command pattern
        //User triggered methods into commands
        //command to search for charities
        //takes away current list for new list based on the search term
        [RelayCommandAttribute]
        private async Task SearchCharitiess(string SearchTerm)
        {
            Charitiess.Clear(); 
            Searching = true;
            foreach (var charitiee in _charityService.GetCharitiess(SearchTerm))
            {
                Charitiess.Add(charitiee);
            }
            Searching = false;


        }

        //going to a certain charity command

        [RelayCommandAttribute]
        private async Task Charity1(Charitiee charitiee)
        {
            //making a dictionary to store the parameter to be passed
            var parameters = new Dictionary<string, object>
            {
                [nameof(Charity1ViewModel.Charitiee)] = charitiee //passing the charity to charity1viewmodel
            };
            await Shell.Current.GoToAsync(nameof(Charity1Page), animate: true, parameters);

        }

    }
}


