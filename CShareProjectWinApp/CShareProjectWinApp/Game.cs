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
    public partial class Game : Form
    {
        private Rectangle[] blackBlock = new Rectangle[100];
        Rectangle redblock;
        private Timer time;
        private string keyArrow;

        private int countBlock;
        public Game()
        {
            InitializeComponent();

        }
        //키워드(Down,Up,Left,Right)를 누를때 생기는 이벤드 처리
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //올라가는 상태에서 내리려고하는 베튼을 누를 수 없음
            //Capture up arrow key
            if (blackBlock[0].Y != blackBlock[1].Y + 10 && keyData == Keys.Up)
            {
                keyArrow = "UP";
                return true;
            }
            //Capture down arrow key
            if (blackBlock[0].Y != blackBlock[1].Y - 10 && keyData == Keys.Down)
            {
                keyArrow = "DOWN";
                return true;
            }
            //왼 - 오른쪽으로 가는 상태에서 받대 쪽의 가는 버튼을 누를 수 없음
            //Capture left arrow key
            if (blackBlock[0].X != blackBlock[1].X + 10 && keyData == Keys.Left)
            {
                keyArrow = "LEFT";
                return true;
            }
            //Capture right arrow key
            if (blackBlock[0].X != blackBlock[1].X - 10 && keyData == Keys.Right)
            {
                keyArrow = "RIGHT";
                return true;
            }
            panel1.Invalidate();
            return base.ProcessCmdKey(ref msg, keyData);
        }
        //타이머의 이벤트 처리
        private void Timer_Setting(object sender, EventArgs e)
        {
            //입력한 키워드에 따라 각 blackBlock의 위치를 다시 설정함
            if (keyArrow == "UP")
            {
                for (int i = countBlock; i > 0; i--)
                    blackBlock[i] = blackBlock[i - 1];
                blackBlock[0].Y -= 10;
            }
            if (keyArrow == "DOWN")
            {
                for (int i = countBlock; i > 0; i--)
                    blackBlock[i] = blackBlock[i - 1];
                blackBlock[0].Y += 10;

            }
            if (keyArrow == "LEFT")
            {
                for (int i = countBlock; i > 0; --i)
                    blackBlock[i] = blackBlock[i - 1];
                blackBlock[0].X -= 10;
            }
            if (keyArrow == "RIGHT")
            {
                for (int i = countBlock; i > 0; --i)
                    blackBlock[i] = blackBlock[i - 1];
                blackBlock[0].X += 10;
            }
            //첫분째 blackBlock의 위치를 panel의 위치를 벗어나면 게임 끝나는 결과를 얻는다.
            bool State_X = ((blackBlock[0].X + 10 == 0 || blackBlock[0].X == panel1.Width)) ? true : false;
            bool State_Y = ((blackBlock[0].Y + 10 == 0) || (blackBlock[0].Y == panel1.Height)) ? true : false;
            if (State_X || State_Y)
            {
                this.time.Stop();
                this.time.Enabled = false;
                MessageBox.Show("You Die");
                return;

            }
            //첫번째 blackBlock 다른 blackBlock를 만난다(위치를 파악해서 해결)면 게임 끝남
            for (int i = 1; i < countBlock; i++)
            {
                if (blackBlock[0].Location == blackBlock[i].Location)
                {
                    this.time.Stop();
                    MessageBox.Show("You Die");
                    return;
                }
            }
            //pabal1의 그림을 그리는 이벤트를 다시 부름
            panel1.Invalidate();
            //Snake를 먹이을 만날때 먹어서 새로운 먹이를 램덤하게 생선
            if (blackBlock[0].Location == redblock.Location)
            {
                Random rnd = new Random();
                progressBar1.Value += 10;
                //10개의 먹은 경우에는 레벨이 1씩 증가하려하거나 다시 시각하냐고 물어봐서 처리
                if (progressBar1.Value == 100)
                {
                    this.time.Stop();
                    DialogResult result = MessageBox.Show("You Wined with Level" + numericUpDown1.Value + ".Continue(Y) or Reset (N)!!!", "Message", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        progressBar1.Value = 0;
                        numericUpDown1.Value++;
                        time.Interval = 1000 / (int)numericUpDown1.Value;
                        time.Start();
                    }
                    else
                    {
                        //Application.Reset();
                        progressBar1.Value = 0;
                        numericUpDown1.Value = 1;
                        button1_Click(sender, e);
                        return;
                    }

                }
                //panel의 사이즈에 따라서 먹이의 위치를 랜덤하게 설정
                redblock.Location = new Point(rnd.Next(0, 56) * 10, rnd.Next(0, 31) * 10);
                //Snake는 먹이를 하나 먹을때마나 길이 증가함
                blackBlock[++countBlock] = new Rectangle(blackBlock[countBlock - 1].X, blackBlock[countBlock - 1].Y, 10, 10);
            }

        }
        //panel는 그림을 그리는 이벤트
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(System.Drawing.Brushes.Red, redblock);
            g.FillRectangle(System.Drawing.Brushes.Violet, blackBlock[0]);
            for (int i = 1; i < countBlock; i++)
                g.FillRectangle(System.Drawing.Brushes.Black, blackBlock[i]);
        }
        //게임을 시작하기 위해서 버튼을 클릭의 이벤트
        private void button1_Click(object sender, EventArgs e)
        {
            time = new Timer(); //타이머 생선
            time.Start();       //타이머 시작
            time.Tick += new EventHandler(Timer_Setting);
            redblock = new Rectangle(100, 100, 10, 10);
            blackBlock[0] = new Rectangle(150, 200, 10, 10);
            blackBlock[1] = new Rectangle(160, 200, 10, 10);
            blackBlock[2] = new Rectangle(170, 200, 10, 10);
            blackBlock[3] = new Rectangle(180, 200, 10, 10);
            blackBlock[4] = new Rectangle(190, 200, 10, 10);
            countBlock = 5;
            progressBar1.Value = 0;
            time.Interval = 1000 / (int)numericUpDown1.Value; //레블이 증가함에 따라 Snake 속도 설정
            label4.Visible = false;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
