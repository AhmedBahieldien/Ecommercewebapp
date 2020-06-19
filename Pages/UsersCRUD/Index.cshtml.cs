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
    public class IndexModel : PageModel
    {
        private readonly MYAPP.Models.MYAPPContext _context;

        public IndexModel(MYAPP.Models.MYAPPContext context)
        {
            _context = context;
        }

        public IList<user> user { get;set; }
        [BindProperty(SupportsGet = true)]
        public string Searchuser { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Searchpass { get; set; }
        [BindProperty(SupportsGet = true)]
        public string userselect { get; set; }


        public async Task OnGetAsync()
        {
            var users = from m in _context.user
                        select m;

            if (!string.IsNullOrEmpty(Searchuser) && !string.IsNullOrEmpty(Searchpass))
            {

                users = users.Where(s => s.email.Equals(Searchuser) && s.password.Equals(Searchpass));
                
            }
            user = await users.ToListAsync();
        }
    }
}
