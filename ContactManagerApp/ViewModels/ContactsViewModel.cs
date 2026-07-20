using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactManagerApp.Models;
using ContactManagerApp.Services;

namespace ContactManagerApp.ViewModels;

public partial class ContactsViewModel : ObservableObject
{
    private readonly INavigationService navigationService;

    public ObservableCollection<ContactInfo> Contacts { get; } = new();

    public ContactsViewModel(
        INavigationService navigationService)
    {
        this.navigationService = navigationService;
    }

    public void AddContact(ContactInfo contact)
    {
        Contacts.Add(contact);
    }

    [RelayCommand]
    private async Task OpenContactAsync(ContactInfo? contact)
    {
        if (contact == null)
        {
            return;
        }

        await navigationService.GoToContactDetailsPageAsync(contact);
    }

    [RelayCommand]
    private async Task AddAnotherContactAsync()
    {
        await navigationService.GoBackAsync();
    }
}