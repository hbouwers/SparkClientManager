﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Models.Note
{
    public class NoteListItem
    {
        public int NoteId { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
