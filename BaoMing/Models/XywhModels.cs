using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace BaoMing.Models
{
    public class XywhModels
    {
        [Required]
        [DisplayName("姓名 *")]
        public string Name { get; set; }

        [Required]
        [DisplayName("性别 *")]
        public string Sex { get; set; }

        [DisplayName("所在院系")]
        public string Department { get; set; }

        [DisplayName("年级")]
        public string Grademajor { get; set; }

        [Required]
        [DisplayName("电话 *")]
        [Phone]
        public string Phone { get; set; }

        [DisplayName("QQ")]
        public string QQ { get; set; }

        #region 意向部门
        [DisplayName("策划部")]
        public CheckBox CheHua { get; set; }

        [DisplayName("公关部")]
        public CheckBox GongGuan { get; set; }

        [DisplayName("秘书处")]
        public CheckBox MiShu { get; set; }

        [DisplayName("宣传部文字组")]
        public CheckBox XuanWen { get; set; }

        [DisplayName("宣传部美编组")]
        public CheckBox XuanMei { get; set; }

        [DisplayName("学术部")]
        public CheckBox XueShu { get; set; }

        [DisplayName("是否服从调剂")]
        public Boolean TiaoJi { get; set; }
        #endregion

        #region 兴趣特长
        [DisplayName("书法、绘画、摄影")]
        public CheckBox Te1 { get; set; }

        [DisplayName("写作")]
        public CheckBox Te2 { get; set; }

        [DisplayName("PS、微信制作、视频制作剪辑")]
        public CheckBox Te3 { get; set; }

        [DisplayName("熟练掌握office系列应用")]
        public CheckBox Te4 { get; set; }

        [DisplayName("其它")]
        public string TeOther { get; set; }
        #endregion

        [DisplayName("自我介绍")]
        [StringLength(250)]
        public string ZhiWo { get; set; }

        [DisplayName("社团之我见")]
        [StringLength(250)]
        public string WoJian { get; set; }

    }

}