﻿using AutoParts4Sale.Core;
using AutoParts4Sale.Data;
using AutoParts4Sale.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AutoParts4Sale.Repository.Implementation
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly AutoParts4SaleDbContext _context;

        public CategoryRepository(AutoParts4SaleDbContext context)
        {
            _context = context;
        }

        public Category Add(Category category)
        {
            if(category != null)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }

            return category;
        }

        public Category Delete(int id)
        {
            var category = GetById(id);

            if(category != null)
            {
                _context.Remove(category);
                _context.SaveChanges();
            }

            return category;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.Include(c => c.Autoparts);
        }

        public Category GetById(int id)
        {
            Category category = _context.Categories.FirstOrDefault(m => m.Id == id);

            return category;
        }

        public Category Update(Category updatedCategory)
        {
            var category = _context.Categories.Attach(updatedCategory);
            category.State = EntityState.Modified;
            _context.SaveChanges();

            return updatedCategory;
        }
    }
}
