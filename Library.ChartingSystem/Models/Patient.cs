using Library.ChartingSystem.Services;

namespace Library.ChartingSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Birthdate { get; set; }
        public string? Race { get; set; }
        public string? Gender { get; set; }
        public string? Diagnosis { get; set; }
        public string? Prescription { get; set; }

        public string Display
        {
            get
            {
                return ToString();
            }
        }

        public override string ToString()
        {
            return $"{Id}. {Name}: {Address}, {Birthdate}, {Race}, {Gender}, {Diagnosis}, {Prescription}";
        }

        public Patient() {}
        public Patient(int id)
        {
            var patientCopy = PatientServiceProxy.Current.Patients.FirstOrDefault(p => (p?.Id ?? 0) == id);

            if (patientCopy != null)
            {
                Id = patientCopy.Id;
                Name = patientCopy.Name;
                Address = patientCopy.Address;
                Birthdate = patientCopy.Birthdate;
                Race = patientCopy.Race;
                Gender = patientCopy.Gender;
                Diagnosis = patientCopy.Diagnosis;
                Prescription = patientCopy.Prescription;
            }
        }
    }
}