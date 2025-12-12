using Library.ChartingSystem.Models;

namespace API.ChartingSystem.Database
{
    public static class FakeDatabase
    {
        public static List<Physician> Physicians = new List<Physician>
        {
            new Physician{Name = "Edelstein", LicenseNum="12345", Id=1},
            new Physician{Name = "John Pork", LicenseNum="56789", Id=2},
            new Physician{Name = "Johnny Sins", LicenseNum="24680", Id=3}
        };
    }
}