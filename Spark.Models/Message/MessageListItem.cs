using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Models.Message
{
    public class MessageListItem
    {
        public int MessageId { get; set; }
        public string SenderId { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public bool Seen { get; set; }
    }
}
