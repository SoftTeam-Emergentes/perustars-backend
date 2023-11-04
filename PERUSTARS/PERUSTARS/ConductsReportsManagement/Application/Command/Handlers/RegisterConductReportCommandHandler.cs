using AutoMapper;
using MediatR;
using PERUSTARS.ConductsReportsManagement.Domain.Model.Commands;
using PERUSTARS.ConductsReportsManagement.Domain.Model.Events;
using PERUSTARS.ConductsReportsManagement.Domain.Model.Entities;
using PERUSTARS.ConductsReportsManagement.Domain.Repositories;
using PERUSTARS.ConductsReportsManagement.Interfaces.REST.resources;
using PERUSTARS.Shared.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.ConductsReportsManagement.Application.Command.Handlers
{
    public class RegisterConductReportCommandHandler: IRequestHandler<RegisterConductReportCommand, ConductReportResource>
    {
        //private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly IConductReportRepository _conductReportRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterConductReportCommandHandler(IMapper mapper, IConductReportRepository conductReportRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _conductReportRepository = conductReportRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ConductReportResource> Handle(RegisterConductReportCommand registerConductReportCommand,
                                                        CancellationToken cancellationToken)
        {
            ConductReportResource conductReportResource = new ConductReportResource();

            if (_conductReportRepository.ExistByTitle(registerConductReportCommand.Title))
                throw new ApplicationException($"Id '{registerConductReportCommand.id}' is already taken");

            var conductReport = _mapper.Map<ConductReport>(registerConductReportCommand);

            try
            {
                await _conductReportRepository.AddAsync(conductReport);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new ApplicationException($"An error ocurred while saving the artist: {e.Message}");
            }
            return conductReportResource; //Review & Probe before to publish
        }
    }
}
