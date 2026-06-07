using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class AboutMe
    {

        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public bool Frelancer { get; set; }
        [StringLength(350)]
        public string Description { get; set; }

    }
}
