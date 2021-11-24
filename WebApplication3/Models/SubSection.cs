using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet_Core.Models
{
    public class SubSection
    {
        [key]
        public int ID { get; set; }
       [Required]
        public string Name { get; set; }
        [ForeignKey("Section")]
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
