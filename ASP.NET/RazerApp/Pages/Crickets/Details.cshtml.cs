﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazerApp.Data;
using RazerApp.Models;

namespace RazerApp.Pages.Crickets
{
    public class DetailsModel : PageModel
    {
        private readonly RazerApp.Data.RazerAppContext _context;

        public DetailsModel(RazerApp.Data.RazerAppContext context)
        {
            _context = context;
        }

        public Cricket Cricket { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cricket = await _context.Cricket.FirstOrDefaultAsync(m => m.Id == id);

            if (Cricket == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
