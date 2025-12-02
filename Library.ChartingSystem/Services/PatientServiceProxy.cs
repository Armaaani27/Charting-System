//using Library.ChartingSystem.Data;
//using Library.ChartingSystem.DTO;
//using Library.ChartingSystem.Models;
//using Library.ChartingSystem.Utilities;
//using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Reflection.Metadata;

namespace Library.ChartingSystem.Services;

public class PatientServiceProxy
{
	private List<Patient?> Patients;
	private PatientServiceProxy()	{
		Patients = new List<Patient?>();
	}
	private static PatientServiceProxy? instance;
	public PatientServiceProxy Current
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
}
