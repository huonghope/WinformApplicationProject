using CShareProjectWinApp.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShareProjectWinApp.DataAccessObject
{
    class TableDAO
    {
        /// <summary>
        /// Design Pattern Singleton with TableDAO
        /// </summary>
        private static TableDAO instance;
        internal static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return instance; }
            set { TableDAO.instance = value; }
        }
        private TableDAO() { }
        //저장되어 있는 데이블 리스트를 가져와서 출력하는 메소드
        public List<Table> LoadTableList()
        {
            List<Table> result = new List<Table>();
            DataTable data = DataProvider.Instance.ExcuteQuerry("USP_GetTableList");  
            foreach (DataRow item in data.Rows)//테이블 리스트에 데이터 삽입
            {
                Table table = new Table(item);
                result.Add(table);
            }
            return result;
        }
    }
}
