using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Models.Note
{
    public class NoteDetail
    {
        public int NoteId { get; set; }
        public string OwnerId { get; set; }
        public int ProjectId { get; set; }
        public string Content { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
