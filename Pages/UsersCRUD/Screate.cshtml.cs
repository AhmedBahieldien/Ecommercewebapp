using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MYAPP.Models.Users;

namespace MYAPP.Pages.UsersCRUD
{
    public class ScreateModel : PageModel
    {
        [BindProperty]
        public user user { get; set; }

        public const string SessionKeyName = "_Name";
        public string SessionInfo_Email { get; private set; }
        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Password)]
        public string Searchpass1 { get; set; }
        [BindProperty(SupportsGet = true)]
        public string error { get; set; }
        private readonly MYAPP.Models.MYAPPContext _context;      
        public ScreateModel(MYAPP.Models.MYAPPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            HttpContext.Session.Clear();
            return Page();
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
                var users = from m in _context.user
                            select m;
                if (!string.IsNullOrEmpty(user.email) && !string.IsNullOrEmpty(user.password)&& !string.IsNullOrEmpty(Searchpass1) && Searchpass1.Equals(user.password))
                {
                    users = users.Where(s => s.email.Equals(user.email));
                    List<user> u = users.ToList();
                    if (u.Count == 0)
                    {
                        HttpContext.Session.SetString(SessionKeyName, user.email);
                        _context.user.Add(user);
                        await _context.SaveChangesAsync();
                        return RedirectToPage("/ItemsCRUD/Index");
                    }
                }
            error = "Already a user";
            if (!Searchpass1.Equals(user.password))
            {
                error = "Passwords not matching..";
                
            }
            
            return Page();
        }


    }
}