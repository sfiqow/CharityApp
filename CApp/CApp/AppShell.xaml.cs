using CApp.Page;

namespace CApp

{
    public partial class AppShell : Shell
    {
        //navigation structure using shell
        public AppShell()
        {
            InitializeComponent();

            //registering routes for navigation

            Routing.RegisterRoute("detailpage", typeof(DetailPage));
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("Charity1Page", typeof(Charity1Page));
            Routing.RegisterRoute("BasketPage", typeof(BasketPage));
            Routing.RegisterRoute("PaymentPage", typeof(PaymentPage));
            //Routing.RegisterRoute("CheckOutPage", typeof(CheckOutPage));
            Routing.RegisterRoute("ProfilePage", typeof(ProfilePage));
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));


            // Using a method to register routes for additional pages.
            RegisterForRoute<AddOrganisationPage>();
            RegisterForRoute<UpdateOrganisationPage>();
            RegisterForRoute<SignupPage>();
            RegisterForRoute<CheckOutPage>();


        }

        protected void RegisterForRoute<T>()
        {
            Routing.RegisterRoute(typeof(T).Name, typeof(T));
        }
    }
}

