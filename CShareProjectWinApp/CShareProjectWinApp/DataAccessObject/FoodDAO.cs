using CShareProjectWinApp.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShareProjectWinApp.DataAccessObject
{
    public class FoodDAO
    {
        /// <summary>
        /// Design Pattern Singleton with FoodDAO class
        /// </summary>
        private static FoodDAO instance;
        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return instance; }
            set {FoodDAO.instance = value;}
        }
        private FoodDAO() { }

        //전달된 idCategory에 근거하여 음식 리스트를 출력하는 메소드
        public List<Food> GetFoodByCategoryID(int id)
        {
            List<Food> list = new List<Food>();
            string query = "select * from Food where idCategory = " + id;
            DataTable data = DataProvider.Instance.ExcuteQuerry(query);
            foreach (DataRow item in data.Rows) //각 라인 데이터 리스트에서 삽입
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }
        //전달된 idFood에 근거하여 가격 리스트를 출력하는 메소드
        public List<Food> GetPricebyFoodID(int id)
        {
            List<Food> list = new List<Food>();
            string query = "select * from Food where id = " + id;
            DataTable data = DataProvider.Instance.ExcuteQuerry(query);
            foreach (DataRow item in data.Rows)//각 라인 데이터 리스트에서 삽입
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }
    }
}
