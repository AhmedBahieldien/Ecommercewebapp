using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MYAPP.Models;
using MYAPP.Models.Items;

namespace MYAPP.Pages.ItemsCRUD
{
    public class CreateModel : PageModel
    {
        private readonly MYAPP.Models.MYAPPContext _context;

        public CreateModel(MYAPP.Models.MYAPPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Item Item { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("_Name")))
            {
                Item.Email = (HttpContext.Session.GetString("_Name"));
                _context.Item.Add(Item);
                await _context.SaveChangesAsync();
            }

           

            return RedirectToPage("/ItemsCRUD/Index");
        }
    }
}