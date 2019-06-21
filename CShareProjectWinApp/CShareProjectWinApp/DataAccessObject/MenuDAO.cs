using CShareProjectWinApp.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CShareProjectWinApp.DataAccessObject
{
    public class MenuDAO
    {
        /// <summary>
        /// Design Pattern Singleton with MenuDAO
        /// </summary>
        private static MenuDAO instance;
        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return instance; }
            set { MenuDAO.instance = value; }
        }
        private MenuDAO() { }

        //전달된 테이블 id에 근거하면 메뉴 리스트를 출력하는 메소드
        public List<MenuByTable> GetListMenuByTable(int id)
        {
            List<MenuByTable> listmenu = new List<MenuByTable>();
            //3 테이블에서 관계을 맺는 필드를 통해서 결과를 얻음
            string query = "SELECT f.name,bi.count ,f.price,f.price* bi.count AS totalPrice FROM Food AS f,BillInfo AS bi,Bill AS b WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.status = 0 AND b.idTable = " + id;
            DataTable data = DataProvider.Instance.ExcuteQuerry(query);
            foreach (DataRow item in data.Rows)
            {
                MenuByTable menu = new MenuByTable(item);
                listmenu.Add(menu);
            }
            return listmenu;
        }
    }
}
