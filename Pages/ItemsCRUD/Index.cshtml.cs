using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MYAPP.Models;
using MYAPP.Models.Items;

namespace MYAPP.Pages.ItemsCRUD
{
    public class IndexModel : PageModel
    {
        private readonly MYAPP.Models.MYAPPContext _context;

        public IndexModel(MYAPP.Models.MYAPPContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList select { get; set; }
        [BindProperty(SupportsGet = true)]
        public string itemselect { get; set; }

        [BindProperty(SupportsGet = true)]
        public int number { get; set; }


        public async Task OnGetAsync()
        {
            //var name = HttpContext.Session.GetString("_Name");
            var items = from m in _context.Item
                         select m;         
            
            items = items.Where(s => s.Email.Equals(HttpContext.Session.GetString("_Name")));

            number = items.Count();

            if (!string.IsNullOrEmpty(SearchString))
            {
                
                items = items.Where(s => s.name.Contains(SearchString));
            }

            Item = await items.ToListAsync();
          

        }


    }
}
