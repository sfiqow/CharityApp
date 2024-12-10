using CApp.Page;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace CApp.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [RelayCommandAttribute]
        async Task Tap1()
        {

            await Shell.Current.GoToAsync("detailpage");

        }

    }
}