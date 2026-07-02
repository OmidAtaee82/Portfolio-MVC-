using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class Contact
    {

        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "First and last name are required")]
        public string Name { get; set; }

        public string? Email { get; set; }

        [Required(ErrorMessage = "The subject is required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "The Message is required")]
        public string Message { get; set; }

    }
}
