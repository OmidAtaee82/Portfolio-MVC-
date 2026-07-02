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

        [Required(ErrorMessage = "First and last name are required")]
        [StringLength(150)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        public bool Frelancer { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(600)]
        public string Description { get; set; }

    }
}
