using CShareProjectWinApp.DataAccessObject;
using CShareProjectWinApp.DataTransferObject;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CShareProjectWinApp
{
    public partial class Admin : Form
    {
        private static string NirCmdPath = Application.StartupPath + "\\nircmd-x64\\nircmdc.exe"; //NirSoft 경로 setting
        BindingSource accountList = new BindingSource(); //아이디 
        public Account loginAccount; //현재 로그인 아이디를 저장하는 변수
        private Timer time; //대기 기능을 위한 타이머
        public Admin()
        {
            InitializeComponent();
            LoadAccountList();
            time = new Timer();
            time.Tick += new EventHandler(Timer_Setting); //Hook up Timer's tick event handler. 
        }
        /// <summary>
        /// 데이터 베이스에서 저장되어 있는 원하는 항목을 선택해서 조회
        /// </summary>
        /// <param name="pnl"></param>
        #region Show Data Event Handling
        private void ShowSelect(Panel pnl) //체크되 항목을 검사하여 데이터를 출려
        {
            RadioButton ckb = null;
            foreach (RadioButton item in pnl.Controls)
            {
                if (item.Checked)
                {
                    ckb = item;
                    break;
                }
            }
            if (ckb != null) //선텍된 항목을 이름에 근거하여 데이터를 조회 실행
            {
                string showData = ckb.Name;
                string query = "SELECT * FROM " + showData;
                dtgvData.DataSource = DataProvider.Instance.ExcuteQuerry(query);
            }
            else { //선택된 항목이 없는 경우에는 
                MessageBox.Show("먼저 조회 항목을 선택하세요", "알림",MessageBoxButtons.OK,MessageBoxIcon.Information);    
            }
        }
        private void btDateView_Click(object sender, EventArgs e) //조회 버튼을 클릭
        {
            ShowSelect(plShow);
        }
        #endregion
        /// <summary>
        /// 데이터 베이스에서 Acount date를 가져와서 출력하도록
        /// Acount 추가,설정,삭제 기능의 이벤트들
        /// </summary>
        #region Account Event Handlling 
        public void LoadAccountList() //데이트를 로드하는 함수
        {
            LoadAccout();
            dtgvAccount.DataSource = accountList; //Set the data source for dataGridView dtgvAccount to BindingSource accountList
            AddAccountBinding();
        }
        void AddAccountBinding() //Add메소드를 통해서 각 테스트 박스과 DataGridView 데이터 원본 유형의 고정됨
        {
            try
            {
                txtUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never)); //데이터를 textBox애서
                txtDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
                nudType.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
            }
            catch
            { }
        }
        void LoadAccout()
        {
            // Set data source for BindingSource AccountList
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        //기준으로 비밀번호 = 0하고 남은 정보를 받아서 아이디를 추가
        void AddCount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type)) //아이디를 추가될 경우
                MessageBox.Show("Add Account Successful");
            else
                MessageBox.Show("Add Count Fail");
            LoadAccout();
        }
        private void btAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string displayName = txtDisplayName.Text;
            int type = (int)nudType.Value;
            AddCount(userName, displayName, type);
        }
        //이름에 따라서 displayName과 type를 수정,즉 userName 수정하면 안 된다.
        void EditCount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))//아이디를 수정될 경우
                MessageBox.Show("Edit Account Successful");
            else
                MessageBox.Show("Edit Account Fail");
            LoadAccout();
        }
        private void btEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string displayName = txtDisplayName.Text;
            int type = (int)nudType.Value;
            EditCount(userName, displayName, type);
            LoadAccout();
        }
        //현재 로그인된어 있는 아이디를 삭제 할 수 없음.또한 Admin 아이디도 삭제 불가능
        void DeleteCount(string userName) 
        {
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("This Account can't delete,Error", "알림",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName)) //삭제 성공된 경우
                MessageBox.Show("Delete Account Successful", "알림");
            else
                MessageBox.Show("Delete Account Fail", "알림");
            LoadAccout();
        }
        private void btDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            DeleteCount(userName);
            LoadAccout();
        }
        //비밀번호를 변경하기 해댕하는 이름을 전달하고 새로 번호를 입력
        void ResetPassWord(string userName, string newPassWord)
        {
            if (AccountDAO.Instance.ResetPassWord(userName, newPassWord))
                MessageBox.Show("Reset PassWord Successful","알림");
            else
                MessageBox.Show("Reset PassWord Fail", "알림");
            LoadAccout();
        }
        private void rtResetPassWord_Click(object sender, EventArgs e)
        {
            string userName = txtNameRsPw.Text;
            string newPassWord = txtNewPassWord.Text;
            ResetPassWord(userName, newPassWord);
            LoadAccout();
        }
        #endregion
        /// <summary>
        /// 전원 관리 기능에 이벤트와 메소드 구성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Monitor,Computer Event Handling
        private void btSleep_Click(object sender, EventArgs e) //모니터 끄기
        {
            string result = HTTPWebCommDAO.Instance.Connection("sleep");
            serverResult.Text = result.ToString();
            Process.Start(NirCmdPath, "monitor off");
        }
        public void btWakeUp_Click(object sender, EventArgs e) //컴퓨터 시작시에 서버에 로그 기록
        {
            string result = HTTPWebCommDAO.Instance.Connection("wakeup");
            serverResult.Text = result;
        }
        private void btShutDown_Click(object sender, EventArgs e) //컴퓨터 종료시에 서버에 로그 기록
        {
            string result = HTTPWebCommDAO.Instance.Connection("shutdown");
            serverResult.Text = result;
            Process.Start(NirCmdPath, "exitwin poweroff");
        }
        // Create two StatusBarPanel objects to display in the StatusBar.
        StatusBarPanel downTimePanel;
        StatusBarPanel barPanel;
        StatusBar bar; // Create a StatusBar control.
        decimal downTime = 0; //시간을 하나씩 감소 표시하는 변수
        void LoadStatusbar(string option)
        {
            downTimePanel = new StatusBarPanel();
            barPanel = new StatusBarPanel();
            bar = new StatusBar();
         
            bar.ShowPanels = true; // Display panels in the StatusBar control.
            bar.Panels.Add(barPanel); // Add both panels to the StatusBarPanelCollection of the StatusBar.
            bar.Panels.Add(downTimePanel);

            downTimePanel.Text = "";
            barPanel.Text = "Waiting...";
            if (option.Equals("Wait"))//대기모드를 클릭할때
            {
                this.pnlWait.Controls.Add(bar); // Add the StatusBar to the Monitor wait pabel.
                return;
            }
                this.pnlHibernation.Controls.Add(bar);
        }
        //Timer 의 Tick 이벤트를 처리
        private void Timer_Setting(object sender, EventArgs e)
        {
            if (downTime > 0)
            {
                downTime--;
               downTimePanel.Text = downTime.ToString();
            }
            else
            {
                barPanel.Text = "Finish...";
                if (!btWait.Enabled) //시간이 지나면 전원 관리 기능이 실행
                {
                    string result = HTTPWebCommDAO.Instance.Connection("suspend");
                    serverResult.Text = result; //서버에서 response의 결과 출력함
                    Process.Start(NirCmdPath, "standby force");
                    btWait.Enabled = true;
                    time.Stop();
                }
                else //최대 절전모드를 실행
                {
                    string result = HTTPWebCommDAO.Instance.Connection("hibernate");
                    serverResult.Text = result;
                    Process.Start("powercfg", "-h on");
                    Process.Start("rundll32", "powrprof.dll, SetSuspendState");
                    btHibernation.Enabled = true;
                    time.Stop();
                }

            }

        } 
        //대기모드라는 버튼의 클릭의 이벤트 처리
        private void btWait_Click(object sender, EventArgs e)
        {
            if (cbWait.SelectedItem == null) //무조건 시간이 먼저 골라야 됨
            {
                MessageBox.Show("먼저 원하는 시간이 선택해주세요.", "알림", MessageBoxButtons.OK);
                return;
            }
            time.Interval = 1000; //1초마다 Tick 이벤트를 실행
            btWait.Enabled = false;
            string timeSelect = cbWait.SelectedItem.ToString();
            timeSelect = timeSelect.Substring(0,2); //ComboBox부터 선택된 시간의 값은 얻음
            downTime = decimal.Parse(timeSelect);
            LoadStatusbar("Wait");
            time.Start();
        }
        //최대 절전모드라는 버튼의 클릭의 이벤트 처리
        private void btHibernation_Click(object sender, EventArgs e)
        {
            if (cbHibnation.SelectedItem == null)
            {
                MessageBox.Show("먼저 원하는 시간이 선택해주세요.","알림",MessageBoxButtons.OK);
                return;
            }
            time.Interval = 1000;
            btHibernation.Enabled = false;
            string timeSelect = cbHibnation.SelectedItem.ToString();
            timeSelect = timeSelect.Substring(0, 2);
            downTime = decimal.Parse(timeSelect);
            LoadStatusbar("Hibernation");
            time.Start();
        }
        //대기모드 기능의 시간을 실행하다가 취고 버튼의 이벤트
        private void btWaitNo_Click(object sender, EventArgs e)
        {
            btWait.Enabled = true;
            time.Stop();
            downTimePanel.Text = "";
        }
        //최대 절전모드 기능의 시간을 실행하다가 취고 버튼의 이벤트
        private void btHibernationNo_Click(object sender, EventArgs e)
        {
            btHibernation.Enabled = true;
            time.Stop();
            downTimePanel.Text = "";
        }
        #endregion
        /// <summary>
        /// 파일을 가져오기,파일 저장하거나 파일의 내용을 인쇄 이벤트
        /// 파일의 내용을 글꼴,색깔,테스트의 박스의 배경을 변경하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region File,File Content,Link label Event Handling
        private void btOpenFile_Click(object sender, EventArgs e) //파일 가져오기
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                DefaultExt = "txt",
                Title = "파일을 선택해주세요",
                InitialDirectory = @"C:",
                Filter = "Text Files|*.txt|Allfiles|*.*",
                FilterIndex = 2,
            };
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFile.FileName, Encoding.Default);
            }
        }
        private void btSaveFile_Click(object sender, EventArgs e) //파일 저장
        {
            SaveFileDialog saveD = new SaveFileDialog()
            {
                DefaultExt = "txt",
                Title = "파일을 선택해주세요",
                InitialDirectory = @"C:",
                Filter = "Text Files|*.txt|Allfiles|*.*",
                FilterIndex = 2,
            };
            DialogResult result = saveD.ShowDialog();
            if (saveD.FileName != "" && result == DialogResult.OK) //저장할 파일의 이름이 있어야 함
            {
                using (StreamWriter sw = new StreamWriter(saveD.FileName))
                {
                    sw.Write(richTextBox1.Text);
                    sw.Close();
                }
            };
        }
        private void 글꼴ToolStripMenuItem_Click(object sender, EventArgs e) //내용의 글꼴을 변경
        {
            FontDialog fontD = new FontDialog();
            if (fontD.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontD.Font;
            }
        }
        private void 색깔ToolStripMenuItem_Click(object sender, EventArgs e) //내용의 색깔을 변경
        {
            ColorDialog colorD = new ColorDialog();
            if (colorD.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorD.Color;
            }
        }

        private void 배경ToolStripMenuItem_Click(object sender, EventArgs e) //테스트 박스의 배경을 변경
        {
            ColorDialog colorD = new ColorDialog();
            if (colorD.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = colorD.Color;
            }
        }
        private void btPrint_Click(object sender, EventArgs e) //인쇄의 이벤트
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new Font("Arial", 20, FontStyle.Italic), Brushes.Black, 150, 130);
        }
        private void linkGoogle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Google페이지를 이동함
        {
            Process.Start("https://www.google.com/");
        }
        private void linkYoutube_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Youtube패이지를 이동함
        {
            Process.Start("https://www.youtube.com/?gl=KR&hl=ko");
        }
        private void linkNaver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Naver페이지를 이동함
        {
            Process.Start("https://www.naver.com/");
        }
        #endregion
        /// <summary>
        /// 데이트 베
        /// </summary>
        /// <param name="pnl"></param>

        /// <summary>
        /// //키보드 후킹 처리하는 변수,메소드
        /// </summary>
        /// <param name="idHook"></param>
        /// <param name="callback"></param>
        /// <param name="hInstance"></param>
        /// <param name="threadId"></param>
        /// <returns></returns>
        #region KeyboardHookHandler
        private delegate IntPtr KeyboardHookHandler(int nCode, IntPtr wParam, IntPtr lParam);
        private KeyboardHookHandler hookHandler;
        private IntPtr hookID = IntPtr.Zero;
        public void Install()
        {
            hookHandler = HookFunc;
            hookID = SetHook(hookHandler);
        }
        public void Uninstall()
        {
            UnhookWindowsHookEx(hookID);
        }
        private IntPtr SetHook(KeyboardHookHandler proc)
        {
            using (ProcessModule module = Process.GetCurrentProcess().MainModule)
                return SetWindowsHookEx(13, proc, GetModuleHandle(module.ModuleName), 0);
        }
        private IntPtr HookFunc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                switch (vkCode.ToString())
                {
                    case "112": //F1 - 모니터 끄기
                        this.btSleep_Click(new object(), new EventArgs());
                        break;
                    case "113": //F2 - 컴퓨터 시작시
                        this.btWakeUp_Click(new object(), new EventArgs());
                        break;
                    case "114": //F3 - 컴퓨터 끄기
                        this.btShutDown_Click(new object(), new EventArgs());
                        break;
                    case "115": //F5 - 대기모드
                        this.btWait_Click(new object(), new EventArgs());
                        break;
                    case "116": //F6 - 최대 절전모드
                        this.btHibernation_Click(new object(), new EventArgs());
                        break;
                }
                return (IntPtr)1;
            }
            else
                return CallNextHookEx(hookID, nCode,wParam, lParam);
        }

        #region WinAPI
        private const int WM_KEYDOWN = 0x100;
        private const int WM_SYSKEYDOWN = 0x104;
        private const int WM_KEYUP = 0x101;
        private const int WM_SYSKEYUP = 0x105;
         private const int WH_KEYBOARD_LL = 13;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, KeyboardHookHandler lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion
        private void tabControl1_Selected(object sender, TabControlEventArgs e) //이장에서만 후킹 되는것임
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                Install();
            }
            else
            {
                Uninstall(); //End Hoonking
            }
        }
        #endregion
    }
}

