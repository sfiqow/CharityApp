using CApp.Models;
using CApp.Page;
using CApp.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Maui.Core;



namespace CApp.ViewModel
{

    //observer pattern
    //notifying of changes happening to the basket
    //observer- charityviewmodel -which is being updated


    // Attribute to bind the charity object chosen as a query parameter for the charity that is shown.
    [QueryProperty(nameof(Charitiee), nameof(Charitiee))]

    //dispose pattern-releasing unmanaged resources when object is nolonger needed(cleaning up)
    public partial class Charity1ViewModel : ObservableObject, IDisposable
    {
        //referencing basket model to be updated depending on what the user does.

        private readonly BasketViewModel _basketViewModel;  

        //setting event handlers for basket changes
        public Charity1ViewModel(BasketViewModel basketViewModel)
        {
            _basketViewModel = basketViewModel;
            _basketViewModel.BasketCleared += OnBasketCleared;
            _basketViewModel.BasketContributionUpdated += OnBasketContributionUpdated;
            _basketViewModel.BasketContributionRemoved += OnBasketContributionRemoved;
        }

        private void OnBasketCleared(object? _, EventArgs E)
        {
            Charitiee.DonationN = 0;
        }

        // Calls OnBasketContributionChanged with 0 donations for the removed charity
        private void OnBasketContributionRemoved(object? _, Charitiee c) => OnBasketContributionChanged(c, 0);

        //updates donation count
        private void OnBasketContributionUpdated(object? _, Charitiee c) => OnBasketContributionChanged(c, c.DonationN);

        // Updates the donated amount for a charity if its name matches the one passed.
        private void OnBasketContributionChanged(Charitiee c, int donations)
        {
            if(c.Namee == Charitiee.Namee)
            {
                Charitiee.DonationN = donations;
            }
        }

        [ObservableProperty]
        private Charitiee _charitiee;

        //increasing the donation amount
        [RelayCommandAttribute] 
        public void Increase()
        {
            Charitiee.DonationN++;
           _basketViewModel.UpdateBasketcontributionCommand.Execute(Charitiee);
        }
         
        //decreasind donation amount if more than 0
        [RelayCommandAttribute]
        public void Decrease()
        {
            if (Charitiee.DonationN > 0)
                Charitiee.DonationN--;
            _basketViewModel.UpdateBasketcontributionCommand.Execute(Charitiee);
        }

        [RelayCommandAttribute]
        static async Task OnGoBack()
        {
            await Shell.Current.GoToAsync("..");

        }

        [RelayCommandAttribute]
        private async Task ViewBasket()
        {
            if (Charitiee.DonationN > 0)
            {
                await Shell.Current.GoToAsync("BasketPage");
            }
            else
            {
                //Toast.Make("First add to the cart", ToastDuration.Short);
                await Shell.Current.DisplayAlert("Error!", "First add to cart", "Okay");

            }
        }

        //unsubscribing from events.-preventing memory leaks
        public void Dispose()
        {
            _basketViewModel.BasketCleared -= OnBasketCleared;
            _basketViewModel.BasketContributionUpdated -= OnBasketContributionUpdated;
            _basketViewModel.BasketContributionRemoved -= OnBasketContributionRemoved;
        }
    }
}
