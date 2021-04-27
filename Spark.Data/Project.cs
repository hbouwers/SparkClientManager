using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Data
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string OwnerId { get; set; }
        public string[] UserIds { get; set; }
    }
}
