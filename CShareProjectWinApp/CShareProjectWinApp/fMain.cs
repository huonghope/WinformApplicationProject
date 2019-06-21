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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace CShareProjectWinApp
{
    public partial class fMain : Form
    {
        private Account loginAccount; //현재 로그인 계정을 저장하는 변수
        public Account LoginAccount {
            get { return loginAccount; }
            set
            {
                this.loginAccount = value;
                ChangAccount(loginAccount.Type);
            }
        }
        public fMain(Account _account)
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
            this.LoginAccount = _account;
        }
        #region Load Table,Catgory,Food - Show Bill,Food,Price Access
        private void LoadCategory() //데이터베이스에서 저장되어 있는 음식 종류 함목들을 로드
        {
            List<Category> category = CategoryDAO.Instance.GetListCategory(); //로드된 데이터를 리스트에 삽입
            int btWidth = 94;
            int btHeight = 53;
            foreach (Category item in category) //각 항목들을 버튼에서 표시하여 FlowLayoutPanel에서 삽입
            {
                Button btn = new Button() { Width = btWidth, Height = btHeight };
                btn.Text = item.Name;
                btn.Tag = item; //각 버튼에 Tag값은 설정(Category 객체)
                btn.BackColor = Color.Silver;
                btn.Click += btn_ClickCategory;
                flpCategory.Controls.Add(btn);
            }
        }
        private void LoadFoodListByCategory(int _idCategory)//Category의 Id에 근거하여 데이터를 꺼내서 출력하는 메소드
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(_idCategory);
            cbFood.DataSource = listFood; //Combobox에서 Name라는 property 출력함
            cbFood.DisplayMember = "Name";
        }
        void btn_ClickCategory(object sender, EventArgs e) //각 Category 버튼을 클릭의 이벤트 처리
        {
            int idCategory = ((sender as Button).Tag as Category).ID;
            LoadFoodListByCategory(idCategory);
        }
        private void LoadPriceListByFoodID(int id)// 전달된 idFood에 근거하여 가격을 출력할다
        {
            List<Food> listFood = FoodDAO.Instance.GetPricebyFoodID(id);
            cbPrice.DataSource = listFood;//Combobox에서 Price라는 property 출력함
            cbPrice.DisplayMember = "Price";
        }
        private void cbFood_SelectedIndexChanged(object sender, EventArgs e) //Combobox Food에서 항목들을 선택하는 이벤트 처리
        {
            int id;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Food selected = cb.SelectedItem as Food;
            id = selected.ID;
            LoadPriceListByFoodID(id);
        }
        //==========================================================================================================
        private void LoadTable() //데이터베이스에서 저장되어 있는 테이블 데이터 로드
        {
            flpTable.Controls.Clear(); //로드할때마다 FlowLayoutPanel removes all items
            List<Table> tableList = TableDAO.Instance.LoadTableList(); //데이터 베이스테서 데이터를 얻어서 리스트를 저장함
            int btWidth = 75;
            int btHeight = 80;
            foreach(Table item in tableList)
            {
                Button btn = new Button() { Width = btWidth, Height = btHeight };
                btn.Text = item.Name + Environment.NewLine;
                btn.Click += btn_Click;
                btn.Tag = item; //태스 값을 설정
                btn.BackColor = Color.Silver;
                if (item.Status.Equals("DONT HAVE")) //테이블 상태가 주문한 항목이 없으면 배경을 변경
                {
                    btn.BackColor = Color.Red;
                }
                flpTable.Controls.Add(btn); //각 버튼을 FlowLayoutPanel에서 삽입
            }
        }
        float totalPrice;
        void Show_Bill(int _idTable)
        {
            lsvBill.Items.Clear(); //로드할때마다 ListVew removes  all items
            //List<BillInfo> listBillInfo = BillInfoDAO.Instance.GetListBillInfo(BillDAO.Instance.GetUnCheckBillIdbyTableID(_idTable));
            List<MenuByTable> listBillInfo = MenuDAO.Instance.GetListMenuByTable(_idTable);
            totalPrice = 0; //주문한 것을 총 금액 저장하는 변수 
            foreach (MenuByTable item in listBillInfo) //각 주문한 항목들을 ListView에서 출력함
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrince.ToString());
                totalPrice += item.TotalPrince;
                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("euc-KR");
            txttotalPrice.Text = totalPrice.ToString("c", culture); //긍액을 한국의 돈 style로 display
        }
        void btn_Click(object sender,EventArgs e) //테이블 버튼 클릭하는 이벤트 처리
        {
            int idTable = ((sender as Button).Tag as Table).Id;
            lsvBill.Tag = (sender as Button).Tag;
            Show_Bill(idTable);
        }
        void ChangAccount(int type) //관리자이든지 직원이든지 관리라는 버튼의 상태 지정
        {
            adMStrip.Enabled = type == 1; 
            lbLoginUserName.Text = "로그인 : " + this.LoginAccount.DisplayName.ToString(); //현재 로그인자 출력함
        }
        #endregion
        #region Button : Status,Click - AddFood,Print Bill,Sale
        private void 관리정보ToolStripMenuItem_Click(object sender, EventArgs e) //관리라는 버튼의 클릭 이벤트 처리
        {
            Admin admin = new Admin();
            admin.loginAccount = LoginAccount;
            admin.ShowDialog();
        }
        private void 로그인ToolStripMenuItem1_Click(object sender, EventArgs e)//로그인라는 버튼의 클릭 이벤트 처리
        {
            Login lg = new Login();
            this.Hide();
            lg.ShowDialog();
        }
        private void 여가ToolStripMenuItem_Click(object sender, EventArgs e) //여가라는 버튼으 클릭 이벤트 처리
        {
            Game game = new Game();
            game.Show();
        }
        private void btAddFood_Click(object sender, EventArgs e) //주문이라는 버튼 클릭이벤트 처리
        {
            Table table = lsvBill.Tag as Table; //현재 클릭 테이블과 ListView에서 출력하는 Bill 지정
            int idBill = BillDAO.Instance.GetUnCheckBillIdbyTableID(table.Id); //현재 테이블의 id값을 전달해서 Billd가 존재하는지 테스트
            int foodID = (cbFood.SelectedItem as Food).ID; //선택된 음식 항목 값은 저장
            int count = (int)nudFoodCount.Value; //해당하는 음식을 선택된 개수 저장
            if (idBill == -1)//현재 테이블이 Bill가 존재하지 않은 경우에는 Bill추가하면 BillInfo를 만듦
            {
                BillDAO.Instance.InsertBill(table.Id);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIdBill(), foodID, count);
            }
            else//현재 테이블에 Bill가 이미 존재해 있음
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
            }
            Show_Bill(table.Id); //ListView 다시 로드
            LoadTable(); //Table 다시 로드
        }
        private void checkOut_Click(object sender, EventArgs e)//결제시에 일어나는 이벤트 처리
        {
            Table table = lsvBill.Tag as Table;
            int idBill = BillDAO.Instance.GetUnCheckBillIdbyTableID(table.Id);
            if(idBill != -1) //해당하는 idTable과 idBill 맞음
            {
                if (MessageBox.Show(table.Name + "결제를 진행하시겠습니까?", "Infomation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill); //Bill에서 idBill의 상태 변경
                    Show_Bill(table.Id);//ListView 다시 로드
                    LoadTable();//Table 다시 로드
                }
            }
        }
        private void btShowBill_Click(object sender, EventArgs e) //영수증이라는 버튼 클릭 이벤트 처리
        {
            Table table = lsvBill.Tag as Table; 
            fBill bill = new fBill();
            bill.ShowBill(this.loginAccount.DisplayName, txttotalPrice.Text,table.Id);//idTable를 전달해서 주문한 정보들을 출력
            bill.ShowDialog();
        }
        private void btSale_Click(object sender, EventArgs e) //할인이라는 버튼 클릭 이벤트
        {
            if (cbSale.SelectedItem == null)
            {
                MessageBox.Show("먼저 할인 금액을 선택하세요.");
                return;
            }
            float Sale = (float)Convert.ToDouble(cbSale.SelectedItem);
            totalPrice -= Sale;
            if (totalPrice <= 0f)
            {
                MessageBox.Show("할인 금액을 만족하지 않습니다.");
                return;
            }
            CultureInfo culture = new CultureInfo("euc-KR");
            txttotalPrice.Text = totalPrice.ToString("c", culture);
        }
        #endregion
        #region NotifiIcon Event Handling
        private void fMain_Resize(object sender, EventArgs e) //폼의 사이즈에 따라서 nofiIcon의 상태 지정
        {
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            if (this.WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
            if (this.WindowState == FormWindowState.Normal)
            {
                ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }
        private void fMain_FormClosing(object sender, FormClosingEventArgs e) //품의 닫을때 발생하는 이벤트 처리
        {
            e.Cancel = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }
        private void 화면보기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            //this.WindowState = System.Windows.Forms.FormWindowState.Normal;
        }
        private void 로그인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
        }
        private void 게임실행ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.ShowDialog();
        }
        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e) //종료라는 버튼 이벤트 처리
        {
            //Application.Exit();
            Environment.Exit(1);
        }
        #endregion

    }
}
