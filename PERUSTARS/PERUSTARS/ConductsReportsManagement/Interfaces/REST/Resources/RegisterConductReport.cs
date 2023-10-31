using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.ConductsReportsManagement.Interfaces.REST.Resources
{
    public class RegisterConductReport
    {
        [Required]
        [ForeignKey("ConductReport")]
        public long id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime dateTimeReport { get; set; }
    }
}
