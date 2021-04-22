using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Data
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [Required]
        public string SenderId { get; set; }
        [Required]
        public string RecipientId { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        [Required]
        public bool Seen { get; set; }
    }
}
