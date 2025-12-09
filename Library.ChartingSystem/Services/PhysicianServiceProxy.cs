//using Library.ChartingSystem.Data;
//using Library.ChartingSystem.DTO;
//using Library.ChartingSystem.Utilities;
//using Newtonsoft.Json;
using System;
using System.ComponentModel;
using Library.ChartingSystem.Models;

//using System.Reflection.Metadata;

namespace Library.ChartingSystem.Services;

public class PhysicianServiceProxy
{
	private List<Physician?> allPhysicians { get; set; }
	public PhysicianServiceProxy()	{
		allPhysicians = new List<Physician?>();
	}
	private static PhysicianServiceProxy? instance;
    private static object instanceLock = new object();
	public static PhysicianServiceProxy Current
	{
		get
		{
            lock(instanceLock)
            {
                if (instance == null)
                {
                    instance = new PhysicianServiceProxy();
                }
            }
			return instance;
		}
    }
    public List<Physician?> Physicians
    {
        get
        {
            return allPhysicians;
        }
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
            if (allPhysicians.Any())
            {
                maxId = allPhysicians.Select(p => p?.Id ?? -1).Max();
            }
            else
            {
                maxId = 0;
            }
            physician.Id = ++maxId;
            allPhysicians.Add(physician);
        }
        else
        {
            var physicianToEdit = Physicians.FirstOrDefault(p => (p?.Id ?? 0) == physician.Id);
            if (physicianToEdit != null)
            {
                var index = Physicians.IndexOf(physicianToEdit);
                Physicians.RemoveAt(index);
                allPhysicians.Insert(index, physician);
            }
        }
        return physician;
    }

    public Physician? Delete(Physician? physician)
    {
        var physicianToDelete = allPhysicians.Where(p => p != null).FirstOrDefault(p => p?.Id == physician.Id);
        allPhysicians.Remove(physicianToDelete);
        return physicianToDelete;
    }
}