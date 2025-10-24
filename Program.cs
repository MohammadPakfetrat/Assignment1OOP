using static Assignment1OOP.JobApplication;

namespace Assignment1OOP
{
   
   

namespace JobbAnsokningar
    {

        internal class Program
        {
            static void Main(string[] args)
            {  
                //Objekt till klassen JobManager 
                JobManager jobManager = new JobManager();



                // den kör loopen så länge running är true
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

                            jobManager.AddJob();
                           
                            break;

                        // 2. Visa alla ansökningar
                        case "2":
                           jobManager.ShowAll();
                            break;

                        // 3. Filtrera ansökningar efter status
                        case "3":                          
                            jobManager.ShowByStatus();                           
                            break;

                        // 4. Sortera ansökningar efter datum 
                        case "4":
                            jobManager.ShowByDate();
                            break;

                        // 5. Uppdatera ansökningsstatus 
                        case "5":                            
                            Console.WriteLine("Enter Company Name to update:");                           
                            string companyName = Console.ReadLine();                            
                            Console.WriteLine("Enter new Status (0: Applied, 1: Interview, 2: Offer, 3: Rejected):");                           
                            int statusInput = int.Parse(Console.ReadLine());
                            ApplicationStatus newStatus = (ApplicationStatus)statusInput;                            
                            Console.WriteLine("Enter Response Date (yyyy-mm-dd) or leave blank:");                           
                            string responseDateStr = Console.ReadLine();
                            DateTime? responseDate = string.IsNullOrWhiteSpace(responseDateStr) ? null : DateTime.Parse(responseDateStr);

                            // Här: visa status i färg innan uppdatering
                            Console.Write("Updating status to: ");
                            switch (newStatus)
                            {
                                case ApplicationStatus.Applied:
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    break;
                                case ApplicationStatus.Interview:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                                case ApplicationStatus.Offered:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    break;
                                case ApplicationStatus.Rejected:
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    break;
                            }
                            Console.WriteLine(newStatus);
                            Console.ResetColor();

                            jobManager.UpdateStatus(companyName, newStatus, responseDate);
                            break;

                        // 6. Ta bort en ansökan 
                        case "6":
                            jobManager.DeleteJob(); 
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

