using Entities;
using System;
using System.Collections.Generic;
using System.Text;
// DataAccess es para el acceso a la BD
using DataAccess;
using System.Linq;

namespace Business
{
    public class B_Category
    {
        // CRUD de Category, este es el formato basico para acceder a los datos
        public static List<CategoryEntity> CategoryList()
        { 
            using (var db = new InventoryContext())
            {
                return db.Categories.ToList();
            }
        }

        public static CategoryEntity CategoryById(string id)
        {
            using (var db = new InventoryContext())
            {
                return db.Categories.ToList().LastOrDefault(p => p.CategoryId == id);
            }
        }

        public static void CreateCategory(CategoryEntity oCategory)
        {
            using (var db = new InventoryContext())
            {
                db.Categories.Add(oCategory);
                db.SaveChanges();
            }
        }

        public static void UpdateCategory(CategoryEntity oCategory)
        {
            using (var db = new InventoryContext())
            {
                db.Categories.Update(oCategory);
                db.SaveChanges();
            }
        }

        public void DeleteCategory(CategoryEntity oCategory)
        {
            using (var db = new InventoryContext())
            {
                db.Categories.Remove(oCategory);
                db.SaveChanges();
            }
        }
    }
}
