using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UrlBs
    {
        
        private URLdb objDB;

        public UrlBs()
        {
            objDB = new URLdb();
        }

        public IEnumerable<tbl_Url> GetAll()
        {
            return objDB.GetAll();
        }

        public tbl_Url GetById(int id)
        {
            return objDB.GetByID(id);
        }
        public void Insert(tbl_Url url)
        {
            objDB.Insert(url);
        }
        public void Delete(int id)
        {
            objDB.Delete(id);
        }
        public void Update(tbl_Url url)
        {
            objDB.Update(url);
        }
    }
}
