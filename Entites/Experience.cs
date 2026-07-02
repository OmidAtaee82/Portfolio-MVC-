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

        [Required(ErrorMessage = "The Expertise Required")]
        [StringLength(200)]
        public string Expertise { get; set; }

        [Required(ErrorMessage = "The Description Required")]
        [MaxLength(600)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The NameCompany Required")]
        public string NameCompany { get; set; }

        [Required(ErrorMessage = "The StartDate Required")]
        public DateTime StartData { get; set; }

        public DateTime? EndDate { get; set; }

    }
}
