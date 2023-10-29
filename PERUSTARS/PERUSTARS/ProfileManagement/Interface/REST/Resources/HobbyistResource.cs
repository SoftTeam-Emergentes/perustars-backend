

using System.ComponentModel.DataAnnotations.Schema;

namespace PERUSTARS.ProfileManagement.Interface.REST.Resources
{
    public class HobbyistResource
    {
        [ForeignKey("User")]
        public long UserId { get; set; }
        public long HobbyistId { get; set; }
        public int Age { get; set; }
    }
}