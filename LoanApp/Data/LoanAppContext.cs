using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanApp.Models.Entities;

namespace LoanApp.Data
{
    public class LoanAppContext : DbContext
    {
        public LoanAppContext (DbContextOptions<LoanAppContext> options)
            : base(options)
        {
        }

        public DbSet<LoanApp.Models.Entities.LoanApplication> LoanApplication { get; set; } = default!;
    }
}
