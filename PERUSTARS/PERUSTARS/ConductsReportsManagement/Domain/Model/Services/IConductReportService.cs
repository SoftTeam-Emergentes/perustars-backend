using MediatR;
using PERUSTARS.ConductsReportsManagement.Domain.Model.Commands;
using PERUSTARS.ConductsReportsManagement.Interfaces.REST.resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.ConductsReportsManagement.Domain.Model.Services
{
    public interface IConductReportService
    {
        Task<RegisterCondcutReport> ExecuteRegisterConductReportCommand(RegisterConductReportCommand registerConductReportCommand);
        Task<Unit> ExecuteDeleteConductReportCommand(DeleteConductReportCommand deleteConductReportCommand);
    }
}
