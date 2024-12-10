using CApp.ViewModel;

namespace CApp.Page;

public partial class OrganisationsListingPage : ContentPage
{
    public OrganisationsListingPage(OrganisationsListingViewModel organisationsListingViewModel)
	{
		InitializeComponent();
        BindingContext = organisationsListingViewModel;
    }
}