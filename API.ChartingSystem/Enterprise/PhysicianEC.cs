using Library.ChartingSystem.Models;
using API.ChartingSystem.Database;

namespace API.ChartingSystem.Enterprise
{
    public class PhysicianEC
    {
        public IEnumerable<Physician> GetPhysicians()
        {
            return Filebase.Current.Physicians.OrderByDescending(p => p.Id).Take(100);
        }
        public Physician? GetById(int id)
        {
            return Filebase.Current.Physicians.FirstOrDefault(p => p.Id == id);
        }
        public Physician? Delete(int id)
        {
            var toRemove = GetById(id);
            if (toRemove != null)
            {
                Filebase.Current.Delete(toRemove.Id);
            }
            return toRemove;
        }

        public Physician? AddOrUpdate(Physician? physician)
        {
            if (physician == null)
            {
                return null;
            }
            if (physician.Id <= 0)
            {
                var maxId = -1;
                if (Filebase.Current.Physicians.Any())
                {
                    maxId = Filebase.Current.Physicians.Select(p => p?.Id ?? -1).Max();
                }
                else
                {
                    maxId = 0;
                }
                physician.Id = ++maxId;
                Filebase.Current.Physicians.Add(physician);
            }
            else
            {
                var physicianToEdit = Filebase.Current.Physicians.FirstOrDefault(p => (p?.Id ?? 0) == physician.Id);
                if (physicianToEdit != null)
                {
                    var index = Filebase.Current.Physicians.IndexOf(physicianToEdit);
                    Filebase.Current.Physicians.RemoveAt(index);
                    Filebase.Current.Physicians.Insert(index, physician);
                }
            }
            /*
            var phys = new Physician(physician);
            physician = new Physician(Filebase.Current.AddOrUpdate(phys));
            return physician;
            */
            return Filebase.Current.AddOrUpdate(physician);
        }

        public IEnumerable<Physician?> Search(string query)
        {
            return Filebase.Current.Physicians.Where(physician => (physician?.Name?.ToUpper()?.Contains(query?.ToUpper() ?? string.Empty) ?? false) || (physician?.LicenseNum?.ToUpper()?.Contains(query?.ToUpper() ?? string.Empty) ?? false) || (physician?.GradDate?.ToUpper()?.Contains(query?.ToUpper() ?? string.Empty) ?? false) || (physician?.Specializations?.ToUpper()?.Contains(query?.ToUpper() ?? string.Empty) ?? false));
        }
    }
}