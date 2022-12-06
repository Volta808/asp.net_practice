using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SignalRChatApiFetch.Data;
using SignalRChatApiFetch.Models;

namespace SignalRChatApiFetch.Pages.Chats
{
    public class EditModel : PageModel
    {
        private readonly SignalRChatApiFetch.Data.ChatContext _context;

        public EditModel(SignalRChatApiFetch.Data.ChatContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Chat Chat { get; set; } = default!;

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
            Chat = chat;
            return Page();
        }

        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Attach(Chat).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ChatExists(Chat.Id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return RedirectToPage("./Index");
        //}

        //private bool ChatExists(int id)
        //{
        //  return _context.Chats.Any(e => e.Id == id);
        //}
    }
}
