using System.ComponentModel.DataAnnotations;
using LoanApp.Models.Enums;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LoanApp.Models.Entities
{
    public class LoanApplication
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Applicant name is required.")]
        public string ApplicantName { get; set; }
        [Required(ErrorMessage = "Loan term field is required.")]
        [Range(1, 240)]
        public int LoanTerm { get; set; }
        [Required(ErrorMessage = "Loan Amount field is required.")]
        public decimal LoanAmount { get; set; }
        public bool IsActive { get; set; }//implement SoftDelete
        public LoanStatus LoanStatus { get; set; }
        public DateTime ApplicationDate { get; set; } = DateTime.Now;
    }
}
