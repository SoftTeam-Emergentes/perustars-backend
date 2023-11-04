using MediatR;
using PERUSTARS.ConductsReportsManagement.Domain.Model.Commands;
using PERUSTARS.ConductsReportsManagement.Domain.Model.Services;
using PERUSTARS.ConductsReportsManagement.Interfaces.REST.resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.ConductsReportsManagement.Application.Command.Services
{
    public class ConductReportCommandService : IConductReportService
    {
        private readonly IMediator _mediator;

        public ConductReportCommandService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<RegisterCondcutReport> ExecuteRegisterConductReportCommand(RegisterConductReportCommand registerConductReportCommand)
        {
            return await _mediator.Send(registerConductReportCommand);
        }

        public async Task<Unit> ExecuteDeleteConductReportCommand(DeleteConductReportCommand deleteConductReportCommand)
        {
            // return await _mediator.Send(deleteConductReportCommand);
            return Unit.Value;
        }
    }
}
