
namespace Assignment1OOP
{
    public class JobApplication
    {
        // atributer
        public string CompanyName { get; set; }
        public string PositionTitle { get; set; }
        public ApplicationStatus Status { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public int SalaryExpectation { get; set; }

        // konstruktor

        public JobApplication(string companyName, string positionTitle, DateTime applicationDate, DateTime? responseDate, int salaryExpectation)
        {
            CompanyName = companyName;
            PositionTitle = positionTitle;
            ApplicationDate = applicationDate;
            SalaryExpectation = salaryExpectation;
            ResponseDate = responseDate;
        }

        // metoder

        public int GetdaysSinceApplied()
        {
            return (DateTime.Now - ApplicationDate).Days;
        }

        public string GetSummery()
        {
            return $"Company: {CompanyName}, Position: {PositionTitle}, Applied on: {ApplicationDate:yyyy-MM-dd}, Salary Expectation: {SalaryExpectation} USD";
        }

        // enum för status
        public enum ApplicationStatus
        {
            Applied,
            Interviewing,
            Offered,
            Rejected
        }
    }
}
