using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.ConductsReportsManagement.Application.Exceptions
{
    public class ConductReportNotFoundException : Exception
    {
        public ConductReportNotFoundException() { }
        public ConductReportNotFoundException(string message) : base(message) { }
        public ConductReportNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
