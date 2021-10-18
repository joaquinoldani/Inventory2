using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class B_InputOutput
    {
        public List<InputOutputEntity> InputOutputList()
        {
            using (var db = new InventoryContext())
            {
                return db.InOut.ToList();
            }
        }

        public void CreateInputOutput(InputOutputEntity oInout)
        {
            using (var db = new InventoryContext())
            {
                db.InOut.Add(oInout);
                db.SaveChanges();
            }
        }

        public void UpdateInputOutput(InputOutputEntity oInout)
        {
            using (var db = new InventoryContext())
            {
                db.InOut.Update(oInout);
                db.SaveChanges();
            }
        }

        public void DeleteInputOutput(InputOutputEntity oInout)
        {
            using (var db = new InventoryContext())
            {
                db.InOut.Remove(oInout);
                db.SaveChanges();
            }
        }
    }
}
