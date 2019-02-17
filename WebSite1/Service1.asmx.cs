using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data.OracleClient;

namespace WebServiceSample
{
    /// <summary>
    /// This is an sample code for vendors to set up webservice server that can test web reference in their own office.
    /// 
    /// 1.0.0.0
    /// sendDataToSer()
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Service1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string sendDataToSer(String username, String password, String equid, 
            String parameterName, String parameterValue, String createDate)
        {
            String Restr = "OK";

            //去除輸入參數中的空白字元
            //remove space from input parameter
            username = username.Trim();
            password = password.Trim();
            equid = equid.Trim();
            createDate = createDate.Trim();
            parameterName = parameterName.Trim();
            parameterValue = parameterValue.Trim();

            //檢查是否傳入的空值
            //check if input empty string
            if (username == String.Empty || password == String.Empty || createDate == String.Empty ||
                (parameterName == String.Empty && parameterValue == String.Empty))
            {
                Restr = "NG: parameter missing!";
                return Restr;
            }

            //檢察要寫入資料庫的參數名稱與參數值的數量是否相同，分隔符號是'|'
            //check parameterName and parameterValue number,delimiter is '|'
            if (parameterName.Length != 0 && parameterValue.Length != 0)
            {
                if (parameterName.Split('|').Length != parameterValue.Split('|').Length)
                {
                    Restr = "NG: parameter number mismatch!";
                    return Restr;
                }
            }

            DateTime tempDateTime;
            try
            {
                tempDateTime = System.Convert.ToDateTime(createDate);
            }
            catch (Exception ex)
            {
                Restr = "NG: time format error!(" + ex.Message.ToString() + ")";
                return Restr;
            }

            try
            {
                /*
                 * 開啟資料庫連線，正常則回傳"OK"，有問題則回傳"open fail:"開頭的字串，原因接在後面
                 * open database get connection and return "OK" if everything is correct, start with "open fail:" if something wrong.
                 */
                //Restr = GetOraConnection(Oraconn);
                if (Restr != "OK")
                {
                    return Restr;
                }

                /*
                 * 將資料寫入資料庫，並取得執行結果，正常則回傳"OK"，有問題則回傳"NG:"開頭的字串，原因接在後面
                 * Insert data into database and return "OK" if everything is correct, start with "NG:" if something wrong.
                 */

                return Restr;
            }
            catch (OracleException ex)
            {
                if (ex.Message.ToString().StartsWith("ORA-1:"))
                    Restr = "Error attempting to insert duplicate data.";
                else if (ex.Message.ToString().StartsWith("ORA-12545:"))
                    Restr = "The database is unavailable.";
                else
                    Restr = "Database error: " + ex.Message.ToString();
            }
            catch (Exception ex)
            {
                Restr = "Programmer error:" + ex.Message.ToString();
            }
            finally
            {
                /*
                 * 關閉資料庫連線
                 * close database connection.
                 */
                //DisOraConnection(Oraconn);
            }

            /*
             * 將資料寫入資料庫，發生例外，回傳"NG:"開頭的字串，原因接在後面
             * Insert data into database and get exception, return error message start with "NG:".
             */

            return "NG: " + Restr;
        }



        [WebMethod]
        public string sendDataToSerGrp(String username, String password, String equid,
            String groupid, String funid, String parameterName, String parameterValue, String createDate)
        {
            String Restr = "OK";

            //去除輸入參數中的空白字元
            //remove space from input parameter
            username = username.Trim();
            password = password.Trim();
            equid = equid.Trim();
            groupid = groupid.Trim();
            funid = funid.Trim();
            createDate = createDate.Trim();
            parameterName = parameterName.Trim();
            parameterValue = parameterValue.Trim();

            //檢查是否傳入的空值
            //check if input empty string
            if (username == String.Empty || password == String.Empty || createDate == String.Empty ||
                (parameterName == String.Empty && parameterValue == String.Empty))
            {
                Restr = "NG: parameter missing!";
                return Restr;
            }

            //檢察要寫入資料庫的參數名稱與參數值的數量是否相同，分隔符號是'|'
            //check parameterName and parameterValue number,delimiter is '|'
            if (parameterName.Length != 0 && parameterValue.Length != 0)
            {
                if (parameterName.Split('|').Length != parameterValue.Split('|').Length)
                {
                    Restr = "NG: parameter number mismatch!";
                    return Restr;
                }
            }

            DateTime tempDateTime;
            try
            {
                tempDateTime = System.Convert.ToDateTime(createDate);
            }
            catch (Exception ex)
            {
                Restr = "NG: time format error!(" + ex.Message.ToString() + ")";
                return Restr;
            }

            /*
             * 根據groupid連線指定的DB，根據funid執行動作
             * According groupid and funid, function will select database and run program
             */

            try
            {
                /*
                 * 開啟資料庫連線，正常則回傳"OK"，有問題則回傳"open fail:"開頭的字串，原因接在後面
                 * open database get connection and return "OK" if everything is correct, start with "open fail:" if something wrong.
                 */
                //Restr = GetOraConnection(Oraconn);
                if (Restr != "OK")
                {
                    return Restr;
                }

                /*
                 * 將資料寫入資料庫，並取得執行結果，正常則回傳"OK"，有問題則回傳"NG:"開頭的字串，原因接在後面
                 * Insert data into database and return "OK" if everything is correct, start with "NG:" if something wrong.
                 */

                return Restr;
            }
            catch (OracleException ex)
            {
                if (ex.Message.ToString().StartsWith("ORA-1:"))
                    Restr = "Error attempting to insert duplicate data.";
                else if (ex.Message.ToString().StartsWith("ORA-12545:"))
                    Restr = "The database is unavailable.";
                else
                    Restr = "Database error: " + ex.Message.ToString();
            }
            catch (Exception ex)
            {
                Restr = "Programmer error:" + ex.Message.ToString();
            }
            finally
            {
                /*
                 * 關閉資料庫連線
                 * close database connection.
                 */
                //DisOraConnection(Oraconn);
            }

            /*
             * 將資料寫入資料庫，發生例外，回傳"NG:"開頭的字串，原因接在後面
             * Insert data into database and get exception, return error message start with "NG:".
             */

            return "NG: " + Restr;
        }

        [WebMethod]
        public string getDataFromSer(String username, String password, String equid,
            String groupid, String funid, String parameterName, String parameterValue, String createDate)
        {
            String Restr = "OK";

            //去除輸入參數中的空白字元
            //remove space from input parameter
            username = username.Trim();
            password = password.Trim();
            equid = equid.Trim();
            groupid = groupid.Trim();
            funid = funid.Trim();
            createDate = createDate.Trim();
            parameterName = parameterName.Trim();
            parameterValue = parameterValue.Trim();

            //檢查是否傳入的空值
            //check if input empty string
            if (username == String.Empty || password == String.Empty || createDate == String.Empty ||
                (parameterName == String.Empty && parameterValue == String.Empty))
            {
                Restr = "NG: parameter missing!";
                return Restr;
            }

            //檢察要寫入資料庫的參數名稱與參數值的數量是否相同，分隔符號是'|'
            //check parameterName and parameterValue number,delimiter is '|'
            if (parameterName.Length != 0 && parameterValue.Length != 0)
            {
                if (parameterName.Split('|').Length != parameterValue.Split('|').Length)
                {
                    Restr = "NG: parameter number mismatch!";
                    return Restr;
                }
            }

            DateTime tempDateTime;
            try
            {
                tempDateTime = System.Convert.ToDateTime(createDate);
            }
            catch (Exception ex)
            {
                Restr = "NG: time format error!(" + ex.Message.ToString() + ")";
                return Restr;
            }

            /*
             * 根據groupid連線指定的DB，根據funid執行動作
             * According groupid and funid, function will select database and run program
             */

            try
            {
                /*
                 * 開啟資料庫連線，正常則回傳"OK"，有問題則回傳"open fail:"開頭的字串，原因接在後面
                 * open database get connection and return "OK" if everything is correct, start with "open fail:" if something wrong.
                 */
                //Restr = GetOraConnection(Oraconn);
                if (Restr != "OK")
                {
                    return Restr;
                }

                /*
                 * 將資料寫入資料庫，並取得執行結果，正常則回傳"OK"，有問題則回傳"NG:"開頭的字串，原因接在後面
                 * Insert data into database and return "OK" if everything is correct, start with "NG:" if something wrong.
                 */

                return Restr;
            }
            catch (OracleException ex)
            {
                if (ex.Message.ToString().StartsWith("ORA-1:"))
                    Restr = "Error attempting to insert duplicate data.";
                else if (ex.Message.ToString().StartsWith("ORA-12545:"))
                    Restr = "The database is unavailable.";
                else
                    Restr = "Database error: " + ex.Message.ToString();
            }
            catch (Exception ex)
            {
                Restr = "Programmer error:" + ex.Message.ToString();
            }
            finally
            {
                /*
                 * 關閉資料庫連線
                 * close database connection.
                 */
                //DisOraConnection(Oraconn);
            }

            /*
             * 將資料寫入資料庫，發生例外，回傳"NG:"開頭的字串，原因接在後面
             * Insert data into database and get exception, return error message start with "NG:".
             */

            return "NG: " + Restr;
        }

    }
}