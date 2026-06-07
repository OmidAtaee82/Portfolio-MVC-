using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class Experience
    {

        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Expertise { get; set; }
        [StringLength(400)]
        public string Description { get; set; }
        public string NameCompany { get; set; }
        public DateTime StartData { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
