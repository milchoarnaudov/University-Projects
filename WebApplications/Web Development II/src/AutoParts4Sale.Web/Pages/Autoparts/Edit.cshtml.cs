﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoParts4Sale.Core;
using AutoParts4Sale.Data;
using AutoParts4Sale.Data.Repositories;

namespace AutoParts4Sale
{
    public class EditModel : PageModel
    {
        private readonly AutoParts4SaleDbContext _context;
        private readonly AutopartRepository autopartService;

        public EditModel(AutoParts4SaleDbContext context)
        {
            autopartService = new AutopartRepository(context);
            _context = context;
        }

        [BindProperty]
        public Autopart Autopart { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int _id = (int)id;

            Autopart = autopartService.GetById(_id);

            if (Autopart == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            autopartService.Update(Autopart);

            return RedirectToPage("/Autoparts/SuccessMessage");
        }

        
    }
}
