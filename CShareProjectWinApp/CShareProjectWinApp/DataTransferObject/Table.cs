using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShareProjectWinApp.DataTransferObject
{
    public class Table
    {
        private int id;
        private string name;
        private string status;
        public Table(int _id,string _name,string _status) //Construction
        {
            this.Id = _id;
            this.Name = _name;
            this.Status = _status;
        }
        public Table(DataRow rows) //해당하는 라인에서 각 열의 데이터를 꺼내서 저장
        {
            this.Id =(int)rows["id"];
            this.Name = rows["name"].ToString();
            this.Status = rows["status"].ToString();
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
    }
}
