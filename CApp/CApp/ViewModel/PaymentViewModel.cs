//using CommunityToolkit.Mvvm.ComponentModel;
//using CommunityToolkit.Mvvm.Input;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CApp.ViewModel
//{
//    internal class PaymentViewModel
//    {
//    }
//}

using CApp.Page;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace CApp.ViewModel
{
    public partial class PaymentViewModel : ObservableObject
    {
        [RelayCommandAttribute]
        async Task Payed()
        {

            await Shell.Current.GoToAsync("CheckOutPage");

        }

    }
}
