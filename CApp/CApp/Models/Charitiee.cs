using CommunityToolkit.Mvvm.ComponentModel;


namespace CApp.Models
{

    //notifying UI of property change
   public partial class Charitiee : ObservableObject
    {

        //charity info
        public string Namee { get; set; }
        public string Pic { get; set; }
        public string Info { get; set; }


       //otified when cart is increased so amount is also changed

        [ObservableProperty, NotifyPropertyChangedFor(nameof(DonationAmount))]
        private int _DonationN;
        //private double DonationN { get; set; }

        public double DonationAmount => _DonationN * 5;

        //for basketPage
        //creating clone of the charity
        public Charitiee Clone() => MemberwiseClone() as Charitiee;
    }
}
 