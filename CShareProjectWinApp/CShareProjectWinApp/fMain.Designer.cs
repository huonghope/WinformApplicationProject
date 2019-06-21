namespace CShareProjectWinApp
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbSale = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.btShowBill = new System.Windows.Forms.Button();
            this.btSale = new System.Windows.Forms.Button();
            this.checkOut = new System.Windows.Forms.Button();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.nudFoodCount = new System.Windows.Forms.NumericUpDown();
            this.btAddFood = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adMStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.관리정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proMStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.여가ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그인ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.flpCategory = new System.Windows.Forms.FlowLayoutPanel();
            this.txttotalPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.cbPrice = new System.Windows.Forms.ComboBox();
            this.lbLoginUserName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.화면보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그인ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.게임실행ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFoodCount)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbSale);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.btShowBill);
            this.panel2.Controls.Add(this.btSale);
            this.panel2.Controls.Add(this.checkOut);
            this.panel2.Location = new System.Drawing.Point(682, 155);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(133, 299);
            this.panel2.TabIndex = 1;
            // 
            // cbSale
            // 
            this.cbSale.FormattingEnabled = true;
            this.cbSale.Items.AddRange(new object[] {
            "1000",
            "2000",
            "3000",
            "4000",
            "5000",
            "6000",
            "7000",
            "8000",
            "9000",
            "10000"});
            this.cbSale.Location = new System.Drawing.Point(0, 228);
            this.cbSale.Name = "cbSale";
            this.cbSale.Size = new System.Drawing.Size(133, 21);
            this.cbSale.TabIndex = 11;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Red;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(3, 268);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(133, 31);
            this.button7.TabIndex = 10;
            this.button7.Text = "신고";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // btShowBill
            // 
            this.btShowBill.BackColor = System.Drawing.Color.Silver;
            this.btShowBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btShowBill.Location = new System.Drawing.Point(0, 76);
            this.btShowBill.Name = "btShowBill";
            this.btShowBill.Size = new System.Drawing.Size(133, 53);
            this.btShowBill.TabIndex = 9;
            this.btShowBill.Text = "영수증 출력";
            this.btShowBill.UseVisualStyleBackColor = false;
            this.btShowBill.Click += new System.EventHandler(this.btShowBill_Click);
            // 
            // btSale
            // 
            this.btSale.BackColor = System.Drawing.Color.Silver;
            this.btSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSale.Location = new System.Drawing.Point(0, 152);
            this.btSale.Name = "btSale";
            this.btSale.Size = new System.Drawing.Size(133, 53);
            this.btSale.TabIndex = 8;
            this.btSale.Text = "할인";
            this.btSale.UseVisualStyleBackColor = false;
            this.btSale.Click += new System.EventHandler(this.btSale_Click);
            // 
            // checkOut
            // 
            this.checkOut.BackColor = System.Drawing.Color.Silver;
            this.checkOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkOut.Location = new System.Drawing.Point(0, 0);
            this.checkOut.Name = "checkOut";
            this.checkOut.Size = new System.Drawing.Size(133, 53);
            this.checkOut.TabIndex = 5;
            this.checkOut.Text = "현금";
            this.checkOut.UseVisualStyleBackColor = false;
            this.checkOut.Click += new System.EventHandler(this.checkOut_Click);
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBill.GridLines = true;
            this.lsvBill.Location = new System.Drawing.Point(366, 156);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(298, 249);
            this.lsvBill.TabIndex = 0;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "상품명";
            this.columnHeader1.Width = 86;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "수량";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 38;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "정가";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 84;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "금액";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 112;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nudFoodCount);
            this.panel4.Controls.Add(this.btAddFood);
            this.panel4.Location = new System.Drawing.Point(680, 39);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(133, 53);
            this.panel4.TabIndex = 3;
            // 
            // nudFoodCount
            // 
            this.nudFoodCount.Location = new System.Drawing.Point(93, 18);
            this.nudFoodCount.Name = "nudFoodCount";
            this.nudFoodCount.Size = new System.Drawing.Size(40, 20);
            this.nudFoodCount.TabIndex = 3;
            this.nudFoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btAddFood
            // 
            this.btAddFood.BackColor = System.Drawing.Color.Silver;
            this.btAddFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddFood.Location = new System.Drawing.Point(0, 0);
            this.btAddFood.Name = "btAddFood";
            this.btAddFood.Size = new System.Drawing.Size(94, 53);
            this.btAddFood.TabIndex = 2;
            this.btAddFood.Text = "주문";
            this.btAddFood.UseVisualStyleBackColor = false;
            this.btAddFood.Click += new System.EventHandler(this.btAddFood_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adMStrip,
            this.proMStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(827, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adMStrip
            // 
            this.adMStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.관리정보ToolStripMenuItem});
            this.adMStrip.Name = "adMStrip";
            this.adMStrip.Size = new System.Drawing.Size(43, 20);
            this.adMStrip.Text = "관리";
            // 
            // 관리정보ToolStripMenuItem
            // 
            this.관리정보ToolStripMenuItem.Name = "관리정보ToolStripMenuItem";
            this.관리정보ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.관리정보ToolStripMenuItem.Text = "사업 관리";
            this.관리정보ToolStripMenuItem.Click += new System.EventHandler(this.관리정보ToolStripMenuItem_Click);
            // 
            // proMStrip
            // 
            this.proMStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.여가ToolStripMenuItem,
            this.로그인ToolStripMenuItem1});
            this.proMStrip.Name = "proMStrip";
            this.proMStrip.Size = new System.Drawing.Size(43, 20);
            this.proMStrip.Text = "작업";
            // 
            // 여가ToolStripMenuItem
            // 
            this.여가ToolStripMenuItem.Name = "여가ToolStripMenuItem";
            this.여가ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.여가ToolStripMenuItem.Text = "여가";
            this.여가ToolStripMenuItem.Click += new System.EventHandler(this.여가ToolStripMenuItem_Click);
            // 
            // 로그인ToolStripMenuItem1
            // 
            this.로그인ToolStripMenuItem1.Name = "로그인ToolStripMenuItem1";
            this.로그인ToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.로그인ToolStripMenuItem1.Text = "로그인";
            this.로그인ToolStripMenuItem1.Click += new System.EventHandler(this.로그인ToolStripMenuItem1_Click);
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.Location = new System.Drawing.Point(13, 38);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(347, 256);
            this.flpTable.TabIndex = 5;
            // 
            // flpCategory
            // 
            this.flpCategory.Location = new System.Drawing.Point(365, 36);
            this.flpCategory.Name = "flpCategory";
            this.flpCategory.Size = new System.Drawing.Size(302, 57);
            this.flpCategory.TabIndex = 6;
            // 
            // txttotalPrice
            // 
            this.txttotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotalPrice.Location = new System.Drawing.Point(367, 424);
            this.txttotalPrice.Multiline = true;
            this.txttotalPrice.Name = "txttotalPrice";
            this.txttotalPrice.Size = new System.Drawing.Size(298, 30);
            this.txttotalPrice.TabIndex = 8;
            this.txttotalPrice.Text = "0";
            this.txttotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(369, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "총매출액 =";
            // 
            // cbFood
            // 
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(367, 98);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(298, 21);
            this.cbFood.TabIndex = 10;
            this.cbFood.SelectedIndexChanged += new System.EventHandler(this.cbFood_SelectedIndexChanged);
            // 
            // cbPrice
            // 
            this.cbPrice.FormattingEnabled = true;
            this.cbPrice.Location = new System.Drawing.Point(367, 126);
            this.cbPrice.Name = "cbPrice";
            this.cbPrice.Size = new System.Drawing.Size(298, 21);
            this.cbPrice.TabIndex = 11;
            // 
            // lbLoginUserName
            // 
            this.lbLoginUserName.AutoSize = true;
            this.lbLoginUserName.BackColor = System.Drawing.Color.Silver;
            this.lbLoginUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoginUserName.Location = new System.Drawing.Point(683, 113);
            this.lbLoginUserName.Name = "lbLoginUserName";
            this.lbLoginUserName.Size = new System.Drawing.Size(0, 22);
            this.lbLoginUserName.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("휴먼명조", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Indigo;
            this.label3.Location = new System.Drawing.Point(119, 472);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(587, 21);
            this.label3.TabIndex = 13;
            this.label3.Text = "저의 식당에 와주셔서 감사합니다  ☺  안녕히 가십시오 ♪";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 300);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(344, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "외식업 포스(POS)";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.화면보기ToolStripMenuItem,
            this.로그인ToolStripMenuItem,
            this.게임실행ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(126, 92);
            // 
            // 화면보기ToolStripMenuItem
            // 
            this.화면보기ToolStripMenuItem.Name = "화면보기ToolStripMenuItem";
            this.화면보기ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.화면보기ToolStripMenuItem.Text = "화면 보기";
            this.화면보기ToolStripMenuItem.Click += new System.EventHandler(this.화면보기ToolStripMenuItem_Click);
            // 
            // 로그인ToolStripMenuItem
            // 
            this.로그인ToolStripMenuItem.Name = "로그인ToolStripMenuItem";
            this.로그인ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.로그인ToolStripMenuItem.Text = "로그인";
            // 
            // 게임실행ToolStripMenuItem
            // 
            this.게임실행ToolStripMenuItem.Name = "게임실행ToolStripMenuItem";
            this.게임실행ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.게임실행ToolStripMenuItem.Text = "게임 실행";
            this.게임실행ToolStripMenuItem.Click += new System.EventHandler(this.게임실행ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 511);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbLoginUserName);
            this.Controls.Add(this.cbPrice);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cbFood);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txttotalPrice);
            this.Controls.Add(this.lsvBill);
            this.Controls.Add(this.flpCategory);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2017112154_응웬딩흐엉";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing);
            this.Resize += new System.EventHandler(this.fMain_Resize);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudFoodCount)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adMStrip;
        private System.Windows.Forms.ToolStripMenuItem proMStrip;
        private System.Windows.Forms.NumericUpDown nudFoodCount;
        private System.Windows.Forms.Button btAddFood;
        private System.Windows.Forms.ToolStripMenuItem 여가ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 관리정보ToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btShowBill;
        private System.Windows.Forms.Button btSale;
        private System.Windows.Forms.Button checkOut;
        private System.Windows.Forms.FlowLayoutPanel flpCategory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txttotalPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.ComboBox cbPrice;
        private System.Windows.Forms.Label lbLoginUserName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSale;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 로그인ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 게임실행ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 화면보기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그인ToolStripMenuItem1;
    }
}

