using Spark.Data;
using Spark.Models.Note;
using SparkClientManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Services
{
    public class NoteService
    {
        private readonly string _userId;

        public NoteService(string userId)
        {
            _userId = userId;
        }

        public bool CreateNote(NoteCreate model)
        {
            var entity =
                new Note()
                {
                    OwnerId = _userId,
                    ProjectId = model.ProjectId,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<NoteListItem> GetNotes(int projectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Notes
                        .Where(e => e.OwnerId == _userId && e.ProjectId == projectId)
                        .Select(
                        e =>
                            new NoteListItem
                            {
                                NoteId = e.NoteId,
                                Content = e.Content,
                                CreatedUtc = e.CreatedUtc
                            }
                        );

                return query.ToArray();
            }
        }
    }
}
