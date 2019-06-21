using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShareProjectWinApp.DataTransferObject
{
    class Bill
    { 
        private int iD;
        private DateTime? dataCheckOut; //NUll 저장할 수 있게 하기 위한 ? 추가
        private DateTime? dataCheckIn;
        private int status;

        public Bill(int id, DateTime? _dataCheckOut, DateTime? _dataCheckIn, int status) //Construction
        {
            this.ID = id;
            this.DataCheckIn = _dataCheckIn;
            this.DataCheckOut = _dataCheckOut;
            this.Status = status;
        }
        public Bill(DataRow row) //해당하는 라인에서 각 열의 데이터를 꺼내서 저장
        {
            this.ID =(int)row["id"];
            this.DataCheckIn = (DateTime?)row["DateCheckIn"];
            var DataCheckOut = (DateTime?)row["DateCheckOut"];
            this.Status = (int)row["status"];
        }
        public int ID { get => iD; set => iD = value; }
        public DateTime? DataCheckOut { get => dataCheckOut; set => dataCheckOut = value; }
        public DateTime? DataCheckIn { get => dataCheckIn; set => dataCheckIn = value; }
        public int Status { get => status; set => status = value; }
    }
}
