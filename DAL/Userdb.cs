using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Userdb
    {
        private LinkHubDBEntities db;

        public Userdb()
        {
            db = new LinkHubDBEntities();
        }

        public IEnumerable<tbl_User> GetAll()
        {
            return db.tbl_User.ToList();
        }

        public tbl_User GetByID(int id)
        {
            return db.tbl_User.Find(id);
        }

        public void Insert(tbl_User url)
        {
            db.tbl_User.Add(url);
            Save();
        }
        public void Delete(int id)
        {
            tbl_User url = db.tbl_User.Find(id);
            db.tbl_User.Remove(url);
            Save();
        }

        public void Update(tbl_User url)
        {
            db.Entry(url).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
