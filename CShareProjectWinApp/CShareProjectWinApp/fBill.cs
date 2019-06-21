using CShareProjectWinApp.DataAccessObject;
using CShareProjectWinApp.DataTransferObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CShareProjectWinApp
{
    public partial class fBill : Form
    {
        public fBill()
        {
            InitializeComponent();
        }
        //fMain에서 매개변수를 받아서 계산서를 출력하는 메소드
        public void ShowBill(string _name, string _totalCount, int _idTable)
        {
            DateTime localData = DateTime.Now;
            CultureInfo culture = new CultureInfo("euc-KR"); //한국 돈의 단위로 표시하기 위한
            this.lbName.Text = _name;
            this.lbTime.Text = localData.ToString(culture);
            List<MenuByTable> listBillInfo = MenuDAO.Instance.GetListMenuByTable(_idTable); //Id 테이블을 통해서 메뉴 리스트 값들을 얻는다
            foreach (MenuByTable item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrince.ToString());
                listView.Items.Add(lsvItem);
            }
            this.tbTotalCount.Text = _totalCount.ToString();
        }
        private void 인쇄ToolStripMenuItem_Click(object sender, EventArgs e) //인쇄의 이벤트 처리
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(this.listView.ToString(), new Font("Arial", 20, FontStyle.Italic), Brushes.Black, 150, 130);
        }

    }
}
