using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.ConductsReportsManagement.Domain.Model.Entities
{
    public class ConductReport
    {
        public long id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeReport { get; set; }
        [ForeignKey("Hobbyst")]
        public long HobbystId { get; set; }
    }
}
