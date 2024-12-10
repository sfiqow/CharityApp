using CApp.ViewModel;

namespace CApp.Page;

public partial class UpdateOrganisationPage : ContentPage
{
	public UpdateOrganisationPage(UpdateOrganisationViewModel updateOrganisationViewModel)
	{
		InitializeComponent();
        BindingContext = updateOrganisationViewModel;
    }
}