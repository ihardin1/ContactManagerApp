using CommunityToolkit.Mvvm.ComponentModel;

namespace ContactManagerApp.Models;

public partial class ContactInfo : ObservableObject
{
    [ObservableProperty]
    private string name = string.Empty;

    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private string phoneNumber = string.Empty;

    [ObservableProperty]
    private string description = string.Empty;
}