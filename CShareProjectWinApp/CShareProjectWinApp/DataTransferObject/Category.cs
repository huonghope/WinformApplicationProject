using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShareProjectWinApp.DataTransferObject
{
    public class Category
    {
        public Category(int _id,string _name) //Construction
        {
            this.ID = _id;
            this.Name = _name;
        }
        public Category(DataRow row) //해당하는 라인에서 각 열의 데이터를 꺼내서 저장
        {
            this.ID =(int)row["id"];
            this.Name = row["name"].ToString();
        }
        private int iD;
        private string name;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
    }
}
