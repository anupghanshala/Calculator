using Calculate.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculate.Repository.Interface.Interface
{
    public interface ILogCalculationRepository
    {
        bool LogCalculation(LogCalculation logCalculation);
    }
}
