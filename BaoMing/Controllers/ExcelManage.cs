using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Web.UI.WebControls;

namespace BaoMing.Controllers
{
    public class ExcelManage
    {
        private static string PathStart = @"E:\报名表\";
        private static string conStart_beforePath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
        private static string conStart_afterPath = ";Extended Properties=Excel 8.0;";

        #region 操作excel表单 —— 泛型
        /// <summary>
        /// 获得sql语句
        /// </summary>
        /// <param name="path">excel地址</param>
        private bool CreatExcel<Model>(String path, Model model)
        {
            try
            {
                string OLEDBConnStr = conStart_beforePath + path + conStart_afterPath;
                string strCreateTableSQL = GetCreatSql(model);
                using (OleDbConnection oConn = new OleDbConnection())
                {
                    oConn.ConnectionString = OLEDBConnStr;
                    OleDbCommand oCreateComm = new OleDbCommand();
                    oCreateComm.Connection = oConn;
                    oCreateComm.CommandText = strCreateTableSQL;

                    oConn.Open();
                    oCreateComm.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("创建Excel发生错误：" + ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 将报名对象 添加进入excel中
        /// </summary>
        /// <param name="models">报名对象</param>
        /// <param name="fileName">插入表名</param>
        /// <returns></returns>
        public bool SavetoExcel<Model>(Model models, String fileName)
        {
            string path = PathStart + fileName + ".xls";
            string strConn = conStart_beforePath + path + conStart_afterPath;
            try
            {
                ////判断文件是否存在 否则创建
                if (!File.Exists(path))
                {
                    CreatExcel(path, models);
                }

                //判断对象中的数据是否为空 是则并赋予值为"空"
                Authentication.IsModelNull(models);
                using (OleDbConnection conn = new OleDbConnection(strConn))
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = GetInsertSql(models);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                System.Diagnostics.Debug.WriteLine("写入Excel发生错误：" + ex.Message);
            }
            return false;
        }
        #endregion

        #region 获得sql语句 —— 泛型
        /// <summary>
        /// 获得sql语句
        /// </summary>
        /// <param name="model">插入对象模型</param>
        public static string GetCreatSql<Model>(Model model)
        {
            //Models.XywhModels xywhModels = new Models.XywhModels();
            string SQL = "";
            string SQL1 = "CREATE TABLE 简历 (";

            PropertyInfo[] propertys = model.GetType().GetProperties();

            foreach (PropertyInfo property in propertys)
            {
                string name = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;  //得到属性的名字
                name = name.Replace("*", "");
                SQL1 += name + " VARCHAR , ";
            }
            SQL = SQL1 + "报名时间 VARCHAR) ";

            return SQL;
        }

        /// <summary>
        /// 获得sql语句
        /// </summary>
        /// <param name="model">插入对象模型</param>
        public static string GetInsertSql<Model>(Model models)
        {
            //Models.XczsModels xczsModels = new Models.XczsModels();
            PropertyInfo[] propertys = models.GetType().GetProperties();
            string SQL = "";
            string SQL1 = "INSERT INTO [简历$] (";
            string SQL2 = "values('";
            int index = 0;
            foreach (PropertyInfo property in propertys)
            {
                //object value = property.GetValue(models);//得到属性的值
                object value = property.GetValue(models, null);//得到属性的值
                string name = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;  //得到属性的名字
                name = name.Replace("*", "");
                SQL1 += name + ",";

                if (value != null)
                {
                    if (property.PropertyType == typeof(CheckBox))
                    {
                        value = (value as CheckBox).Checked;
                    }
                    if (property.PropertyType == typeof(RadioButton))
                    {
                        value = (value as RadioButton).Checked;
                    }
                }
                else
                {
                    value = false;
                }

                SQL2 += value.ToString().Trim() + "','";
                index++;
            }
            //SQL1 = SQL1.Substring(0, SQL1.Length - 1);
            //SQL2 = SQL2.Substring(0, SQL2.Length - 2);
            SQL = SQL1 + "报名时间) " + SQL2 + DateTime.Now + "');";//这就成了需要的插入记录的SQL语句。
            return SQL;
        }
        #endregion
    }
}