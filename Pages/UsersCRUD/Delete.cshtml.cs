using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MYAPP.Models;
using MYAPP.Models.Users;

namespace MYAPP.Pages.UsersCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly MYAPP.Models.MYAPPContext _context;

        public DeleteModel(MYAPP.Models.MYAPPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public user user { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            user = await _context.user.FirstOrDefaultAsync(m => m.ID == id);

            if (user == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            user = await _context.user.FindAsync(id);

            if (user != null)
            {
                _context.user.Remove(user);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
