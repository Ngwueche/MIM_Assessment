using LoanApp.Dtos;
using LoanApp.Models.Entities;

namespace LoanApp.Services.Interfaces
{
    public interface ILoanApplicationService
    {
        Task AddLoanApplicationAsync(CreateLoanApplicationDto loanDto);
        Task DeleteLoanApplicationAsync(int id);
        Task<GetLoanApplicationDto> GetLoanApplicationByIdAsync(int id);
        Task<List<GetLoanApplicationDto>> GetLoanApplicationsAsync();
        Task UpdateLoanApplicationAsync(UpdateLoanApplicationDto loanDto);
    }
}
