using Calculate.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculate.Repository.Context
{
    public class CalculateDbContext : DbContext
    {
        public CalculateDbContext(DbContextOptions<CalculateDbContext> options)
      : base(options)
        {

        }
        public DbSet<LogCalculation> LogCalculation { get; set; }
    }
}
