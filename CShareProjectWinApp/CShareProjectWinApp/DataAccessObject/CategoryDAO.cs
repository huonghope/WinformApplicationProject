using CShareProjectWinApp.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShareProjectWinApp.DataTransferObject
{
    public class CategoryDAO
    {
        /// <summary>
        /// Design Pattern Singleton with CategoryDAO
        /// </summary>
        private static CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return instance; }
            set { CategoryDAO.instance = value; }
        }
        private CategoryDAO() { }

        //현재 저장되어 있는 음식 종류의 데이터를 출력
        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();
            string query = "select * from FoodCategory";
            DataTable data = DataProvider.Instance.ExcuteQuerry(query);
            foreach(DataRow item in data.Rows)//각 라인의 데이터 리스터 넣음
            {
                Category category = new Category(item);
                list.Add(category);
            }
            return list;
        }
    }
}
