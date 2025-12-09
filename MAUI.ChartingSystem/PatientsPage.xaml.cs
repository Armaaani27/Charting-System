namespace ChartingSystem;
using MAUI.ChartingSystem.ViewModels;

public partial class PatientsPage : ContentPage
{
	public PatientsPage()
	{
		InitializeComponent();
		BindingContext = new PatientsViewModel();
	}

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Patient?patientId=0");
    }

    private void EditClicked(object sender, EventArgs e)
    {
        var selectedId = (BindingContext as PatientsViewModel)?.SelectedPatient?.Id ?? 0;
        Shell.Current.GoToAsync($"//Patient?patientId={selectedId}");
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as PatientsViewModel)?.Delete();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as PatientsViewModel)?.Refresh();
    }
}