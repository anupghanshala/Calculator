using Calculate.Common.Models;
using Calculate.Repository.Context;
using Calculate.Repository.Interface.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculate.Repository.Repository
{
    public class LogCalculationRepository : ILogCalculationRepository
    {
        private readonly CalculateDbContext _calculateDbContext;
        public LogCalculationRepository(CalculateDbContext calculateDbContext )
        {
            this._calculateDbContext = calculateDbContext;
        }
        public bool LogCalculation(LogCalculation logCalculation)
        {
            try
            {
                _calculateDbContext.LogCalculation.Add(logCalculation);
                _calculateDbContext.SaveChanges();             
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }
    }
}
