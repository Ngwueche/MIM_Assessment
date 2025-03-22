using LoanApp.Data;
using LoanApp.Dtos;
using LoanApp.Models.Entities;
using LoanApp.Models.Enums;
using LoanApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LoanApp.Services.Implementations
{

    public class LoanApplicationService : ILoanApplicationService
    {
        private readonly LoanAppContext _context;

        public LoanApplicationService(LoanAppContext context)
        {
            _context = context;
        }

        public async Task<List<GetLoanApplicationDto>> GetLoanApplicationsAsync()
        {
            try
            {
                var records = await _context.LoanApplication.Where(x => x.IsActive).ToListAsync();
                if (!records.Any())
                {
                    Log.Information("No record found.");
                    return null;
                }
                else
                {
                    return records.Select(x => new GetLoanApplicationDto
                    {
                        ApplicantName = x.ApplicantName,
                        LoanAmount = x.LoanAmount,
                        LoanStatus = x.LoanStatus,
                        Id = x.Id,
                        LoanTerm = x.LoanTerm,
                        ApplicationDate = x.ApplicationDate,
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error from GetLoanApplicationsAsync method ==> " + ex.Message);
                throw;
            }
        }

        private async Task<LoanApplication> GetActiveLoanRecord(int Id) => await _context.LoanApplication.Where(l => l.IsActive && l.IsActive).FirstOrDefaultAsync();

        public async Task<GetLoanApplicationDto> GetLoanApplicationByIdAsync(int id)
        {
            try
            {
                var record = await GetActiveLoanRecord(id);

                if (record is not null)
                {
                    Log.Information("No record found.");
                    return null;
                }
                else
                {
                    var loanRecord = new GetLoanApplicationDto
                    {
                        ApplicantName = record.ApplicantName,
                        LoanAmount = record.LoanAmount,
                        LoanStatus = record.LoanStatus,
                        Id = record.Id,
                        LoanTerm = record.LoanTerm,
                        ApplicationDate = record.ApplicationDate,
                    };
                    return loanRecord;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error from GetLoanApplicationByIdAsync method ==> " + ex.Message);
                throw;
            }
        }

        public async Task AddLoanApplicationAsync(CreateLoanApplicationDto loanDto)
        {
            try
            {
                var loanApplication = new LoanApplication
                {
                    ApplicantName = loanDto.FirstName + " " + loanDto.LastName,
                    LoanAmount = loanDto.LoanAmount,
                    LoanStatus = Models.Enums.LoanStatus.Pending,
                    ApplicationDate = DateTime.Now,
                    IsActive = true,
                    LoanTerm = loanDto.LoanTerm,
                };

                _context.LoanApplication.Add(loanApplication);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error("Error from AddLoanApplicationAsync method ==> " + ex.Message);
                throw;
            }
        }

        public async Task UpdateLoanApplicationAsync(UpdateLoanApplicationDto loanDto)
        {
            try
            {
                var getRecord = await GetActiveLoanRecord(loanDto.Id);
                if (getRecord == null)
                {
                    return;
                }
                getRecord.LoanTerm = loanDto.LoanTerm;
                getRecord.LoanAmount = loanDto.LoanAmount;
                getRecord.ApplicantName = loanDto.ApplicantName;

                _context.LoanApplication.Update(getRecord);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error("Error from UpdateLoanApplicationAsync method ==> " + ex.Message);
                throw;
            }
        }
        public async Task UpdateLoanApplicationStatusAsync(UpdateLoanApplicationStatusDto loanDto)
        {
            try
            {
                var getRecord = await GetActiveLoanRecord(loanDto.Id);
                if (getRecord == null)
                {
                    return;
                }
                getRecord.LoanStatus = (LoanStatus)loanDto.status;

                _context.LoanApplication.Update(getRecord);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error("Error from UpdateLoanApplicationAsync method ==> " + ex.Message);
                throw;
            }
        }

        public async Task DeleteLoanApplicationAsync(int id)
        {
            try
            {
                var loanApplication = await _context.LoanApplication.FindAsync(id);
                if (loanApplication != null)
                {
                    loanApplication.IsActive = false;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error from DeleteLoanApplicationAsync method ==> " + ex.Message);
                throw;
            }
        }

    }
}
