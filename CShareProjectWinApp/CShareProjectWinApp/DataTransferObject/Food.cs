using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShareProjectWinApp.DataTransferObject
{
    public class Food
    {
        int iD;
        string name;
        int idCategory;
        float price;

        public Food(int _id, string _name, int _idCategory, float _price) //Construction
        {
            this.ID = _id;
            this.Name = _name;
            this.IdCategory = _idCategory;
            this.Price = _price;
        }
        public Food(DataRow row) //해당하는 라인에서 각 열의 데이터를 꺼내서 저장
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.IdCategory = (int)row["idCategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public float Price { get => price; set => price = value; }
    }
}
