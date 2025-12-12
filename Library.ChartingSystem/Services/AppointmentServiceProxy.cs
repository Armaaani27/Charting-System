//using Library.ChartingSystem.Data;
//using Library.ChartingSystem.DTO;
//using Library.ChartingSystem.Utilities;
//using Newtonsoft.Json;
using System;
using System.ComponentModel;
using Library.ChartingSystem.Models;

//using System.Reflection.Metadata;

namespace Library.ChartingSystem.Services;

public class AppointmentServiceProxy
{
	public List<Appointment?> allAppointments;

    private PatientServiceProxy patientSvc;
    private PhysicianServiceProxy physicianSvc;
	private AppointmentServiceProxy()
    {
		patientSvc = PatientServiceProxy.Current;
        physicianSvc = PhysicianServiceProxy.Current;
        allAppointments = new List<Appointment?>();
	}
	private static AppointmentServiceProxy? instance;
    private static object instanceLock = new object();
	public static AppointmentServiceProxy Current
	{
		get
		{
            lock(instanceLock)
            {
                if (instance == null)
                {
                    instance = new AppointmentServiceProxy();
                }
            }
			return instance;
		}
    }
    public List<Appointment?> Appointments
    {
        get
        {
            return allAppointments;
        }
    }

    public Appointment? AddOrUpdate(Appointment? appointment)
    {
        if (appointment == null)
        {
            return null;
        }

        // PROBLEM: What if user enters a patient or physician ID that does not exist in the patient or physician lists?
        int count1 = 0;
        int count2 = 0;

        foreach (var a in patientSvc.Patients)
        {
            if (appointment.PatId == a.Id)
            {
                count1++;
            }
        }
        if (count1 < 1)
        {
            return null;
        }

        foreach (var a in physicianSvc.Physicians)
        {
            if (appointment.PhysId == a.Id)
            {
                count2++;
            }
        }
        if (count2 < 1)
        {
            return null;
        }

        // this loop ensures that physicians are not double-booked (could maybe be improved to have a dropdown of selectable dates/times? Picker feature?)
        foreach (var a in allAppointments)
        {
            if (a.PhysId == appointment.PhysId && a.Date == appointment.Date && a.Time == appointment.Time)
            {
                return null;
            }
        }

        appointment.Patient = patientSvc.Patients.FirstOrDefault(p => p.Id == appointment.PatId);
        appointment.Physician = physicianSvc.Physicians.FirstOrDefault(p => p.Id == appointment.PhysId);

        if (appointment.Id <= 0)
        {
            var maxId = -1;
            if (allAppointments.Any())
            {
                maxId = allAppointments.Select(p => p?.Id ?? -1).Max();
            }
            else
            {
                maxId = 0;
            }
            appointment.Id = ++maxId;
            allAppointments.Add(appointment);
        }
        else
        {
            var appointmentToEdit = Appointments.FirstOrDefault(p => (p?.Id ?? 0) == appointment.Id);
            if (appointmentToEdit != null)
            {
                var index = Appointments.IndexOf(appointmentToEdit);
                Appointments.RemoveAt(index);
                allAppointments.Insert(index, appointment);
            }
        }


        return appointment;
    }

    public Appointment? Delete(Appointment? appointment)
    {
        var appointmentToDelete = allAppointments.Where(p => p != null).FirstOrDefault(p => p?.Id == appointment.Id);
        allAppointments.Remove(appointmentToDelete);
        return appointmentToDelete;
    }
}