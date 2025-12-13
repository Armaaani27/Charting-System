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
    public class PhysiciansViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Physician?> _physicians;

        public PhysiciansViewModel()
        {
            ImportPath = Path.Combine(FileSystem.AppDataDirectory, "physiciansData.json");
            _physicians = PhysicianServiceProxy.Current.Physicians;
            Refresh();
        }
        
        private bool MatchesQuery(Physician? physician)
        {
            if (physician == null)
            {
                return false;
            }
            return (physician?.Name?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false)
                || (physician?.LicenseNum?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false)
                || (physician?.GradDate?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false)
                || (physician?.Specializations?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false);
        }
        
        public ObservableCollection<Physician?> Physicians
        {
            get
            {
                return _physicians;
            }
        }
        
        public void Refresh()
        {
            NotifyPropertyChanged("Physicians");
        }

        public void Export()
        {
            var physicianString = JsonConvert.SerializeObject(Physicians);
            
            using (StreamWriter sw = new StreamWriter(Path.Combine(FileSystem.AppDataDirectory, "physiciansData.json")))
            {
                sw.WriteLine(physicianString);
            }
        }

        public void Import()
        {
            using(StreamReader sr = new StreamReader(ImportPath))
            {
                var physicianString = sr.ReadLine();
                if (string.IsNullOrEmpty(physicianString))
                {
                    return;
                }
                var physicians = JsonConvert.DeserializeObject<List<Physician>>(physicianString);
            
                foreach(var physician in physicians)
                {
                    physician.Id = 0;
                    PhysicianServiceProxy.Current.AddOrUpdate(physician);
                }
                NotifyPropertyChanged("Physicians");
            }
        }

        public string ImportPath { get; set; }
        public Physician? SelectedPhysician { get; set; }
        public string? Query { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Delete()
        {
            if (SelectedPhysician == null)
            {
                return;
            }
            PhysicianServiceProxy.Current.Delete(SelectedPhysician);
            Refresh();
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}