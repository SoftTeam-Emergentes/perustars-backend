using MediatR;
using PERUSTARS.ConductsReportsManagement.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.ConductsReportsManagement.Application.Commands.Handlers
{
    public abstract class RegisterConductReportCommandHandler
    {
        public async Task<ConductReport> Handle();
    }
}
