using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShareProjectWinApp.DataTransferObject
{
    public class MenuByTable
    {
        string foodName;
        private float price;
        private int count;
        private float totalPrince;

        public MenuByTable(string foodName, float price, int count, float totalPrince = 0) //Construction
        {
            this.FoodName = foodName;
            this.Price = price;
            this.Count = count;
            this.TotalPrince = totalPrince;
        }
        public MenuByTable(DataRow row) //해당하는 라인에서 각 열의 데이터를 꺼내서 저장
        {
            this.FoodName = row["name"].ToString();
            this.Count = (int)row["count"];
            this.Price =(float)Convert.ToDouble(row["price"].ToString());
            this.TotalPrince = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }


        public string FoodName { get => foodName; set => foodName = value; }
        public float Price { get => price; set => price = value; }
        public int Count { get => count; set => count = value; }
        public float TotalPrince { get => totalPrince; set => totalPrince = value; }
    }
}
