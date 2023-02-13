using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class InputResponse
    {
        [Key]
        [Required]
        public int InputID { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Year { get; set; }

        // Build Foreign Key
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }

        public Boolean Edited { get; set; }

        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
