using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.ConductsReportsManagement.Application.Exceptions
{
    public class ConductReportDeleteException : Exception
    {
        public ConductReportDeleteException() { }
        public ConductReportDeleteException(string message) : base(message) { }
        public ConductReportDeleteException(string message, Exception inner) : base(message, inner) { }
    }
}
