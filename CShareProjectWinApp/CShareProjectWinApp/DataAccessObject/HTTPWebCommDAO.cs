using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CShareProjectWinApp.DataAccessObject
{
    public class HTTPWebCommDAO
    {
        /// <summary>
        /// Design Pattern Singleton with HTTPWebCommDAO
        /// </summary>
        private static HTTPWebCommDAO instance;
        public static HTTPWebCommDAO Instance
        {
            get { if (instance == null) instance = new HTTPWebCommDAO(); return instance; }
            set { HTTPWebCommDAO.instance = value; }
        }

        private HTTPWebCommDAO() { }

        //해댕하는 액션에 연결된 결과를 출력
        public string Connection(string action)
        {
            string result = "";
            this.SetURL("http://210.94.194.82:52131/log.asp?id=2017112154&cmd=write&action=" + action);
            this.setMessage("");
            this.Reqeust();
            result = this.Response();
            if (result.Equals(""))
            {
                return "서버의 음답 없음";
            }
            return result;
        }
        string URL;
        string message;
        string resultStr;
        HttpWebRequest request;
        public void SetURL(string url) //경로 지정
        {
            URL = url;
        }
        public void setMessage(string msg) //메시지 지정
        {
            message = msg;
        }
        public void Reqeust() //서버에 요구 보니
        {
            request = (HttpWebRequest)WebRequest.Create(URL);
            byte[] sendData = UTF8Encoding.UTF8.GetBytes(message);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Method = "POST";
            StreamWriter sw = new StreamWriter(request.GetRequestStream());
            sw.Write(message);
            sw.Close();
        }
        public string Response()//서버에 응답 받기
        {
            HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
            resultStr = streamReader.ReadToEnd();
            streamReader.Close();
            httpWebResponse.Close();
            return resultStr;
        }
    }
}
