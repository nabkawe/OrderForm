namespace OrderAppMAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(InvoicesDetailPage), typeof(InvoicesDetailPage));
	}
}
