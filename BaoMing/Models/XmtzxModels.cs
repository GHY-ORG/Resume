using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BaoMing.Models
{
    /// <summary>
    /// 属性Birth,QQ的类型为int，dataTime时，会要求必填 所以 将数据类型统一改为string
    /// </summary>
    public class XmtzxModels
    {
        [Required]
        [DisplayName("姓名 *")]
        public string Name { get; set; }

        [Required]
        [DisplayName("性别 *")]
        public string Sex { get; set; }

        [Required]
        [DisplayName("手机 *")]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [DisplayName("第一意向部门 *")]
        public string BuMen { get; set; }

        [Required]
        [DisplayName("年级＆专业 *")]
        public string Grademajor { get; set; }

        [Required]
        [DisplayName("是否服从调剂 *")]
        public string TiaoJi { get; set; }

        [DisplayName("出生年月")]
        public String Birth { get; set; }

        [DisplayName("现有或曾有学生职务")]
        public string ZhiWu { get; set; }

        [DisplayName("个人特长")]
        public string TeChang { get; set; }

        #region 开放问题
        [DisplayName("介绍自己")]
        [StringLength(250)]
        public string Que1 { get; set; }

        [DisplayName("对新媒体的理解")]
        [StringLength(250)]
        public string Que2 { get; set; }

        [DisplayName("对西财新媒体中心的官方微信官方微博的了解")]
        [StringLength(250)]
        public string Que3 { get; set; }
        #endregion
    }

}