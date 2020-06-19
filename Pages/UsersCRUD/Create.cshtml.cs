using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MYAPP.Models;
using MYAPP.Models.Users;

namespace MYAPP.Pages.UsersCRUD
{
    public class CreateModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public string SessionInfo_Email { get; private set; }
       
        private readonly MYAPP.Models.MYAPPContext _context;

        public CreateModel(MYAPP.Models.MYAPPContext context)
        {
            _context = context;
        }   
        public IList<user> user { get; set; }
        [BindProperty(SupportsGet = true)]
        [EmailAddress]
        public string Searchuser { get; set; }
        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Password)]
        public string Searchpass { get; set; }
        public SelectList select { get; set; }
        [BindProperty(SupportsGet = true)]
        public string userselect { get; set; }

        public IActionResult OnGet()
        {
            HttpContext.Session.Clear();
            return Page();
        } 
        public  async Task<IActionResult> OnPostAsync()
        {
           // HttpContext.Session.Clear();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var users = from m in _context.user
                        select m;
            if (!string.IsNullOrEmpty(Searchuser) && !string.IsNullOrEmpty(Searchpass))
            {
                users = users.Where(s => s.email.Equals(Searchuser) && s.password.Equals(Searchpass));
                List<user> u = users.ToList();
                if (u.Count != 0)
                {                  
                        if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
                        {
                        HttpContext.Session.SetString(SessionKeyName, Searchuser);

                        }                                       
                    return RedirectToPage("/ItemsCRUD/Index");
                }
            }
                
            return RedirectToPage("/UsersCRUD/Create");           
        }
    }
}