using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Models.Note
{
    public class NoteCreate
    {
        [Required]
        public int ProjectId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        public string Content { get; set; }
    }
}
