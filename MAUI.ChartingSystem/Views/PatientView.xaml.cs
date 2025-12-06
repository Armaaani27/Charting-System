using Library.ChartingSystem.Models;
using Library.ChartingSystem.Services;

namespace MAUI.ChartingSystem.Views;

public partial class PatientView : ContentPage
{
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
        // must call here instead of in PatientView() because we want to be able to create a new item every time the page is navigated to rather than only when it is initialized
		BindingContext = new Patient();
    }
}