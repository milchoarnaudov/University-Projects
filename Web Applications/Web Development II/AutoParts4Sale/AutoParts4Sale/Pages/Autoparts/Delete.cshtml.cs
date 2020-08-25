﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoParts4Sale.Core;
using AutoParts4Sale.Data;
using AutoParts4Sale.Repository.Implementation;

namespace AutoParts4Sale
{
    public class DeleteModel : PageModel
    {
        private readonly AutopartRepository autopartService;

        public DeleteModel(AutoParts4SaleDbContext context)
        {
            autopartService = new AutopartRepository(context);
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

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int _id = (int)id;

            Autopart = autopartService.Delete(_id);

            if (Autopart == null)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
