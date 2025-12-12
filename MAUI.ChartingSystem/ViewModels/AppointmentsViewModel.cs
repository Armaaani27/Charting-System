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

using Newtonsoft.Json;

namespace MAUI.ChartingSystem.ViewModels
{
    public class AppointmentsViewModel : INotifyPropertyChanged
    {
        public AppointmentsViewModel()
        {
            ImportPath = Path.Combine(FileSystem.AppDataDirectory, "appointmentsData.json");
        }

        // only allows searches for date and time; could update in the future to be able to search names of pats. and phys.?
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

        public void Export()
        {
            var appointmentString = JsonConvert.SerializeObject(Appointments);
            
            using (StreamWriter sw = new StreamWriter(Path.Combine(FileSystem.AppDataDirectory, "appointmentsData.json")))
            {
                sw.WriteLine(appointmentString);
            }
        }

        public void Import()
        {
            using(StreamReader sr = new StreamReader(ImportPath))
            {
                var appointmentString = sr.ReadLine();
                if (string.IsNullOrEmpty(appointmentString))
                {
                    return;
                }
                var appointments = JsonConvert.DeserializeObject<List<Appointment>>(appointmentString);
            
                foreach(var appointment in appointments)
                {
                    appointment.Id = 0;
                    AppointmentServiceProxy.Current.AddOrUpdate(appointment);
                }
                NotifyPropertyChanged("Appointments");
            }
        }
        public string ImportPath { get; set; }
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