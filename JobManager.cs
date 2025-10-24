


using System;
using static Assignment1OOP.JobApplication;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment1OOP
{
    public class JobManager
    {
        // Skapar en lista för att lagra alla jobbansökningar
        public List<JobApplication> applications = new List<JobApplication>();

        // 1. Lägg till en ny ansökan 
        public void AddJob()
        {
            // Frågar efter företagsnamn
            Console.Write("Företag: ");
            string companyName = Console.ReadLine();

            // Frågar efter position/tjänst
            Console.Write("Position: ");
            string positionTitle = Console.ReadLine();

            Console.WriteLine("Status (0: Applied, 1: Interviewing, 2: Offer, 3: Rejected)");
            int jobStatus = int.Parse(Console.ReadLine());
            ApplicationStatus status = (ApplicationStatus)jobStatus;
            
            Console.WriteLine("Application Date (yyyy-mm-dd)");
            DateTime applicationDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Response Date (yyyy-mm-dd) or leave blank");
            DateTime responseDateInput = Convert.ToDateTime(Console.ReadLine());

            // Frågar efter löneförväntan
            Console.Write("Löneförväntan (USD): ");
            int salaryExpectation = Convert.ToInt32(Console.ReadLine());

            // Skapar ett nytt JobApplication-objekt med aktuell tid som ansökningsdatum
            // och lägger till det i listan
    
            

            // Bekräftar för användaren att ansökan har lagts till
            Console.WriteLine("Ansökan tillagd!");


            JobApplication jobApp = new JobApplication
            {
                CompanyName = companyName,
                PositionTitle = positionTitle,
                Status = status,
                ApplicationDate = applicationDate,
                SalaryExpectation = salaryExpectation,
                ResponseDate = responseDateInput,
            };
                applications.Add(jobApp);
        }
        // 2. Visa alla ansökningar
        public void ShowAll()
        {
            // Kollar om det finns några ansökningar
            if (applications.Count == 0)
            {
                Console.WriteLine("Inga ansökningar hittades.");
            }
            else
            {
                // Skriver ut alla ansökningar genom att anropa en metod i varje objekt
                Console.WriteLine("Alla ansökningar:");
                foreach (var app in applications)
                    Console.WriteLine(app.GetSummery());
            }
        }
        // 3. Filtrera ansökningar efter status
        public void ShowByStatus()
        {
            Console.Write("Filter by status (1=Applied, 2=Interview, 3=Offer, 4=Rejected): ");
            int num = Convert.ToInt32(Console.ReadLine());
            ApplicationStatus status = (ApplicationStatus)num;

            var filtered = applications.Where(a => a.Status == status);

            if (!filtered.Any())
            {
                Console.WriteLine($"No applications with status {status}");
            }
            else
            {
                foreach (var a in filtered)
                {

                    Console.WriteLine(a.GetSummery());
                }
            }
        }
        // 4. Sortera ansökningar efter datum 
        public void ShowByDate()
        {
            // Använder LINQ för att sortera listan efter ApplicationDate
            var sorted = applications.OrderBy(a => a.ApplicationDate);

            Console.WriteLine("Ansökningar sorterade efter datum:");
            foreach (var app in sorted)
                Console.WriteLine(app.GetSummery());

        }

        // 5. Uppdatera ansökningsstatus 
        public void UpdateStatus(string companyName, ApplicationStatus newStatus, DateTime? responseDate = null)
        {
            // Hitta första ansökan som matchar företagsnamnet
            var job = applications.FirstOrDefault(a => a.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase));

            if (job == null)
            {
                Console.WriteLine("Company not found.");
                return;
            }

            job.Status = newStatus;
            job.ResponseDate = responseDate;

            Console.WriteLine($"Status updated for {job.CompanyName} to {job.Status}.");
        }

        // 6. Ta bort en ansökan 
        public void DeleteJob() 
        {
            // Frågar vilket företag som ska tas bort
            Console.Write("Ange företagsnamn att ta bort: ");
            string nameToDelete = Console.ReadLine();

            // Hittar rätt objekt
            var toDelete = applications.FirstOrDefault(a => a.CompanyName.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

            if (toDelete != null)
            {
                // Tar bort ansökan från listan
                applications.Remove(toDelete);
                Console.WriteLine("Ansökan borttagen!");
            }
            else
            {
                Console.WriteLine("Ingen ansökan hittades.");
            }
        }

       
    }
    }

