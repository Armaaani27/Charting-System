using Library.ChartingSystem;
namespace CLI.ChartingSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Patient?> Patients = new List<Patient?>();
            List<Physician?> Physicians = new List<Physician?>();
            List<Appointment?> Appointments = new List<Appointment?>();
            bool quit = false;

            do
            {
                Console.WriteLine("1. Add a Patient");
                Console.WriteLine("2. List All Patients");
                Console.WriteLine("3. Add a Physician");
                Console.WriteLine("4. List All Physicians");
                Console.WriteLine("5. Add an Appointment");
                Console.WriteLine("6. List All Appointments");
                Console.WriteLine("7. Quit");

                var userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        // read in all patient information
                        var patient = new Patient();
                        patient.Name = Console.ReadLine();
                        patient.Address = Console.ReadLine();
                        patient.Birthdate = Console.ReadLine();
                        patient.Race = Console.ReadLine();
                        patient.Gender = Console.ReadLine();
                        patient.Diagnosis = Console.ReadLine();
                        patient.Prescription = Console.ReadLine();
                        Patients.Add(patient);
                        break;
                    case "2":
                        foreach (var a in Patients)
                        {
                            Console.WriteLine(a);
                        }
                        break;
                    case "3":
                        var phys = new Physician();
                        phys.Name = Console.ReadLine();
                        phys.LicenseNum = Console.ReadLine();
                        phys.GradDate = Console.ReadLine();
                        phys.Specializations = Console.ReadLine();
                        Physicians.Add(phys);
                        break;
                    case "4":
                        foreach (var p in Physicians)
                        {
                            Console.WriteLine(p);
                        }
                        break;
                    case "5":
                        var app = new Appointment();
                        var invalidity = false;
                        var patMatch = false;
                        var physMatch = false;

                        // user is given a list of patients to choose from
                        // potential weakness: may cause some confusion if two patients have identical names
                        Console.WriteLine("Select a patient. (Enter their name)");
                        foreach (var a in Patients)
                        {
                            Console.WriteLine(a);
                        }
                        var tempPat = Console.ReadLine();
                        foreach (var a in Patients)
                        {
                            if (a.Name == tempPat)
                            {
                                patMatch = true;
                            }
                        }

                        // user is given a list of physicians to choose from
                        // potential weakness: may cause some confusion if two physicians have identical names
                        Console.WriteLine("Select a physician. (Enter their name)");
                        foreach (var p in Physicians)
                        {
                            Console.WriteLine(p);
                        }
                        var tempPhys = Console.ReadLine();
                        foreach (var a in Physicians)
                        {
                            if (a.Name == tempPhys)
                            {
                                physMatch = true;
                            }
                        }

                        Console.WriteLine("Enter desired date.");
                        var tempDate = Console.ReadLine();

                        Console.WriteLine("Enter desired time.");
                        var tempTime = Console.ReadLine();

                        // validity checks
                        if (patMatch == false)
                        {
                            Console.WriteLine("This patient does not exist in the database. Please add the patient and try again.");
                            invalidity = true;
                        }
                        if (physMatch == false)
                        {
                            Console.WriteLine("This physician does not exist in the database. Please add the physician and try again.");
                            invalidity = true;
                        }
                        if (tempDate != "Monday" && tempDate != "Tuesday" && tempDate != "Wednesday" && tempDate != "Thursday" && tempDate != "Friday")
                        {
                            Console.WriteLine("Invalid date. Please try again.");
                            invalidity = true;
                        }
                        if (tempTime != "8AM" && tempTime != "9AM" && tempTime != "10AM" && tempTime != "11AM" && tempTime != "12PM" && tempTime != "1PM" && tempTime != "2PM" && tempTime != "3PM" && tempTime != "4PM" && tempTime != "5PM")
                        {
                            Console.WriteLine("Invalid time. Please try again.");
                            invalidity = true;
                        }
                        foreach (var a in Appointments)
                        {
                            if (a.PhysName == tempPhys && a.Date == tempDate && a.Time == tempTime)
                            {
                                Console.WriteLine("This physician is already booked for the selected date & time. Please try again.");
                                invalidity = true;
                            }
                        }
                        if (invalidity == false)
                        {
                            app.PatName = tempPat;
                            app.PhysName = tempPhys;
                            app.Date = tempDate;
                            app.Time = tempTime;
                            Appointments.Add(app);
                        }
                        break;
                    case "6":
                        foreach (var a in Appointments)
                        {
                            Console.WriteLine(a);
                        }
                        break;
                    case "7":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            } while (quit == false);
        }
    }
}