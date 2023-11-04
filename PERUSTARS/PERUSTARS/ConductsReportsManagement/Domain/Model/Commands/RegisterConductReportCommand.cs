using MediatR;
using PERUSTARS.ConductsReportsManagement.Interfaces.REST.resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.ConductsReportsManagement.Domain.Model.Commands
{
    public class RegisterConductReportCommand : IRequest<RegisterCondcutReport>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeReport { get; set; }
        public long HobbystId { get; set; }
    }
}
