using CApp.ViewModel;

namespace CApp.Page;

public partial class AddOrganisationPage : ContentPage
{
	public AddOrganisationPage(AddOrganisationViewModel addOrganisationViewModel)
    {
        InitializeComponent();
        BindingContext = addOrganisationViewModel;
    }

}