using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class Skills
    {

        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        public string Image { get; set; }

    }
}
