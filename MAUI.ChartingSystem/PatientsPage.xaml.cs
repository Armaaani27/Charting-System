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
        Shell.Current.GoToAsync("//Patient");
    }

    private void EditClicked(object sender, EventArgs e)
    {
        
    }
}