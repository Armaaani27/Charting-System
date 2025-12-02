namespace Library.ChartingSystem
{
    public class Physician
    {
        public string? Name { get; set; }
        public string? LicenseNum { get; set; }
        public string? GradDate { get; set; }
        public string? Specializations { get; set; }

        public override string ToString()
        {
            return $"{Name}: {LicenseNum}, {GradDate}, {Specializations}";
        }
    }
}
