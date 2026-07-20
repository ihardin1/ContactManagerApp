using ContactManagerApp.Views;

namespace ContactManagerApp;

public partial class App : Application
{
    private readonly AddContactPage addContactPage;

    public App(AddContactPage addContactPage)
    {
        InitializeComponent();
        this.addContactPage = addContactPage;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        NavigationPage navigationPage = new(addContactPage);

        return new Window(navigationPage);
    }
}