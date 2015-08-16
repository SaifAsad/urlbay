using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//used repository pattern with entity framework

namespace DAL
{
    public class URLdb
    {
        private LinkHubDBEntities db;

        public URLdb()
        {
            db = new LinkHubDBEntities();
        }

        public IEnumerable<tbl_Url> GetAll()
        {
            return db.tbl_Url.ToList();
        }

        public tbl_Url GetByID(int id)
        {
            return db.tbl_Url.Find(id);
        }

        public void Insert(tbl_Url url)
        {
            db.tbl_Url.Add(url);
            Save();
        }
        public void Delete(int id)
        {
            tbl_Url url = db.tbl_Url.Find(id);
            db.tbl_Url.Remove(url);
            Save();
        }

        public void Update(tbl_Url url)
        {
            db.Entry(url).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
