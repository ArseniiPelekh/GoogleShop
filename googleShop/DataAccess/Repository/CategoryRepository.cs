using Data.Interface;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class CategoryRepository : ICategory
    {

        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDB)
        {
            this.appDBContent = appDB;
        }

        public IEnumerable<Category> AllCategories => appDBContent.Categories;
    }
}
