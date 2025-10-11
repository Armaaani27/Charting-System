namespace Library.ChartingSystem
{
    public class Appointment
    {
        public string? Date { get; set; }
        public string? Time { get; set; }
        public string? PhysName { get; set; }
        public string? PatName { get; set; }

        public override string ToString()
        {
            return $"{PatName} will see {PhysName} on {Date} at {Time}";
        }
    }
}