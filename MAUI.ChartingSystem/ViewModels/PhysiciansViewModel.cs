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
    public class PhysiciansViewModel : INotifyPropertyChanged
    {
        private bool MatchesQuery(Physician? physician)
        {
            if (physician == null)
            {
                return false;
            }
            return (physician?.Name?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false) || (physician?.LicenseNum?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false) || (physician?.GradDate?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false) || (physician?.Specializations?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false);
        }
        
        public ObservableCollection<Physician?> Physicians
        {
            get
            {
                return new ObservableCollection<Physician?>(PhysicianServiceProxy.Current.Physicians.Where(MatchesQuery));
            }
        }
        
        public void Refresh()
        {
            NotifyPropertyChanged("Physicians");
        }
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
            NotifyPropertyChanged("Physicians");
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}