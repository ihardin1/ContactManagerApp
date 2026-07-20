using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactManagerApp.Models;
using ContactManagerApp.Services;

namespace ContactManagerApp.ViewModels;

public partial class AddContactViewModel : ObservableObject
{
    private readonly ContactsViewModel contactsViewModel;
    private readonly INavigationService navigationService;

    [ObservableProperty]
    private string name = string.Empty;

    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private string phoneNumber = string.Empty;

    [ObservableProperty]
    private string description = string.Empty;

    public AddContactViewModel(
        ContactsViewModel contactsViewModel,
        INavigationService navigationService)
    {
        this.contactsViewModel = contactsViewModel;
        this.navigationService = navigationService;
    }

    [RelayCommand]
    private async Task SaveContactAsync()
    {
        if (string.IsNullOrWhiteSpace(Name) ||
            string.IsNullOrWhiteSpace(Email) ||
            string.IsNullOrWhiteSpace(PhoneNumber))
        {
            await ShowAlertAsync(
                "Missing Information",
                "Please enter a name, email, and phone number.");

            return;
        }

        if (!Email.Contains("@") || !Email.Contains("."))
        {
            await ShowAlertAsync(
                "Invalid Email",
                "Please enter a valid email address.");

            return;
        }

        ContactInfo newContact = new()
        {
            Name = Name.Trim(),
            Email = Email.Trim(),
            PhoneNumber = PhoneNumber.Trim(),
            Description = Description.Trim()
        };

        contactsViewModel.AddContact(newContact);

        ClearForm();

        await navigationService.GoToContactsPageAsync();
    }

    [RelayCommand]
    private async Task ViewContactsAsync()
    {
        await navigationService.GoToContactsPageAsync();
    }

    private void ClearForm()
    {
        Name = string.Empty;
        Email = string.Empty;
        PhoneNumber = string.Empty;
        Description = string.Empty;
    }

    private static async Task ShowAlertAsync(
        string title,
        string message)
    {
        Page? currentPage =
            Application.Current?.Windows.FirstOrDefault()?.Page;

        if (currentPage != null)
        {
            await currentPage.DisplayAlertAsync(
                title,
                message,
                "OK");
        }
    }
}