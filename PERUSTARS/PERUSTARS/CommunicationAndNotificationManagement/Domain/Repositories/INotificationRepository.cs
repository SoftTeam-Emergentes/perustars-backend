using System.Collections.Generic;
using System.Threading.Tasks;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Entities;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.CommunicationAndNotificationManagement.Domain.Repositories
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        

    }
}
