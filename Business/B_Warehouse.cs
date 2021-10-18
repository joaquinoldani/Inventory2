using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class B_Warehouse
    {
        public static List<WarehouseEntity> WarehouseList()
        {
            using (var db = new InventoryContext())
            {
                return db.Warehouses.ToList();
            }
        }

        public static void CreateWarehouse(WarehouseEntity oWarehouse)
        {
            using (var db = new InventoryContext())
            {
                db.Warehouses.Add(oWarehouse);
                db.SaveChanges();
            }
        }

        public void UpdateWarehouse(WarehouseEntity oWarehouse)
        {
            using (var db = new InventoryContext())
            {
                db.Warehouses.Update(oWarehouse);
                db.SaveChanges();
            }
        }

        public void DeleteWarehouse(WarehouseEntity oWarehouse)
        {
            using (var db = new InventoryContext())
            {
                db.Warehouses.Remove(oWarehouse);
                db.SaveChanges();
            }
        }
    }
}
