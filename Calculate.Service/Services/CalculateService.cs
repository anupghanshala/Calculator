using Calculate.Common.Models;
using Calculate.Service.Interface.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Calculate.Service.Services
{
    public class CalculateService : ICalculateService
    {
        private readonly ILogCalculationService _logCalculationService;

        public CalculateService(ILogCalculationService logCalculationService)
        {
            this._logCalculationService = logCalculationService;
        }
        public ApiResult CalculateValue(string values, string ipAddress)
        {
            // Log Client Ip Address
            var logResult=_logCalculationService.LogCalculation(new LogCalculation() { ClientIp = ipAddress, CreateDate = DateTime.Now });
            if(!logResult)
            {
                throw new Exception();
            }
            var result = new ApiResult();
            result.Input = values.Replace(" ", "+"); 
            try
            {
                var loDataTable = new DataTable();
                var loDataColumn = new DataColumn("Eval", typeof(double), result.Input);
                loDataTable.Columns.Add(loDataColumn);
                loDataTable.Rows.Add(0);
                result.Output = ((double)(loDataTable.Rows[0]["Eval"])).ToString();
            }
            catch (Exception ex)
            {
                result.Error = "Error with input";
            }
            return result;
        }
    }
}
