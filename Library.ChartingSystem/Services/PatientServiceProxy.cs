//using Library.ChartingSystem.Data;
//using Library.ChartingSystem.DTO;
//using Library.ChartingSystem.Utilities;
//using Newtonsoft.Json;
using System;
using System.ComponentModel;
using Library.ChartingSystem.Models;

//using System.Reflection.Metadata;

namespace Library.ChartingSystem.Services;

public class PatientServiceProxy
{
	private List<Patient?> allPatients;
	private PatientServiceProxy()	{
		allPatients = new List<Patient?>();
	}
	private static PatientServiceProxy? instance;
	public static PatientServiceProxy Current
	{
		get
		{
			if (instance == null)
			{
				instance = new PatientServiceProxy();
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
        allPatients.Add(patient);

        return patient;
    }

    public Patient? Delete(Patient? patient)
    {
        allPatients.Remove(patient);
        return patient;
    }
}
