using System.ComponentModel.DataAnnotations;
using LoanApp.Models.Enums;

namespace LoanApp.Dtos
{
    public class CreateLoanApplicationDto
    {
        [Required]
        [Range(3, 25)]
        public string FirstName { get; set; }
        [Required]
        [Range(3, 25)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Loan term field is required.")]
        [Range(1, 240)]
        public int LoanTerm { get; set; }

        [Required(ErrorMessage = "Loan Amount field is required.")]
        public decimal LoanAmount { get; set; }
    }
    public class GetLoanApplicationDto
    {
        public int Id { get; set; }
        public string ApplicantName { get; set; }
        public int LoanTerm { get; set; }
        public decimal LoanAmount { get; set; }
        public LoanStatus LoanStatus { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
    public class UpdateLoanApplicationDto
    {
        public int Id { get; set; }
        public string ApplicantName { get; set; }
        public int LoanTerm { get; set; }
        public decimal LoanAmount { get; set; }
    }
}
