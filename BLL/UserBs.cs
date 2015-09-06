using System.Collections.Generic;
using BOL;
using DAL;

namespace BLL
{
    public class UserBs
    {
        private Userdb objDB;

        public UserBs()
        {
            objDB = new Userdb();
        }

        public IEnumerable<tbl_User> GetAll()
        {
            return objDB.GetAll();
        }

        public tbl_User GetById(int id)
        {
            return objDB.GetById(id);
        }
        public void Insert(tbl_User url)
        {
            objDB.Insert(url);
        }
        public void Delete(int id)
        {
            objDB.Delete(id);
        }
        public void Update(tbl_User url)
        {
            objDB.Update(url);
        }
    }
}
