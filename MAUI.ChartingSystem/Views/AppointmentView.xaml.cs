using Library.ChartingSystem.Models;
using Library.ChartingSystem.Services;

namespace MAUI.ChartingSystem.Views;

[QueryProperty(nameof(AppointmentId), "appointmentId")]
public partial class AppointmentView : ContentPage
{
	public int AppointmentId { get; set; }

	public AppointmentView()
	{
		InitializeComponent();
	}

	private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AppointmentsPage");
    }

	private void OkClicked(object sender, EventArgs e)
    {
		AppointmentServiceProxy.Current.AddOrUpdate(BindingContext as Appointment);

		Shell.Current.GoToAsync("//AppointmentsPage");
    }

	private void AppointmentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
		if (AppointmentId == 0)
        {
            BindingContext = new Appointment();
        }
		else
        {
            BindingContext = new Appointment(AppointmentId);
		}
    }
}