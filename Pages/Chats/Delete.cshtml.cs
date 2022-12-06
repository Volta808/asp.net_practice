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
    public class DeleteModel : PageModel
    {
        private readonly SignalRChatApiFetch.Data.ChatContext _context;

        public DeleteModel(SignalRChatApiFetch.Data.ChatContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Chat Chat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Chats == null)
            {
                return NotFound();
            }

            var chat = await _context.Chats.FirstOrDefaultAsync(m => m.Id == id);

            if (chat == null)
            {
                return NotFound();
            }
            else 
            {
                Chat = chat;
            }
            return Page();
        }

        //public async Task<IActionResult> OnPostAsync(int? id)
        //{
        //    if (id == null || _context.Chats == null)
        //    {
        //        return NotFound();
        //    }
        //    var chat = await _context.Chats.FindAsync(id);

        //    if (chat != null)
        //    {
        //        Chat = chat;
        //        _context.Chats.Remove(Chat);
        //        await _context.SaveChangesAsync();
        //    }

        //    return RedirectToPage("./Index");
        //}
    }
}
