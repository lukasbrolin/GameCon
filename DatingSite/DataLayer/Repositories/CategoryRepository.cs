using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DataLayer.Repositories
{
    public class CategoryRepository
    {
        private readonly DatingSiteContext _context;

        public CategoryRepository(DatingSiteContext context)
        {
            _context = context;
        }

        //Collect all categories to list
        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        //Collect all category names to lists
        public List<string> GetCategorieNames()
        {
            var names = new List<string>();
            var list = _context.Categories.ToList();
            foreach (var item in list)
            {
                names.Add(item.Name);
            }

            return names;
        }

        //Add new category to database
        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        //Get category by ID
        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.CategoryId.Equals(id));
        }
    }
}