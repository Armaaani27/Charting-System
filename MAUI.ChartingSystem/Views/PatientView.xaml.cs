using Library.ChartingSystem.Models;
using Library.ChartingSystem.Services;

namespace MAUI.ChartingSystem.Views;

[QueryProperty(nameof(PatientId), "patientId")]
public partial class PatientView : ContentPage
{
	public int PatientId { get; set; }

	public PatientView()
	{
		InitializeComponent();
	}

	private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PatientsPage");
    }

	private void OkClicked(object sender, EventArgs e)
    {
		PatientServiceProxy.Current.AddOrUpdate(BindingContext as Patient);

		Shell.Current.GoToAsync("//PatientsPage");
    }

	private void PatientPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
		if (PatientId == 0)
        {
            BindingContext = new Patient();
        }
		else
        {
            BindingContext = new Patient(PatientId);
		}
    }
}