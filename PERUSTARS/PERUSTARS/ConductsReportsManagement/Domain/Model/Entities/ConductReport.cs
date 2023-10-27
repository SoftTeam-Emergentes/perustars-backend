using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.ConductsReportsManagement.Domain.Model.Entities
{
    public class ConductReport
    {
        private long Id { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private DateTime DateTimeConductReport { get; set; }
        private long HobbystId { get; set; }
    }
}
