using System;
using System.Collections.Generic;
using System.Text;

namespace Calculate.Common.Models
{
    public class ApiResult
    {
        public string Output { get; set; }

        public string Input { get; set; }

        public string Error { get; set; } = string.Empty;
    }
}
