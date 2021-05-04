using Spark.Data;
using Spark.Models.Note;
using Spark.Models.Project;
using SparkClientManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Services
{
    public class ProjectService
    {
        private readonly string _userId;

        public ProjectService(string userId)
        {
            _userId = userId;
        }

        public bool CreateProject(ProjectCreate model)
        {
            var entity =
                new Project()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    UserIds = model.UserIds
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Projects.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProjectListItem> GetProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Projects
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new ProjectListItem
                            {
                                ProjectId = e.ProjectId,
                                Title = e.Title,
                            }
                        );

                return query.ToArray();
            }
        }

        public ProjectDetail GetProjectById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Projects
                    .Single(e => e.ProjectId == id && e.OwnerId == _userId);
                return
                    new ProjectDetail
                    {
                        ProjectId = entity.ProjectId,
                        Title = entity.Title,
                        OwnerId = entity.OwnerId,
                        UserIds = entity.UserIds
                    };
            }
        }
    }
}
