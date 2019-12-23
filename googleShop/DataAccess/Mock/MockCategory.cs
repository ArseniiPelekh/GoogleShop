using Data.Interface;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mock
{
    public class MockCategory : ICategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category> {
                    new Category {  CategoryName = "Програмирования", Desc = "Курс для начинающих." },
                    new Category {  CategoryName = "Психология", Desc = "Курс предназначеный для улучшения внутрений сили и мотивации!" }
                };

            }
        }

    }
}
