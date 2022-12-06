using Microsoft.EntityFrameworkCore;
using SignalRChatApiFetch.Models;
using System.Collections.Generic;

namespace SignalRChatApiFetch.Data
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        {

        }
        public DbSet<Chat> Chats { get; set; } = default!;
    }
}
