using Library.ChartingSystem.Services;

namespace Library.ChartingSystem.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        
        public Physician? Physician { get; set; }
        public int PhysId { get; set; }

        public Patient? Patient { get; set; }
        public int PatId { get; set; }

        public string? Date { get; set; }
        public string? Time { get; set; }

        public string Display
        {
            get
            {
                return ToString();
            }
        }

        public override string ToString()
        {
            return $"{Id}. {Patient.Name} will see {Physician.Name} on {Date} at {Time}";
        }

        public Appointment() {}
        public Appointment(int id)
        {
            var appointmentCopy = AppointmentServiceProxy.Current.Appointments.FirstOrDefault(p => (p?.Id ?? 0) == id);

            if (appointmentCopy != null)
            {
                Id = appointmentCopy.Id;
                PhysId = appointmentCopy.PhysId;
                PatId = appointmentCopy.PatId;
                Date = appointmentCopy.Date;
                Time = appointmentCopy.Time;
            }
        }
    }
}