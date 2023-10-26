using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;
using ArtistResource = PERUSTARS.Resources.ArtistResource;

namespace PERUSTARS.ProfileManagement.Application.Commands.Handlers
{
    public class RegisterProfileCommandHandler<TProfileResource>:IRequestHandler<RegisterProfileCommand<TProfileResource>, TProfileResource> where TProfileResource : new()
    {

        public readonly IPublisher _publisher;
        private readonly IMapper _mapper;

        public RegisterProfileCommandHandler(IPublisher publisher, IMapper mapper)
        {
            _publisher = publisher;
            _mapper = mapper;
        }

        public Task<TProfileResource> Handle(RegisterProfileCommand<TProfileResource> request,
            CancellationToken cancellationToken)
        {
            //TO-DO

            if (typeof(TProfileResource) == typeof(HobbyistResource))
            {
                
            }
            else if (typeof(TProfileResource) == typeof(ArtistResource))
            {
                
            }

            return Task.FromResult(new TProfileResource());
        }
        
    }
}