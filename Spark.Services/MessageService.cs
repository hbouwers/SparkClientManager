using Spark.Data;
using Spark.Models.Message;
using SparkClientManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Services
{
    public class MessageService
    {
        private readonly string _userId;

        public MessageService(string userId)
        {
            _userId = userId;
        }

        public bool CreateMessage(MessageCreate model)
        {
            var entity =
                new Message()
                {
                    SenderId = _userId,
                    RecipientId = model.RecipientId,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.UtcNow,
                    Seen = false
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Messages.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MessageListItem> GetMessages()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Messages
                        .Where(e => e.RecipientId == _userId)
                        .Select(
                        e =>
                            new MessageListItem
                            {
                                MessageId = e.MessageId,
                                SenderId = e.SenderId,
                                Content = e.Content,
                                CreatedUtc = e.CreatedUtc,
                                Seen = e.Seen
                            }
                        );

                return query.ToArray();
            }
        }

        public MessageDetail GetMessageById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Messages
                    .Single(e => e.MessageId == id && e.RecipientId == _userId);
                return
                    new MessageDetail
                    {
                        MessageId = entity.MessageId,
                        SenderId = entity.SenderId,
                        RecipientId = entity.RecipientId,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc,
                        Seen = entity.Seen
                    };
            }
        }

        public bool UpdateMessage(MessageEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Messages
                    .Single(e => e.MessageId == model.MessageId && e.RecipientId == _userId);

                entity.Seen = model.Seen;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMessage(int messageId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Messages
                        .Single(e => e.MessageId == messageId && e.SenderId == _userId);

                ctx.Messages.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
