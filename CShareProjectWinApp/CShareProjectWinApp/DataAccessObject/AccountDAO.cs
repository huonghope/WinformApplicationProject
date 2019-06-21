using CShareProjectWinApp.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShareProjectWinApp.DataAccessObject
{
    public class AccountDAO
    {
        /// <summary>
        /// Design Pattern Singleton with Account Class
        /// </summary>
        private static AccountDAO instance;
        public static AccountDAO Instance {
            get { if (instance == null)
                    instance = new AccountDAO();
                return instance; }
            set { AccountDAO.instance = value; }
        }
        private AccountDAO() { } 
        //입력받은 계정의 정보 이름,비밀번호를 이미 있는지 없는지 검사
        public bool LoginCheck(string _userName, string _password)
        {
            string query = "dbo.USP_LoginCheck @userName , @passWOrd";
            DataTable result = DataProvider.Instance.ExcuteQuerry(query,new object[] {_userName,_password});
            return result.Rows.Count > 0; //출력된 결과가 있는지 없는지,
        }
        //전달된 이름을 이용해서 해당하는 계정을 존재하는지 검사
        public Account GetAccountByUserName(string _userName)
        {
            DataTable data = DataProvider.Instance.ExcuteQuerry("SELECT * FROM Account WHERE UserName = '" + _userName + "'");
            foreach(DataRow item in data.Rows)
           {
                return new Account(item);
           }
            return null;
        }
        //데이트 베이스에서 저장되어 있는 모든 계정들을 출력함
        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExcuteQuerry("SELECT UserName, DisplayName, Type FROM Account");
        }
        //입력한 정보들을 이름,표시 이름을 매개변수를 전달해서 계정데이트 삽입,안 되다면 false 출력 - 추가 기능
        public bool InsertAccount(string userName,string displayName,int type)
        {
            string query = string.Format("INSERT Account (UserName, DisplayName, Type) VALUES ('{0}', '{1}', {2})", userName, displayName, type);
            int result = DataProvider.Instance.ExcuteNonQuerry(query);  //실행 안 되다면 음수를 출력햐서 함수 리턴 false
            return result > 0; 
        }
        //입력한 이름에 근거하여 이름과 같은 계정의 정보를 변경,즉 이름에 근거하여 - 수정기능
        public bool UpdateAccount(string userName,string displayName,int type)
        {
            string query = string.Format("UPDATE Account SET DisplayName = '{1}', Type = {2} WHERE UserName = '{0}'", userName, displayName, type);
            int result = DataProvider.Instance.ExcuteNonQuerry(query);
            return result > 0;
        }
        //입력한 이름에 근거하여 계정의 정보를 찾아서 계정을 지우다,관리자의아이디를 지울 수 없음 - 삭제 기능
        public bool DeleteAccount(string userName) 
        {
            string query = string.Format("Delete Account WHERE UserName = '{0}' AND Type != 1", userName);
            int result = DataProvider.Instance.ExcuteNonQuerry(query);
            return result > 0;
        }
        //입력한 이름에 근거하여 계정 정보를 찾아서 비밀번호를 변경함 - 변경 기능
        public bool ResetPassWord(string userName,string newPassWord)
        {
            string query = string.Format("UPDATE Account SET PassWord = '{1}'  WHERE UserName = '{0}'", userName,newPassWord);
            int result = DataProvider.Instance.ExcuteNonQuerry(query);
            return result > 0;
        }
    }
}
