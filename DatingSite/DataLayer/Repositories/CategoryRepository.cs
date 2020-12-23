using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class CategoryRepository
    {
        private readonly DatingSiteContext _context;

        public CategoryRepository(DatingSiteContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.CategoryId.Equals(id));
        }
    }
}