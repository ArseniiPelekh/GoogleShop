using Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Courses.Any())
            {
                content.AddRange(
                    new Course
                    {
                        Name = "Програмування C# розробки",
                        Img = "https://edx.prometheus.org.ua/c4x/Microsoft/CS201/asset/88750_c444_7.jpg",
                        Price = 200,
                        Category = Categories["Курс програмирования C#"]
                    },

                    new Course
                    {
                        Name = "Цель как мотивирующая сила!",
                        Img = "https://cf.ppt-online.org/files2/slide/7/7XFelwZ394fLbKnHRO5tuCEz2opMxhd6JrsYVaqBGP/slide-0.jpg",
                        Price = 150,
                        Category = Categories["Стальные нервы"]
                    }
                ) ;

            }
            content.SaveChanges();


           }
        private static Dictionary<string, Category> category;
        private static Dictionary<string, Category> Categories {
            get {
                if (category == null)
                {
                    var list = new Category[] {
                        new Category {  CategoryName = "Курс програмирования C#", Desc = "Курс для начинающих." },
                        new Category {  CategoryName = "Стальные нервы", Desc = "Курс предназначеный для улучшения внутрений сили и мотивации!" }

                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category cat in list)
                        category.Add(cat.CategoryName, cat);
                }
                return category;
            }
        }

    }
}
