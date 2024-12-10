namespace CApp.Page;

public partial class CheckOutPage : ContentPage
{
	public CheckOutPage()
	{
		InitializeComponent();
	}


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        IMG.ScaleTo(1.5);
        MSG.ScaleTo(1);

        await IMG.ScaleTo(0.5);
        await IMG.ScaleTo(1.5);
        await IMG.ScaleTo(0.5);
        await IMG.ScaleTo(1.5);
        await IMG.ScaleTo(0.5);
        await IMG.ScaleTo(1.5);
        await IMG.ScaleTo(1);

        MBTN.FadeTo(1, length: 500);
        await MBTN.ScaleTo(1);



    }

    //removing from stack 
    //going to mainpage
    async private void MBTN_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}", animate: true);
    }
}
