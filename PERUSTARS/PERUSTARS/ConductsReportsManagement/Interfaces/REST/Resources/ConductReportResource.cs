using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.ConductsReportsManagement.Interfaces.REST.resources
{
    public class RegisterCondcutReport
    {
        public long id;
        [Required]
        [ForeignKey("Hobbyst")]
        public long HobbystId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeReport { get; set; }
    }
}
