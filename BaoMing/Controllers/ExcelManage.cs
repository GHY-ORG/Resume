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
        //private static string PathStart = @"E:\GHY\Work\BaoMing";
        private static string conStart_beforePath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
        private static string conStart_afterPath = ";Extended Properties=Excel 8.0;";

        #region ghy
        /// <summary>
        /// 自定义excel文件绝对地址 path
        /// </summary>
        private string ghy_Path = PathStart + "ghy_BaoMing.xls";

        /// <summary>
        /// 将报名对象 添加进入excel中
        /// </summary>
        /// <param name="models">报名对象</param>
        /// <returns></returns>
        public bool ghy_SavetoExcel(Models.GhyModels models)
        {
            try
            {
                ////判断文件是否存在 否则创建
                if (!File.Exists(ghy_Path))
                {
                    ghy_CreatExcel();
                }

                //判断对象中的数据是否为空 是则并赋予值为"空"
                Authentication.ghy_IsModelNull(models);

                string strConn = conStart_beforePath + ghy_Path + conStart_afterPath;
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                // 反斜杠在转换为\\ 在INSERT INTO语句中会一直报错  所以 将"摄影\视频制作"改为"摄影或视频制作"
                //cmd.CommandText = @"INSERT INTO [简历$] (姓名,性别,出生年月,籍贯,年级专业,QQ,邮箱,电话号码,设计部,开发部,办公室,新闻中心,音乐网,生活网,软件园,学苑,电影网,自媒体事业群,摄影或视频制作,加入原因) VALUES('" + models.Name + "','" + models.Sex + "','" + models.Birth + "','" + models.NativePlace + "','" + models.Grademajor + "','" + models.QQ + "','" + models.Email + "','" + models.Phone + "','" + models.She.Checked + "','" + models.Kai.Checked + "','" + models.Ban.Checked + "','" + models.Xin.Checked + "','" + models.Yin.Checked + "','" + models.Sheng.Checked + "','" + models.Ruan.Checked + "','" + models.Xue.Checked + "','" + models.Dian.Checked + "','" + models.Zi.Checked + "','" + models.Shi.Checked + "','" + models.TeChang + "')";
                cmd.CommandText = @"INSERT INTO [简历$] (姓名,性别,出生年月,年级专业,QQ,邮箱,电话号码,设计部,开发部,办公室,新闻中心,音乐网,生活网,软件园,学苑,电影网,自媒体事业群,摄影或视频制作,加入原因,报名时间) VALUES('" + models.Name.Trim() + "','" + models.Sex.Trim() + "','" + models.Birth.Trim() + "','" + models.Grademajor.Trim() + "','" + models.QQ.Trim() + "','" + models.Email.Trim() + "','" + models.Phone.Trim() + "','" + models.She.Checked + "','" + models.Kai.Checked + "','" + models.Ban.Checked + "','" + models.Xin.Checked + "','" + models.Yin.Checked + "','" + models.Sheng.Checked + "','" + models.Ruan.Checked + "','" + models.Xue.Checked + "','" + models.Dian.Checked + "','" + models.Zi.Checked + "','" + models.Shi.Checked + "','" + models.TeChang.Trim() + "','"+DateTime.Now+"')";
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                System.Diagnostics.Debug.WriteLine("写入Excel发生错误：" + ex.Message);
            }
            return false;
        }

        private bool ghy_CreatExcel()
        {
            try
            {
                string OLEDBConnStr = conStart_beforePath + ghy_Path + conStart_afterPath;
                string strCreateTableSQL = @" CREATE TABLE ";
                strCreateTableSQL += @" 简历 ";
                strCreateTableSQL += @" ( ";
                strCreateTableSQL += @" 姓名 VARCHAR , ";
                strCreateTableSQL += @" 性别 VARCHAR , ";
                strCreateTableSQL += @" 出生年月 VARCHAR , ";
                //strCreateTableSQL += @" 籍贯 VARCHAR , ";
                strCreateTableSQL += @" 年级专业 VARCHAR , ";
                strCreateTableSQL += @" QQ VARCHAR , ";
                strCreateTableSQL += @" 邮箱 VARCHAR , ";
                strCreateTableSQL += @" 电话号码 VARCHAR , ";
                strCreateTableSQL += @" 设计部 VARCHAR , ";
                strCreateTableSQL += @" 开发部 VARCHAR , ";
                strCreateTableSQL += @" 办公室 VARCHAR , ";
                strCreateTableSQL += @" 新闻中心 VARCHAR , ";
                strCreateTableSQL += @" 音乐网 VARCHAR , ";
                strCreateTableSQL += @" 生活网 VARCHAR , ";
                strCreateTableSQL += @" 软件园 VARCHAR , ";
                strCreateTableSQL += @" 学苑 VARCHAR , ";
                strCreateTableSQL += @" 电影网 VARCHAR , ";
                strCreateTableSQL += @" 自媒体事业群 VARCHAR , ";
                strCreateTableSQL += @" 摄影或视频制作 VARCHAR , ";
                strCreateTableSQL += @" 加入原因 VARCHAR , ";
                strCreateTableSQL += @" 报名时间 VARCHAR ";

                strCreateTableSQL += @" ) ";

                OleDbConnection oConn = new OleDbConnection();

                oConn.ConnectionString = OLEDBConnStr;
                OleDbCommand oCreateComm = new OleDbCommand();
                oCreateComm.Connection = oConn;
                oCreateComm.CommandText = strCreateTableSQL;

                oConn.Open();
                oCreateComm.ExecuteNonQuery();
                oConn.Close();


                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("创建Excel发生错误：" + ex.Message);
            }
            return false;
        }
        #endregion

        #region 校园文化研究社
        /// <summary>
        /// 自定义excel文件绝对地址 path
        /// </summary>
        private string xywh_Path = PathStart + "xywh_BaoMing.xls";

        /// <summary>
        /// 将报名对象 添加进入excel中
        /// </summary>
        /// <param name="models">报名对象</param>
        /// <returns></returns>
        public bool xywh_SavetoExcel(Models.XywhModels models)
        {
            string strConn = conStart_beforePath + xywh_Path + conStart_afterPath;
            ////判断文件是否存在 否则创建
            if (!File.Exists(xywh_Path))
            {
                xywh_CreatExcel();
            }

            //判断对象中的数据是否为空 是则并赋予值为"空"
            Authentication.xywh_IsModelNull(models);

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                try
                {
                    cmd.CommandText = xywh_GetSql(models);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("插入Excel发生错误：" + ex.Message);
                    return false;
                }
                return true;
            }
        }

        private bool xywh_CreatExcel()
        {
            try
            {
                string OLEDBConnStr = conStart_beforePath + xywh_Path + conStart_afterPath;
                string strCreateTableSQL = xywh_GetCreatSql();

                OleDbConnection oConn = new OleDbConnection();

                oConn.ConnectionString = OLEDBConnStr;
                OleDbCommand oCreateComm = new OleDbCommand();
                oCreateComm.Connection = oConn;
                oCreateComm.CommandText = strCreateTableSQL;

                oConn.Open();
                oCreateComm.ExecuteNonQuery();
                oConn.Close();


                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("创建Excel发生错误：" + ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 获得sql语句
        /// </summary>
        /// <param name="models"></param>
        public static string xywh_GetSql(Models.XywhModels models)
        {
            Models.XywhModels xywhModels = new Models.XywhModels();
            PropertyInfo[] propertys = xywhModels.GetType().GetProperties();
            string SQL = "";
            string SQL1 = "INSERT INTO [简历$] (";
            string SQL2 = "values('";
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
            }
            SQL1 = SQL1.Substring(0, SQL1.Length - 1);
            SQL2 = SQL2.Substring(0, SQL2.Length - 2);
            SQL = SQL1 + ") " + SQL2 + ");";//这就成了需要的插入记录的SQL语句。
            return SQL;

        }

        /// <summary>
        /// 获得creat_sql语句
        /// </summary>
        /// <param name="models"></param>
        public static string xywh_GetCreatSql()
        {
            Models.XywhModels xywhModels = new Models.XywhModels();
            PropertyInfo[] propertys = xywhModels.GetType().GetProperties();
            string SQL = "";
            string SQL1 = "CREATE TABLE 简历 (";
            foreach (PropertyInfo property in propertys)
            {
                string name = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;  //得到属性的名字
                name = name.Replace("*", "");
                SQL1 += name + " VARCHAR , ";
            }
            SQL1 = SQL1.Substring(0, SQL1.Length - (", ").Length);
            SQL = SQL1 + ") ";//这就成了需要的插入记录的SQL语句。
            return SQL;
        }
        #endregion

        #region 校报记者团
        /// <summary>
        /// 自定义excel文件绝对地址 path
        /// </summary>
        private string xbjzt_Path = PathStart + "xbjzt_BaoMing.xls";

        /// <summary>
        /// 将报名对象 添加进入excel中
        /// </summary>
        /// <param name="models">报名对象</param>
        /// <returns></returns>
        public bool xbjzt_SavetoExcel(Models.XbjztModels models)
        {
            string strConn = conStart_beforePath + xbjzt_Path + conStart_afterPath;
            ////判断文件是否存在 否则创建
            if (!File.Exists(xbjzt_Path))
            {
                xbjzt_CreatExcel();
            }

            //判断对象中的数据是否为空 是则并赋予值为"空"
            Authentication.xbjzt_IsModelNull(models);

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                try
                {
                    cmd.CommandText = xbjzt_GetSql(models);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("插入Excel发生错误：" + ex.Message);
                    return false;
                }
                return true;
            }
        }

        private bool xbjzt_CreatExcel()
        {
            try
            {
                string OLEDBConnStr = conStart_beforePath + xbjzt_Path + conStart_afterPath;
                string strCreateTableSQL = xbjzt_GetCreatSql();

                OleDbConnection oConn = new OleDbConnection();

                oConn.ConnectionString = OLEDBConnStr;
                OleDbCommand oCreateComm = new OleDbCommand();
                oCreateComm.Connection = oConn;
                oCreateComm.CommandText = strCreateTableSQL;

                oConn.Open();
                oCreateComm.ExecuteNonQuery();
                oConn.Close();


                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("创建Excel发生错误：" + ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 获得sql语句
        /// </summary>
        /// <param name="models"></param>
        public static string xbjzt_GetSql(Models.XbjztModels models)
        {
            Models.XbjztModels xbjztModels = new Models.XbjztModels();
            PropertyInfo[] propertys = xbjztModels.GetType().GetProperties();
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
            SQL1 = SQL1.Substring(0, SQL1.Length - 1);
            SQL2 = SQL2.Substring(0, SQL2.Length - 2);
            SQL = SQL1 + ") " + SQL2 + ");";//这就成了需要的插入记录的SQL语句。
            return SQL;
        }

        /// <summary>
        /// 获得creat_sql语句
        /// </summary>
        /// <param name="models"></param>
        public static string xbjzt_GetCreatSql()
        {
            Models.XbjztModels xbjztModels = new Models.XbjztModels();
            PropertyInfo[] propertys = xbjztModels.GetType().GetProperties();
            string SQL = "";
            string SQL1 = "CREATE TABLE 简历 (";
            foreach (PropertyInfo property in propertys)
            {
                string name = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;  //得到属性的名字
                name = name.Replace("*", "");
                SQL1 += name + " VARCHAR , ";
            }
            SQL1 = SQL1.Substring(0, SQL1.Length - (", ").Length);
            SQL = SQL1 + ") ";//这就成了需要的插入记录的SQL语句。
            return SQL;
        }
        #endregion

        #region 新媒体中心
        /// <summary>
        /// 自定义excel文件绝对地址 path
        /// </summary>
        private string xmtzx_Path = PathStart + "xmtzx_BaoMing.xls";

        /// <summary>
        /// 将报名对象 添加进入excel中
        /// </summary>
        /// <param name="models">报名对象</param>
        /// <returns></returns>
        public bool xmtzx_SavetoExcel(Models.XmtzxModels models)
        {
            string strConn = conStart_beforePath + xmtzx_Path + conStart_afterPath;
            ////判断文件是否存在 否则创建
            if (!File.Exists(xmtzx_Path))
            {
                xmtzx_CreatExcel();
            }

            //判断对象中的数据是否为空 是则并赋予值为"空"
            Authentication.xmtzx_IsModelNull(models);

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                try
                {
                    cmd.CommandText = xmtzx_GetSql(models);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("插入Excel发生错误：" + ex.Message);
                    return false;
                }
                return true;
            }
        }

        private bool xmtzx_CreatExcel()
        {
            try
            {
                string OLEDBConnStr = conStart_beforePath + xmtzx_Path + conStart_afterPath;
                string strCreateTableSQL = xmtzx_GetCreatSql();

                OleDbConnection oConn = new OleDbConnection();

                oConn.ConnectionString = OLEDBConnStr;
                OleDbCommand oCreateComm = new OleDbCommand();
                oCreateComm.Connection = oConn;
                oCreateComm.CommandText = strCreateTableSQL;

                oConn.Open();
                oCreateComm.ExecuteNonQuery();
                oConn.Close();


                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("创建Excel发生错误：" + ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 获得sql语句
        /// </summary>
        /// <param name="models"></param>
        public static string xmtzx_GetSql(Models.XmtzxModels models)
        {
            Models.XmtzxModels xmtzxModels = new Models.XmtzxModels();
            PropertyInfo[] propertys = xmtzxModels.GetType().GetProperties();
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
            SQL1 = SQL1.Substring(0, SQL1.Length - 1);
            SQL2 = SQL2.Substring(0, SQL2.Length - 2);
            SQL = SQL1 + ") " + SQL2 + ");";//这就成了需要的插入记录的SQL语句。
            return SQL;
        }

        /// <summary>
        /// 获得creat_sql语句
        /// </summary>
        /// <param name="models"></param>
        public static string xmtzx_GetCreatSql()
        {
            Models.XmtzxModels xmtzxModels = new Models.XmtzxModels();
            PropertyInfo[] propertys = xmtzxModels.GetType().GetProperties();
            string SQL = "";
            string SQL1 = "CREATE TABLE 简历 (";
            foreach (PropertyInfo property in propertys)
            {
                string name = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;  //得到属性的名字
                name = name.Replace("*", "");
                SQL1 += name + " VARCHAR , ";
            }
            SQL1 = SQL1.Substring(0, SQL1.Length - (", ").Length);
            SQL = SQL1 + ") ";//这就成了需要的插入记录的SQL语句。
            return SQL;
        }
        #endregion

        #region 西财之声广播站
        /// <summary>
        /// 自定义excel文件绝对地址 path
        /// </summary>
        private string xczs_Path = PathStart + "xczs_BaoMing.xls";

        /// <summary>
        /// 将报名对象 添加进入excel中
        /// </summary>
        /// <param name="models">报名对象</param>
        /// <returns></returns>
        public bool xczs_SavetoExcel(Models.XczsModels models)
        {
            string strConn = conStart_beforePath + xczs_Path + conStart_afterPath;
            ////判断文件是否存在 否则创建
            if (!File.Exists(xczs_Path))
            {
                xczs_CreatExcel();
            }

            //判断对象中的数据是否为空 是则并赋予值为"空"
            Authentication.xczs_IsModelNull(models);

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                try
                {
                    cmd.CommandText = xczs_GetSql(models);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("插入Excel发生错误：" + ex.Message);
                    return false;
                }
                return true;
            }
        }

        private bool xczs_CreatExcel()
        {
            try
            {
                string OLEDBConnStr = conStart_beforePath + xczs_Path + conStart_afterPath;
                string strCreateTableSQL = xczs_GetCreatSql();

                OleDbConnection oConn = new OleDbConnection();

                oConn.ConnectionString = OLEDBConnStr;
                OleDbCommand oCreateComm = new OleDbCommand();
                oCreateComm.Connection = oConn;
                oCreateComm.CommandText = strCreateTableSQL;

                oConn.Open();
                oCreateComm.ExecuteNonQuery();
                oConn.Close();


                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("创建Excel发生错误：" + ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 获得sql语句
        /// </summary>
        /// <param name="models"></param>
        public static string xczs_GetSql(Models.XczsModels models)
        {
            Models.XczsModels xczsModels = new Models.XczsModels();
            PropertyInfo[] propertys = xczsModels.GetType().GetProperties();
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
            SQL1 = SQL1.Substring(0, SQL1.Length - 1);
            SQL2 = SQL2.Substring(0, SQL2.Length - 2);
            SQL = SQL1 + ") " + SQL2 + ");";//这就成了需要的插入记录的SQL语句。
            return SQL;
        }

        /// <summary>
        /// 获得creat_sql语句
        /// </summary>
        /// <param name="models"></param>
        public static string xczs_GetCreatSql()
        {
            Models.XczsModels xczsModels = new Models.XczsModels();
            PropertyInfo[] propertys = xczsModels.GetType().GetProperties();
            string SQL = "";
            string SQL1 = "CREATE TABLE 简历 (";
            foreach (PropertyInfo property in propertys)
            {
                string name = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;  //得到属性的名字
                name = name.Replace("*", "");
                SQL1 += name + " VARCHAR , ";
            }
            SQL1 = SQL1.Substring(0, SQL1.Length - (", ").Length);
            SQL = SQL1 + ") ";//这就成了需要的插入记录的SQL语句。
            return SQL;
        }
        #endregion


    }
}