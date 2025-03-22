using LoanApp.Dtos;

namespace LoanApp.Services.Interfaces
{
    public interface ILoanApplicationService
    {
        Task AddLoanApplicationAsync(CreateLoanApplicationDto loanDto);
        Task DeleteLoanApplicationAsync(int id);
        Task<GetLoanApplicationDto> GetLoanApplicationByIdAsync(int id);
        Task<List<GetLoanApplicationDto>> GetLoanApplicationsAsync();
        Task UpdateLoanApplicationAsync(UpdateLoanApplicationDto loanDto);
        Task ApproveLoanApplicationRequestAsync(int Id);
        Task RejectLoanApplicationRequestAsync(int Id);

    }
}
