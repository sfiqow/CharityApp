using Microsoft.Extensions.Logging;
using CApp.ViewModel;
using CApp.Page;
using CApp.Services;
using CApp.Interface;
using CApp.Models;
using CommunityToolkit.Maui;
using Supabase;



namespace CApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            //singleton- single instance for the applications lifetime
            //Transient a new instance each time a service is requested


            // Configure Supabase
            //regestering supabase client as singleton 
            var url = AppConfig.SUPABASE_URL;
            var key = AppConfig.SUPABASE_KEY;
            builder.Services.AddSingleton(provider => new Supabase.Client(url, key));

            // Add ViewModels-dependency injections
            //allows viewmodels to be injected into corresponding pages
            builder.Services.AddSingleton<OrganisationsListingViewModel>();
            builder.Services.AddTransient<AddOrganisationViewModel>();
            builder.Services.AddTransient<UpdateOrganisationViewModel>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<SignupViewModel>();


            // Add Views
            builder.Services.AddSingleton<OrganisationsListingPage>();
            builder.Services.AddTransient<AddOrganisationPage>();
            builder.Services.AddTransient<UpdateOrganisationPage>();
            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<SignupPage>();

            // Add Data & user services for business logic and database interactions
            //single instance shared throughout lifetime of app when injected
            builder.Services.AddSingleton<IDataService, DataService>();
            builder.Services.AddSingleton<IUserService, UserService>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewModel>();

            builder.Services.AddTransient<PaymentPage>();
            builder.Services.AddTransient<PaymentViewModel>();


#if DEBUG
            builder.Logging.AddDebug();
#endif
            AddCharityServices(builder.Services);
            builder.Services.AddTransient<UserService>();
            builder.Services.AddTransient<LoadingPage>();
            // builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<SignupPage>();
            return builder.Build();
        }

        //method for charity related- so correct charities are used for adding to basket etc.
        private static IServiceCollection AddCharityServices(IServiceCollection services)
        {
            services.AddSingleton<CharityService>();
            services.AddTransient<DetailPage>();
            services.AddTransient<DetailViewModel>();

            services.AddTransient<Charity1Page>();
            services.AddTransient<Charity1ViewModel>();

            services.AddTransient<BasketPage>();
            services.AddSingleton<BasketViewModel>();

            return services;
        }

    }


}
