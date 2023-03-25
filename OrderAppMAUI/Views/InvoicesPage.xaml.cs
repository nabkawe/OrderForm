namespace OrderAppMAUI.Views;
public partial class InvoicesPage : ContentPage
{
    readonly SampleDataService dataService;
    private ObservableCollection<Invoice> Items { get; set; }

    public InvoicesPage(SampleDataService service)
    {
        InitializeComponent();

        dataService = service;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        await LoadDataAsync();
    }
    private async void OnRefreshing(object sender, EventArgs e)
    {
        refreshview.IsRefreshing = true;

        try
        {
            await LoadDataAsync();
        }
        finally
        {
            refreshview.IsRefreshing = false;
        }
    }

    private async Task LoadDataAsync()
    {
        Items = new ObservableCollection<Invoice>(await dataService.GetItems());

        collectionview.ItemsSource = Items;
    }

    private async void ItemTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(InvoicesDetailPage), true, new Dictionary<string, object>
        {
            { "Item", (sender as BindableObject).BindingContext as SampleItem }
        });
    }
}
