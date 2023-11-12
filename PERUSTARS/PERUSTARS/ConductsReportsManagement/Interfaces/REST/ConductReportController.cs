using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.ConductsReportsManagement.Domain.Model.Commands;
using PERUSTARS.ConductsReportsManagement.Domain.Model.Services;
using PERUSTARS.ConductsReportsManagement.Interfaces.REST.resources;
using PERUSTARS.ConductsReportsManagement.Interfaces.REST.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.ConductsReportsManagement.Interfaces.REST
{
    [Route("api/v1/conductReports/[controller]")]
    [ApiController]
    public class ConductReportController : ControllerBase
    {
        private readonly IConductReportService _conductReportService;
        private readonly IMapper _mapper;

        public ConductReportController(IConductReportService conductReportService, IMapper mapper)
        {
            _mapper = mapper;
            _conductReportService = conductReportService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterNewConductReport([FromBody] RegisterConductReport registerConductReport)
        {
            RegisterConductReportCommand registerConductReportCommand = _mapper.Map<RegisterConductReportCommand>(registerConductReport);
            ConductReportResource conductReportResource = await _conductReportService.ExecuteRegisterConductReportCommand(registerConductReportCommand);
            return Ok(conductReportResource);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteConductReport(long _id)
        {
            DeleteConductReportCommand deleteConductReportCommand = new DeleteConductReportCommand()
            {
                id = _id
            };

            await _conductReportService.ExecuteDeleteConductReportCommand(deleteConductReportCommand);
            var successMessage = "Conduct Report was removed";
            return Ok(successMessage);
        }

    }
}
