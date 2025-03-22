using System.ComponentModel.DataAnnotations;
using LoanApp.Models.Enums;

namespace LoanApp.Dtos
{
    public class CreateLoanApplicationDto
    {
        [Required(ErrorMessage = "First name is required.")]
        [MinLength(3, ErrorMessage = "First name must be at least 3 characters.")]
        [MaxLength(25, ErrorMessage = "First name cannot exceed 25 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MinLength(3, ErrorMessage = "Last name must be at least 3 characters.")]
        [MaxLength(25, ErrorMessage = "Last name cannot exceed 25 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Loan term field is required.")]
        [Range(1, 240, ErrorMessage = "Loan term must be between 1 and 240 months.")]
        public int LoanTerm { get; set; }

        [Required(ErrorMessage = "Loan Amount field is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Loan amount must be greater than 0.")]
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
    public class UpdateLoanApplicationStatusDto
    {
        public int Id { get; set; }
        public int status { get; set; }
    }
}

