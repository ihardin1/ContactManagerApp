using ContactManagerApp.Services;
using ContactManagerApp.ViewModels;
using ContactManagerApp.Views;
using Microsoft.Extensions.Logging;

namespace ContactManagerApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont(
                    "OpenSans-Regular.ttf",
                    "OpenSansRegular");

                fonts.AddFont(
                    "OpenSans-Semibold.ttf",
                    "OpenSansSemibold");
            });

        // Services
        builder.Services.AddSingleton<INavigationService, NavigationService>();

        // ViewModels
        // ContactsViewModel must be a singleton so the same contact
        // collection is shared by every page.
        builder.Services.AddSingleton<ContactsViewModel>();

        builder.Services.AddTransient<AddContactViewModel>();
        builder.Services.AddTransient<ContactDetailsViewModel>();

        // Pages
        builder.Services.AddTransient<AddContactPage>();
        builder.Services.AddTransient<ContactsPage>();
        builder.Services.AddTransient<ContactDetailsPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}