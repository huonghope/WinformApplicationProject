using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShareProjectWinApp.DataTransferObject
{
    public class Account
    {
        private string userName;
        private string displayName;
        private string passWord;
        private int type;
        public Account(string _userName, string _displayName, int _type, string _passWord) //Contrucstion
        {
            this.UserName = _userName;
            this.DisplayName = _displayName;
            this.Type = _type;
            this.PassWord = _passWord;
        }
        public Account(DataRow row) //해당하는 라인에서 각 열의 데이터를 꺼내서 저장
        {
            this.UserName = row["UserName"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.Type =(int) row["Type"];
            this.PassWord = row["PassWord"].ToString();
        }
        public string UserName { get => userName; set => userName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public int Type { get => type; set => type = value; }
    }
}
