using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.ConductsReportsManagement.Domain.Model.Commands
{
    public class DeleteConductReportCommand : IRequest
    {
        public long id;
    }
}
