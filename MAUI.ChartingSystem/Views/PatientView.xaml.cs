using Library.ChartingSystem.Models;
using Library.ChartingSystem.Services;

namespace MAUI.ChartingSystem.Views;

public partial class PatientView : ContentPage
{
	public PatientView()
	{
		InitializeComponent();
		BindingContext = new Patient();
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
}