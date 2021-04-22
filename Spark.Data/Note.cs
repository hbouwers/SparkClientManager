using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Data
{
    class Note
    {
        [Key]
        public int NoteId { get; set; }
        [Required]
        public string OwnerId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
