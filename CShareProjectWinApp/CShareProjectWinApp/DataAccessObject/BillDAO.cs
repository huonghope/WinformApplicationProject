using CShareProjectWinApp.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShareProjectWinApp.DataAccessObject
{
    public class BillDAO
    {
        /// <summary>
        /// Degisn Pattern Singleton With BillDAO Class
        /// </summary>
        private static BillDAO instance;
        public static BillDAO Instance {
            get { if (instance == null) instance = new BillDAO(); return instance;}
            set { BillDAO.instance = value; }
        }
        private BillDAO() { }
        //Bill테이블에서 전달된 idTable에 근거하여 아직 체크하지 않은 Bill의 정보를 출력
        public int GetUnCheckBillIdbyTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExcuteQuerry("SELECT * FROM Bill WHERE idTable = "+ id + "AND status = 0"); //not check
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]); //얻은 라인 데이터를 Id를 꺼내서 출력함
                return bill.ID;
            }
            return -1; //실패
        }
        // 전달된 id에 근거하여 Bill 상태가 변경
        public void CheckOut(int id)
        {
            string query = "UPDATE Bill SET status = 1 WHERE id = " + id;
            DataProvider.Instance.ExcuteNonQuerry(query);
        }
        //전달된 idTable에 근거하여 주문한 테이블에서 Bill를 삽입
        public void InsertBill(int id) {
            DataProvider.Instance.ExcuteQuerry("EXEC USE_InsertBill @idTable",new object[] {id});
        }
        //리턴 현재에 있는 Bill의 수량
        public int GetMaxIdBill()
        {
            try
            {
                //만약에 현재 테이블에서 Bill가 없으면 return 1;
                return (int)DataProvider.Instance.ExcuteScalar("SELECT MAX(id) FROM Bill");
            }
            catch
            {
                return 1;
            }
        }
    }
}
