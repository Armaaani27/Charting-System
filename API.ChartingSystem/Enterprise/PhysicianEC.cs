namespace API.ChartingSystem.Enterprise
{
    public class PhysicianEC
    {
        public IEnumerable<Physician> GetPhysicians()
        {
            return FakeDatabase.Physicians;
        }
        public Physician? GetById(int id)
        {
            return FakeDatabase.Physicians.FirstOrDefault(p => p.Id == id);
        }
        public Physician? Delete(int id)
        {
            var toRemove = GetById(id);
            if (toRemove != null)
            {
                FakeDatabase.Physicians.Remove(toRemove);
            }
            return toRemove;
        }
    }
}