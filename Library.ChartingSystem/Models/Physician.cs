using Library.ChartingSystem.Services;

namespace Library.ChartingSystem.Models
{
    public class Physician
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LicenseNum { get; set; }
        public string? GradDate { get; set; }
        public string? Specializations { get; set; }

        public string Display
        {
            get
            {
                return ToString();
            }
        }

        public override string ToString()
        {
            return $"{Id}. {Name}: {LicenseNum}, {GradDate}, {Specializations}";
        }

        public Physician()
        {

        }
        public Physician(int id)
        {
            var physicianCopy = PhysicianServiceProxy.Current.Physicians.FirstOrDefault(p => (p?.Id ?? 0) == id);

            if (physicianCopy != null)
            {
                Id = physicianCopy.Id;
                Name = physicianCopy.Name;
                LicenseNum = physicianCopy.LicenseNum;
                GradDate = physicianCopy.GradDate;
                Specializations = physicianCopy.Specializations;
            }
        }
    }
}
