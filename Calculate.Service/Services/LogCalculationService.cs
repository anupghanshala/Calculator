using System;
using System.Collections.Generic;
using System.Text;
using Calculate.Common.Models;
using Calculate.Repository.Interface.Interface;
using Calculate.Service.Interface.Interface;

namespace Calculate.Service.Services
{
    public class LogCalculationService : ILogCalculationService
    {
        private readonly ILogCalculationRepository _logCalculationRepository;

        public LogCalculationService(ILogCalculationRepository logCalculationRepository)
        {
            this._logCalculationRepository = logCalculationRepository;
        }
        public bool LogCalculation(LogCalculation logCalculation)
        {
            return _logCalculationRepository.LogCalculation(logCalculation);
        }
    }


}
