using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Library.ChartingSystem.Models;
using Library.ChartingSystem.Services;

namespace MAUI.ChartingSystem.ViewModels
{
    public class AppointmentsViewModel : INotifyPropertyChanged
    {
        // only allows searches for date and time; could update in the future to be able to search names of patients and physicians?
        private bool MatchesQuery(Appointment? appointment)
        {
            if (appointment == null)
            {
                return false;
            }
            return (appointment?.Date?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false) || (appointment?.Time?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false);
        }
        
        public ObservableCollection<Appointment?> Appointments
        {
            get
            {
                return new ObservableCollection<Appointment?>(AppointmentServiceProxy.Current.Appointments.Where(MatchesQuery));
            }
        }
        
        public void Refresh()
        {
            NotifyPropertyChanged("Appointments");
        }
        public Appointment? SelectedAppointment { get; set; }
        public string? Query { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Delete()
        {
            if (SelectedAppointment == null)
            {
                return;
            }
            AppointmentServiceProxy.Current.Delete(SelectedAppointment);
            NotifyPropertyChanged("Appointments");
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}