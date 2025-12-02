namespace ChartingSystem;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		//BindingContext = this;
	}

	private async void OnPatientsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///PatientsPage");
    }
}
