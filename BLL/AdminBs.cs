using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace BLL
{
    public class AdminBs : BaseBs
    {

        public void ApproveOrReject(List<int> Ids, string Status)
        {
            using (TransactionScope Trans = new TransactionScope())
            {
                try
                {
                    foreach (var item in Ids)
                    {
                        var myUrl = urlBs.GetById(item);
                        myUrl.IsApproved = Status;
                        urlBs.Update(myUrl);
                        //Console.WriteLine("myurl name " + myUrl.UrlTitle.ToString() + "myurl status " + myUrl.IsApproved.ToString());
                    }

                    Trans.Complete();
                }
                catch (Exception E1)
                {
                    throw new Exception(E1.Message);
                }
            }
        }
    }
}

