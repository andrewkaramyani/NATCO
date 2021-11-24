using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet_Core.Models
{
    public class Department
    {
        [key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        ICollection<Section> Sections { get; set; }
    }
}
