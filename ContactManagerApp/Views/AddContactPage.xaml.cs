using ContactManagerApp.ViewModels;

namespace ContactManagerApp.Views;

public partial class AddContactPage : ContentPage
{
    public AddContactPage(AddContactViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}