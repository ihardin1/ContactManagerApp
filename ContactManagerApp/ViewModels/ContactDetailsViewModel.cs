using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactManagerApp.Models;
using ContactManagerApp.Services;

namespace ContactManagerApp.ViewModels;

public partial class ContactDetailsViewModel : ObservableObject
{
    private readonly INavigationService navigationService;

    private ContactInfo? selectedContact;

    [ObservableProperty]
    private string name = string.Empty;

    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private string phoneNumber = string.Empty;

    [ObservableProperty]
    private string description = string.Empty;

    [ObservableProperty]
    private bool isEditing;

    public bool IsNotEditing => !IsEditing;

    public ContactDetailsViewModel(
        INavigationService navigationService)
    {
        this.navigationService = navigationService;
    }

    partial void OnIsEditingChanged(bool value)
    {
        OnPropertyChanged(nameof(IsNotEditing));
    }

    public void LoadContact(ContactInfo contact)
    {
        selectedContact = contact;

        Name = contact.Name;
        Email = contact.Email;
        PhoneNumber = contact.PhoneNumber;
        Description = contact.Description;

        IsEditing = false;
    }

    [RelayCommand]
    private void EditContact()
    {
        IsEditing = true;
    }

    [RelayCommand]
    private async Task SaveChangesAsync()
    {
        if (selectedContact == null)
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(Name) ||
            string.IsNullOrWhiteSpace(Email) ||
            string.IsNullOrWhiteSpace(PhoneNumber))
        {
            await ShowAlertAsync(
                "Missing Information",
                "Name, email, and phone number are required.");

            return;
        }

        selectedContact.Name = Name.Trim();
        selectedContact.Email = Email.Trim();
        selectedContact.PhoneNumber = PhoneNumber.Trim();
        selectedContact.Description = Description.Trim();

        IsEditing = false;

        await ShowAlertAsync(
            "Contact Updated",
            "The contact was updated successfully.");
    }

    [RelayCommand]
    private void CancelEditing()
    {
        if (selectedContact == null)
        {
            return;
        }

        Name = selectedContact.Name;
        Email = selectedContact.Email;
        PhoneNumber = selectedContact.PhoneNumber;
        Description = selectedContact.Description;

        IsEditing = false;
    }

    [RelayCommand]
    private async Task GoBackAsync()
    {
        await navigationService.GoBackAsync();
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