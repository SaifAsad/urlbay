using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Categorydb
    {
        private LinkHubDBEntities db;

        public Categorydb()
        {
            db = new LinkHubDBEntities();
        }

        public IEnumerable<tbl_Category> GetAll()
        {
            return db.tbl_Category.ToList();
        }

        public tbl_Category GetByID(int id)
        {
            return db.tbl_Category.Find(id);
        }

        public void Insert(tbl_Category url)
        {
            db.tbl_Category.Add(url);
            Save();
        }
        public void Delete(int id)
        {
            tbl_Category url = db.tbl_Category.Find(id);
            db.tbl_Category.Remove(url);
            Save();
        }

        public void Update(tbl_Category url)
        {
            db.Entry(url).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
