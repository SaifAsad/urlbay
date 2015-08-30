using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class CategoryBs
    {
        private Categorydb objDB;

        public CategoryBs()
        {
            objDB = new Categorydb();
        }

        public IEnumerable<tbl_Category> GetAll()
        {
            return objDB.GetAll();
        }

        public tbl_Category GetById(int id)
        {
            return objDB.GetByID(id);
        }
        public void Insert(tbl_Category url)
        {
            objDB.Insert(url);
        }
        public void Delete(int id)
        {
            objDB.Delete(id);
        }
        public void Update(tbl_Category url)
        {
            objDB.Update(url);
        }
    }
}
