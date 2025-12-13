using System;
using System.ComponentModel;
using Library.ChartingSystem.Models;

namespace Library.ChartingSystem.Services;

public class PatientServiceProxy
{
	public List<Patient?> allPatients { get; set; }
	private PatientServiceProxy()	{
		allPatients = new List<Patient?>();
	}
	private static PatientServiceProxy? instance;
    private static object instanceLock = new object();
	public static PatientServiceProxy Current
	{
		get
		{
            lock(instanceLock)
            {
                if (instance == null)
                {
                    instance = new PatientServiceProxy();
                }
            }
			return instance;
		}
    }
    public List<Patient?> Patients
    {
        get
        {
            return allPatients;
        }
    }

    public Patient? AddOrUpdate(Patient? patient)
    {
        if (patient == null)
        {
            return null;
        }
        if (patient.Id <= 0)
        {
            var maxId = -1;
            if (allPatients.Any())
            {
                maxId = allPatients.Select(p => p?.Id ?? -1).Max();
            }
            else
            {
                maxId = 0;
            }
            patient.Id = ++maxId;
            allPatients.Add(patient);
        }
        else
        {
            var patientToEdit = Patients.FirstOrDefault(p => (p?.Id ?? 0) == patient.Id);
            if (patientToEdit != null)
            {
                var index = Patients.IndexOf(patientToEdit);
                Patients.RemoveAt(index);
                allPatients.Insert(index, patient);
            }
        }
        return patient;
    }

    public Patient? Delete(Patient? patient)
    {
        var patientToDelete = allPatients.Where(p => p != null).FirstOrDefault(p => p?.Id == patient.Id);
        allPatients.Remove(patientToDelete);
        return patientToDelete;
    }
}
