using AutoMapper;
using MediatR;
using PERUSTARS.ConductsReportsManagement.Application.Exceptions;
using PERUSTARS.ConductsReportsManagement.Domain.Model.Commands;
using PERUSTARS.ConductsReportsManagement.Domain.Repositories;
using PERUSTARS.Shared.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.ConductsReportsManagement.Application.Command.Handlers
{
    public class DeleteConductReportCommandHandler : IRequestHandler<DeleteConductReportCommand>
    {
        private readonly IMapper _mapper;
        private readonly IConductReportRepository _conductReportRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteConductReportCommandHandler(IMapper mapper, IConductReportRepository conductReportRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _conductReportRepository = conductReportRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteConductReportCommand request, CancellationToken cancellationToken)
        {
            var conductReport = await _conductReportRepository.GetConductReportByIdAsync(request.id);
            if (conductReport == null)
                throw new ConductReportNotFoundException("Conuct Report not Found");

            bool success = await _conductReportRepository.DeleteConductReportAsync(conductReport);

            if (!success)
                throw new ConductReportDeleteException("The Conduct Report was not deleted");

            return Unit.Value;
        }
    }
}
