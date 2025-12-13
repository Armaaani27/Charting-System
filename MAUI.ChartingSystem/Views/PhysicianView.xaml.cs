using Library.ChartingSystem.Models;
using Library.ChartingSystem.Services;

namespace MAUI.ChartingSystem.Views;

[QueryProperty(nameof(PhysicianId), "physicianId")]
public partial class PhysicianView : ContentPage
{
	public int PhysicianId { get; set; }

	public PhysicianView()
	{
		InitializeComponent();
	}

	private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PhysiciansPage");
    }

	private async void OkClicked(object sender, EventArgs e)
    {
		try
        {
            await PhysicianServiceProxy.Current.AddOrUpdate(BindingContext as Physician);
        } catch(Exception ex)
        {
            return;
        }
		
		PhysicianServiceProxy.Current.AddOrUpdate(BindingContext as Physician);

		Shell.Current.GoToAsync("//PhysiciansPage");
    }

	private void PhysicianPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
		if (PhysicianId == 0)
        {
            BindingContext = new Physician();
        }
		else
        {
            BindingContext = new Physician(PhysicianId);
		}
    }
}