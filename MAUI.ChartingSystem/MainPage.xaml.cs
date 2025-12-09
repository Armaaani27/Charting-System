namespace ChartingSystem;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnPatientsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///PatientsPage");
    }

	private async void OnPhysiciansClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///PhysiciansPage");
    }

	private async void OnAppointmentsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///AppointmentsPage");
    }
}
