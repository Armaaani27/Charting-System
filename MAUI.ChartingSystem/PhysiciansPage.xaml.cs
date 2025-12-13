namespace ChartingSystem;
using MAUI.ChartingSystem.ViewModels;
using Library.ChartingSystem.Services;

public partial class PhysiciansPage : ContentPage
{
	public PhysiciansPage()
	{
		InitializeComponent();
		BindingContext = new PhysiciansViewModel();
	}

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Physician?physicianId=0");
    }

    private void EditClicked(object sender, EventArgs e)
    {
        var selectedId = (BindingContext as PhysiciansViewModel)?.SelectedPhysician?.Id ?? 0;
        Shell.Current.GoToAsync($"//Physician?physicianId={selectedId}");
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as PhysiciansViewModel)?.Delete();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as PhysiciansViewModel)?.Refresh();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as PhysiciansViewModel)?.Refresh();
    }

    private void ExportClicked(object sender, EventArgs e)
    {
        (BindingContext as PhysiciansViewModel)?.Export();
    }

    private void ImportClicked(object sender, EventArgs e)
    {
        (BindingContext as PhysiciansViewModel)?.Import();
    }
}