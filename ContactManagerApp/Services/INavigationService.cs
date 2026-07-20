using ContactManagerApp.Models;

namespace ContactManagerApp.Services;

public interface INavigationService
{
    Task GoToContactsPageAsync();

    Task GoToContactDetailsPageAsync(ContactInfo contact);

    Task GoBackAsync();
}