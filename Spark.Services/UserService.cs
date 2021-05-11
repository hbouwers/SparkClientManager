using Spark.Models.User;
using SparkClientManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Services
{
    public class UserService
    {
        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Users
                        .Select(
                        e =>
                            new UserListItem
                            {
                                Id = e.Id,
                                UserName = e.UserName,
                            }
                        );

                return query.ToArray();
            }
        }
    }
}
