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
    public class PatientsViewModel : INotifyPropertyChanged
    {
        public PatientsViewModel()
        {
            ImportPath = Path.Combine(FileSystem.AppDataDirectory, "patientsData.json");
        }
        private bool MatchesQuery(Patient? patient)
        {
            if (patient == null)
            {
                return false;
            }
            return (patient?.Name?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false) || (patient?.Address?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false) || (patient?.Birthdate?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false) || (patient?.Gender?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false) || (patient?.Race?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false) || (patient?.Diagnosis?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false) || (patient?.Prescription?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false);
        }
        
        public ObservableCollection<Patient?> Patients
        {
            get
            {
                return new ObservableCollection<Patient?>(PatientServiceProxy.Current.Patients.Where(MatchesQuery));
            }
        }
        
        public void Refresh()
        {
            NotifyPropertyChanged("Patients");
        }

        public void Export()
        {
            var patientString = JsonConvert.SerializeObject(Patients);
            
            using (StreamWriter sw = new StreamWriter(Path.Combine(FileSystem.AppDataDirectory, "patientsData.json")))
            {
                sw.WriteLine(patientString);
            }
        }

        public void Import()
        {
            using(StreamReader sr = new StreamReader(ImportPath))
            {
                var patientString = sr.ReadLine();
                if (string.IsNullOrEmpty(patientString))
                {
                    return;
                }
                var patients = JsonConvert.DeserializeObject<List<Patient>>(patientString);
            
                foreach(var patient in patients)
                {
                    patient.Id = 0;
                    PatientServiceProxy.Current.AddOrUpdate(patient);
                }
                NotifyPropertyChanged("Patients");
            }
        }
        public string ImportPath { get; set; }

        public Patient? SelectedPatient { get; set; }
        public string? Query { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Delete()
        {
            if (SelectedPatient == null)
            {
                return;
            }
            PatientServiceProxy.Current.Delete(SelectedPatient);
            NotifyPropertyChanged("Patients");
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}