using ContactManagerApp.Models;
using ContactManagerApp.ViewModels;
using ContactManagerApp.Views;

namespace ContactManagerApp.Services;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider serviceProvider;

    public NavigationService(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public async Task GoToContactsPageAsync()
    {
        ContactsPage contactsPage =
            serviceProvider.GetRequiredService<ContactsPage>();

        await GetNavigation().PushAsync(contactsPage);
    }

    public async Task GoToContactDetailsPageAsync(ContactInfo contact)
    {
        ContactDetailsPage detailsPage =
            serviceProvider.GetRequiredService<ContactDetailsPage>();

        ContactDetailsViewModel viewModel =
            serviceProvider.GetRequiredService<ContactDetailsViewModel>();

        viewModel.LoadContact(contact);
        detailsPage.BindingContext = viewModel;

        await GetNavigation().PushAsync(detailsPage);
    }

    public async Task GoBackAsync()
    {
        await GetNavigation().PopAsync();
    }

    private static INavigation GetNavigation()
    {
        Page? currentPage =
            Application.Current?.Windows.FirstOrDefault()?.Page;

        if (currentPage is NavigationPage navigationPage)
        {
            return navigationPage.Navigation;
        }

        throw new InvalidOperationException(
            "The application must use a NavigationPage.");
    }
}