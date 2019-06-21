using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShareProjectWinApp.DataTransferObject
{
    public class BillInfo
    {
        private int iD;
        private int billID;
        private int foodID;
        private int count;

        public BillInfo(int id, int _billID, int _foodID, int _count) //Construction
        {
            this.ID = id;
            this.BillID = _billID;
            this.FoodID = _foodID;
            this.Count = _count;
        }
        public BillInfo(DataRow row) //해당하는 라인에서 각 열의 데이터를 꺼내서 저장
        {
            this.ID = (int) row["id"];
            this.BillID = (int)row["idBill"];
            this.FoodID = (int)row["idFood"];
            this.Count = (int)row["count"];
        }
        public int ID { get => iD; set => iD = value; }
        public int BillID { get => billID; set => billID = value; }
        public int FoodID { get => foodID; set => foodID = value; }
        public int Count { get => count; set => count = value; }
    }
}
