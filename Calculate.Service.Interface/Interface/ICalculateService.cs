using Calculate.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculate.Service.Interface.Interface
{
    public interface ICalculateService
    {
        ApiResult CalculateValue(string values,string ipAddress);
    }
}
