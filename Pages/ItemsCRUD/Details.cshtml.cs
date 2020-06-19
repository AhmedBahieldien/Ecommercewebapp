using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MYAPP.Models;
using MYAPP.Models.Items;

namespace MYAPP.Pages.ItemsCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly MYAPP.Models.MYAPPContext _context;

        public DetailsModel(MYAPP.Models.MYAPPContext context)
        {
            _context = context;
        }

        public Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _context.Item.FirstOrDefaultAsync(m => m.ID == id);

            if (Item == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
