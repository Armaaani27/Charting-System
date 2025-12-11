namespace ChartingSystem;
using MAUI.ChartingSystem.ViewModels;

public partial class AppointmentsPage : ContentPage
{
	public AppointmentsPage()
	{
		InitializeComponent();
		BindingContext = new AppointmentsViewModel();
	}

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Appointment?appointmentId=0");
    }

    private void EditClicked(object sender, EventArgs e)
    {
        var selectedId = (BindingContext as AppointmentsViewModel)?.SelectedAppointment?.Id ?? 0;
        Shell.Current.GoToAsync($"//Appointment?appointmentId={selectedId}");
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as AppointmentsViewModel)?.Delete();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as AppointmentsViewModel)?.Refresh();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as AppointmentsViewModel)?.Refresh();
    }
}