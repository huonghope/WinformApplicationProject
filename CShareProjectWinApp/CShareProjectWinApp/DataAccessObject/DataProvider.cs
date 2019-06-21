using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShareProjectWinApp.DataAccessObject
{
    public class DataProvider
    {
        /// <summary>
        /// Design Pattern Singleton with DataProvider Class
        /// </summary>
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        //연결할 SQL 서버 이름 지정
        //connect server DESKTOP-BDLJEER with database name is CaffeDB
        private string connSTR = @"Data Source=DESKTOP-BDLJEER;Initial Catalog=CaffeDB;Integrated Security=True";

        // 명령어를 전달해서 SQL에서 실행해주는 메소드,리턴 데이터 테이블
        public DataTable ExcuteQuerry(string exQuery, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connSTR))
            {    
                conn.Open();  //데이터베이스 열기
                SqlCommand command = new SqlCommand(exQuery, conn); //Instantiate a new command with a query and connection
                if (parameter != null) //Query명령어를 매개변수 포하는 경우에는 명령어를 따서 처리하야 실행
                {
                    string[] listPara = exQuery.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@")) //각 매개변수를 전달함
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command); //중간에 데이트를 꺼내주는 객체
                adapter.Fill(data); //Fill 메소드 실행하여 결과 DataTable를 리턴 받음
                conn.Close(); //데이터베이스 닫기
            }

            return data;
        }

        //SQL에서 해당하는 명령어를 실행 성공하는지 안 하는지 출력하는 메소드
        public int ExcuteNonQuerry(string exQuery, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection conn = new SqlConnection(connSTR))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(exQuery, conn);
                if (parameter != null)
                {
                    string[] listPara = exQuery.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                try
                {
                    data = command.ExecuteNonQuery();
                }
                catch
                {
                    return -1;
                }
                conn.Close();
            }
            return data;
        } //SQL에서 실행된 라인 명령어 출력

        //테이블 행의 개수를 가져와서 출력하는 메소드
        public object ExcuteScalar(string exQuery, object[] parameter = null)
        {
            object data = new object();
            using (SqlConnection conn = new SqlConnection(connSTR))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(exQuery, conn);
                if (parameter != null)
                {
                    string[] listPara = exQuery.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                conn.Close();
            }
            return data;
        } //Result Select Count
    }
}
