using CApp.Models;
using CApp.ViewModel;
using CApp.Page;
using CApp.Services;
using Supabase.Gotrue;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;



namespace CApp.ViewModel
{
    public partial class BasketViewModel : ObservableObject
    {

        //observer pattern
        //event handler notifies other part of the app of changes
        public EventHandler<Charitiee> BasketContributionRemoved;
        public EventHandler<Charitiee> BasketContributionUpdated;
        public event EventHandler BasketCleared;
        public ObservableCollection<Charitiee> Contributions { get; set; } = new();


        [ObservableProperty]
        private double _totalAmount;

        //recalculating the total amount
        //state pattern
        //state of basket is tracked changing the total amount whenever needed
        private void NewTotalAmount() => TotalAmount = Contributions.Sum(i => i.DonationAmount);

        //command patterns
        //commands to be excecuted depending on the user interaction

        [RelayCommandAttribute]
        private void UpdateBasketcontribution(Charitiee charitiee)
        {
            //checking if the charity is already in the basket
            var contribution = Contributions.FirstOrDefault(i => i.Namee == charitiee.Namee);
            if(contribution is not null) 
            {
                //if it exsit update it
                contribution.DonationN = charitiee.DonationN;
                //Contributions.Add(contribution);
            }
            else
            {

                //adding the charity
                Contributions.Add(charitiee.Clone());
            }
            NewTotalAmount();
        }

        [RelayCommandAttribute]
        private async void RemoveBasketContribution(string Namee) 
        {
            //checking if the string exists in the basket
            var contribution = Contributions.FirstOrDefault(i => i.Namee == Namee);
            if (contribution is not null)
            {

                Contributions.Remove(contribution);
                NewTotalAmount();

                //telling the app that something has been removed
                BasketContributionRemoved?.Invoke(this, contribution);

                //creating temporary message
                //decorator pattern
                var snackbarOptions = new SnackbarOptions
                {

                    CornerRadius = 10,
                    // BackgroundC

                };
                
                //user wants to undo the removal
                var snackbar = Snackbar.Make($"'{contribution.Namee}' removed from basket",
                    () =>
                    {
                        
                        //Undo the removal action: re-add the contribution back to the basket.
                        Contributions.Add(contribution);
                        NewTotalAmount();

                        //basket knows to readd
                        BasketContributionUpdated?.Invoke(this, contribution);

                        //button and time it will show for
                    }, "undo", TimeSpan.FromSeconds(5), snackbarOptions);

                await snackbar.Show();
            }
        }

        [RelayCommandAttribute]
        private async Task ClearBasket()
        {
            if (await Shell.Current.DisplayAlert("", "Are you sure you want to remove all contributions? ", "Yes", "No"))
            {
                Contributions.Clear();
                NewTotalAmount();

                BasketCleared?.Invoke(this, EventArgs.Empty);

                //notification that it has been removed

                await Toast.Make("Donations removed", ToastDuration.Short).Show();
            }
        }

        [RelayCommandAttribute]
        private async Task Pay()
        {
            //removing contributions for new empty cart
            Contributions.Clear();
            BasketCleared?.Invoke(this, EventArgs.Empty);
            NewTotalAmount();
            await Shell.Current.GoToAsync("PaymentPage");
        }

        [RelayCommandAttribute]
        static async Task OnGoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
