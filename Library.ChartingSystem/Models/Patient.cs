namespace Library.ChartingSystem
{
    public class Patient
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Birthdate { get; set; }
        public string? Race { get; set; }
        public string? Gender { get; set; }
        public string? Diagnosis { get; set; }
        public string? Prescription { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Address}, {Birthdate}, {Race}, {Gender}, {Diagnosis}, {Prescription}";
        }
    }
}