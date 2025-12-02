using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ChartingSystem;

namespace MAUI.ChartingSystem.ViewModels
{
    public class PatientsViewModel
    {
        public List<Patient> Patients
        {
            get
            {
                return new List<Patient>
                {
                    new Patient { Name = "Patient1", Address = "123 Street", Birthdate = "Jan 1", Race = "Hispanic", Gender = "Male", Diagnosis = "Flu", Prescription = "tylenol" },
                    new Patient { Name = "Patient2", Address = "124 Street", Birthdate = "Jan 2", Race = "Asian", Gender = "Male", Diagnosis = "Insomnia", Prescription = "melatonin" },
                    new Patient { Name = "Patient3", Address = "125 Street", Birthdate = "Jan 3", Race = "White", Gender = "Female", Diagnosis = "Headache", Prescription = "advil" }
                };
            }
        }
        public Patient SelectedPatient { get; set; }
    }
}