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
        public ObservableCollection<Appointment?> Appointments
        {
            get
            {
                return new ObservableCollection<Appointment?>(AppointmentServiceProxy.Current.Appointments);
            }
        }
        
        public void Refresh()
        {
            NotifyPropertyChanged("Appointments");
        }
        public Appointment? SelectedAppointment { get; set; }

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