using CShareProjectWinApp.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShareProjectWinApp.DataAccessObject
{
    public class BillInfoDAO
    {
        /// <summary>
        /// Degisn Pattern Singleton with BillInfoDAO Class
        /// </summary>
        private static BillInfoDAO instance;
        public static BillInfoDAO Instance {
            get { if (instance == null) instance = new BillInfoDAO(); return instance;}
            set { BillInfoDAO.instance = value;}
        }
        private BillInfoDAO() { }

        //public List<BillInfo> GetListBillInfo(int id)
        //{
        //    List<BillInfo> list = new List<BillInfo>();
        //    DataTable data = DataProvider.Instance.ExcuteQuerry("SELECT * FROM BillInfo WHERE idBill =" + id);
        //    foreach (DataRow item in data.Rows)
        //    {
        //        BillInfo info = new BillInfo(item);
        //        list.Add(info);
        //    }
        //    return list;
        //}
        
        //주문 클릭시에 BillInfo 데이터를 삽입,한수 리턴이 없이
        public void InsertBillInfo(int idBill,int idFood,int count)
        {
            DataProvider.Instance.ExcuteQuerry("EXEC USP_InsertBillInfo @idBill , @idFood , @count", new object[] {idBill,idFood,count});
        }
      
    }
}
