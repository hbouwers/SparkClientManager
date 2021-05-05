using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Models.Project
{
    public class ProjectEdit
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string[] UserIds { get; set; }
    }
}
