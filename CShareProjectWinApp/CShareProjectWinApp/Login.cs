using CShareProjectWinApp.DataAccessObject;
using CShareProjectWinApp.DataTransferObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CShareProjectWinApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        //Login button
        private void button1_Click(object sender, EventArgs e)
        {
            string userName = userNametb.Text;
            string passWord = passWordtb.Text;
            if (LoginCheck(userName, passWord))
            {
                //이름 통해서 데이스베이스를 계정 정보를 받아서 fMain 같이 보내기
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                fMain _fMain = new fMain(loginAccount);
                this.Hide();
                _fMain.ShowDialog(); //main form 호출한다.
            }
            else
            {
                MessageBox.Show("로그인 실패");
            }
        }
        bool LoginCheck(string _userName,string _passWord)
        {

            return AccountDAO.Instance.LoginCheck(_userName,_passWord);
        }
        //Exit 버튼을 누를때 프로그램을 종료하기 물어보고 처리
        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("프로그램 종료 하시겠습니다?","알림",MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btEnd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("프로그램 종료 하시겠습니다?", "알림", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
