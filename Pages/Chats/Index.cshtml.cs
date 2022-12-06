using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRChatApiFetch.Data;
using SignalRChatApiFetch.Models;

namespace SignalRChatApiFetch.Pages.Chats
{
    public class IndexModel : PageModel
    {
        private readonly SignalRChatApiFetch.Data.ChatContext _context;

        public IndexModel(SignalRChatApiFetch.Data.ChatContext context)
        {
            _context = context;
        }

        public IList<Chat> Chat { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Chats != null)
            {
                Chat = await _context.Chats.ToListAsync();
            }
        }
    }
}
