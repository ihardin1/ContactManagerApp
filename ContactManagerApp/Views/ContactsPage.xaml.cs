using ContactManagerApp.ViewModels;

namespace ContactManagerApp.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage(ContactsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}