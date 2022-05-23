using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tricktionary.Models
{
    public class Trick
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the trick name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please type the Description")]
        public string Description { get; set; }

        [Display(Name = "Image:")]
        public string Image { get; set; }
    }
}
