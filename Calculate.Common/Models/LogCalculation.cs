using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Calculate.Common.Models
{
    [Table("LogCalculations") ]
    public class LogCalculation
    {
        [Key]
        public int logId { get; set; }

        public string ClientIp { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
