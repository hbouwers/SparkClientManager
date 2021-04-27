using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Models.Message
{
    public class MessageCreate
    {
        [Required]
        public string RecipientId { get; set; }
        [Required]
        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        public string Content { get; set; }
    }
}
