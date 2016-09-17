using System;
using System.Reflection;

namespace BaoMing.Controllers
{
    public class Authentication
    {
        #region ghy
        /// <summary>
        /// 判断志愿是否被选中至少一项
        /// </summary>
        /// <param name="models">报名对象</param>
        /// <returns></returns>
        public static bool ghy_IsZhiYuan(Models.GhyModels models)
        {
            if (models.She.Checked == true || models.Kai.Checked == true || models.Ban.Checked == true || models.Xin.Checked == true || models.Yin.Checked == true || models.Sheng.Checked == true || models.Ruan.Checked == true || models.Xue.Checked == true || models.Dian.Checked == true || models.Zi.Checked == true || models.Shi.Checked == true)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 校园文化研究社
        /// <summary>
        /// 判断意向部门是否被选中至少一项
        /// </summary>
        /// <param name="models">报名对象</param>
        /// <returns></returns>
        public static bool xywh_IsYiXiang(Models.XywhModels models)
        {
            if (models.CheHua.Checked == true || models.GongGuan.Checked == true || models.MiShu.Checked == true || models.XuanWen.Checked == true || models.XuanMei.Checked == true || models.XueShu.Checked == true)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 校报记者团
        /// <summary>
        /// 判断意向部门是否被选中至少一项
        /// </summary>
        /// <param name="models">报名对象</param>
        /// <returns></returns>
        public static bool xbjzt_IsYiXiang(Models.XbjztModels models)
        {
            if (models.WenZi.Checked == true || models.SheYing.Checked == true || models.MeiBian.Checked == true || models.WangLuo.Checked == true)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 新媒体中心
        #endregion

        #region 西财之声广播站
        /// <summary>
        /// 判断意向部门是否被选中至少一项
        /// </summary>
        /// <param name="models">报名对象</param>
        /// <returns></returns>
        public static bool xczs_IsYiXiang(Models.XczsModels models)
        {
            if (models.BoYin.Checked == true || models.WaiLian.Checked == true || models.BianJi.Checked == true || models.XuanChuan.Checked == true || models.ShiWu.Checked == true)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 共用
        /// <summary>
        /// 判断性别是否填写正确
        /// </summary>
        /// <param name="sex">性别</param>
        /// <param name="isNull">是否可为空</param>
        /// <returns></returns>
        public static bool IsSex(String sex, bool isNull)
        {
            if (isNull && (sex == null || sex == ""))
            {
                return true;
            }
            if (sex.Trim() == "男" || sex.Trim() == "女")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断对象中的数据是否为空并赋值
        /// </summary>
        /// <param name="models">待判断对象模型</param>
        public static void IsModelNull<Model>(Model models)
        {
            PropertyInfo[] propertys = models.GetType().GetProperties();
            foreach (PropertyInfo property in propertys)
            {
                if (property.GetValue(models) == null)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(models, "空");
                    }
                    //if (property.PropertyType == typeof(CheckBox))
                    //{
                    //    property.SetValue(models, "空");
                    //}
                    if (property.PropertyType == typeof(DateTime))
                    {
                        property.SetValue(models, DateTime.Today);
                    }
                }

            }
        }
        #endregion
    }
}