using static Assignment1OOP.JobApplication;

namespace Assignment1OOP
{
   
   

namespace JobbAnsokningar
    {

        internal class Program
        {
            static void Main(string[] args)
            {
                // Skapar en lista för att lagra alla jobbansökningar
                List<JobApplication> applications = new List<JobApplication>();

                // Boolesk variabel som styr huvudloopen (true = programmet körs)
                bool running = true;

                // Huvudmeny-loop — fortsätter tills användaren väljer att avsluta
                while (running)
                {
                    // Skriver ut huvudmenyn till konsolen
                    Console.WriteLine("----- Jobbansökningar -----");
                    Console.WriteLine("1. Lägg till en ny ansökan");
                    Console.WriteLine("2. Visa alla ansökningar");
                    Console.WriteLine("3. Filtrera ansökningar efter status");
                    Console.WriteLine("4. Sortera ansökningar efter datum");
                    Console.WriteLine("5. Uppdatera ansökningsstatus");
                    Console.WriteLine("6. Ta bort ansökan");
                    Console.WriteLine("7. Avsluta");

                    // Ber användaren välja ett alternativ
                    Console.Write("Välj ett alternativ (1-7): ");

                    // Läser in användarens menyval
                    switch (Console.ReadLine())
                    {
                        // 1. Lägg till en ny ansökan 
                        case "1":
                            // Frågar efter företagsnamn
                            Console.Write("Företag: ");
                            string companyName = Console.ReadLine();

                            // Frågar efter position/tjänst
                            Console.Write("Position: ");
                            string positionTitle = Console.ReadLine();

                            // Frågar efter löneförväntan
                            Console.Write("Löneförväntan (kr): ");
                            int salaryExpectation = Convert.ToInt32(Console.ReadLine());

                            // Skapar ett nytt JobApplication-objekt med aktuell tid som ansökningsdatum
                            // och lägger till det i listan
                            var job = new JobApplication(companyName, positionTitle, DateTime.Now, null, salaryExpectation);
                            applications.Add(job);

                            // Bekräftar för användaren att ansökan har lagts till
                            Console.WriteLine("Ansökan tillagd!");
                            break;

                        // 2. Visa alla ansökningar
                        case "2":
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
                            break;

                        // 3. Filtrera ansökningar efter status
                        case "3":
                            // Frågar användaren vilken status de vill filtrera på
                            Console.WriteLine("Ange status att filtrera efter (Applied, Interviewing, Offered, Rejected): ");
                            string input = Console.ReadLine();

                            // Försöker omvandla textinmatningen till en giltig ApplicationStatus-enum
                            if (Enum.TryParse(input, true, out ApplicationStatus chosenStatus))
                            {
                                // Filtrerar listan med hjälp av LINQ — tar bara med de som matchar statusen
                                var filtered = applications
                                    .Where(a => a.Status == chosenStatus)
                                    .ToList();

                                // Om det finns resultat, skriv ut dem
                                if (filtered.Any())
                                {
                                    Console.WriteLine($"Ansökningar med status {chosenStatus}:");
                                    foreach (var app in filtered)
                                        Console.WriteLine(app.GetSummery());
                                }
                                else
                                {
                                    Console.WriteLine($"Inga ansökningar med status {chosenStatus} hittades.");
                                }
                            }
                            else
                            {
                                // hanterar ogiltig statusinmatning
                                Console.WriteLine("Ogiltig status.");
                            }
                            break;

                        // 4. Sortera ansökningar efter datum 
                        case "4":
                            // Använder LINQ för att sortera listan efter ApplicationDate
                            var sorted = applications.OrderBy(a => a.ApplicationDate);

                            Console.WriteLine("Ansökningar sorterade efter datum:");
                            foreach (var app in sorted)
                                Console.WriteLine(app.GetSummery());
                            break;

                        // 5. Uppdatera ansökningsstatus 
                        case "5":
                            // Frågar vilket företag användaren vill uppdatera
                            Console.Write("Ange företagsnamn för ansökan att uppdatera: ");
                            string nameToUpdate = Console.ReadLine();

                            // Hittar första ansökan med matchande företagsnamn
                            var toUpdate = applications.FirstOrDefault(a => a.CompanyName.Equals(nameToUpdate, StringComparison.OrdinalIgnoreCase));

                            if (toUpdate != null)
                            {
                                // Frågar efter den nya statusen
                                Console.WriteLine("Ny status (Applied, Interviewing, Offered, Rejected): ");
                                string newStatusInput = Console.ReadLine();

                                // Omvandlar text till enum och uppdaterar ansökningen
                                if (Enum.TryParse(newStatusInput, true, out ApplicationStatus newStatus))
                                {
                                    toUpdate.Status = newStatus;          // Uppdaterar status
                                    toUpdate.ResponseDate = DateTime.Now; // Sparar tidpunkt för ändringen
                                    Console.WriteLine("Status uppdaterad!");
                                }
                                else
                                {
                                    Console.WriteLine("Ogiltig status.");
                                }
                            }
                            else
                            {
                                // Om inget företag hittades
                                Console.WriteLine("Ingen ansökan hittades för det företaget.");
                            }
                            break;

                        // 6. Ta bort en ansökan 
                        case "6":
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
                            break;

                        // 7. Avsluta programmet 
                        case "7":
                            running = false; // Bryter loopen
                            Console.WriteLine("Programmet avslutas");
                            break;

                        // Ogiltigt val 
                        default:
                            Console.WriteLine("Ogiltigt val! Försök igen!");
                            break;
                    }
                }
            }
        }
    }

}

