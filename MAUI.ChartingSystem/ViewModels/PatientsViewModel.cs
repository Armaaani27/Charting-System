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
    public class PatientsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Patient?> Patients
        {
            get
            {
                return new ObservableCollection<Patient?>(PatientServiceProxy.Current.Patients);
            }
        }
        
        public void Refresh()
        {
            NotifyPropertyChanged("Patients");
        }
        public Patient? SelectedPatient { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}