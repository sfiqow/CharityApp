
using CApp.ViewModel;

namespace CApp.Page;

public partial class PaymentPage : ContentPage
{
    public PaymentPage(PaymentViewModel PaymentViewModel)
    {
        InitializeComponent();
        BindingContext = PaymentViewModel;
    }

}