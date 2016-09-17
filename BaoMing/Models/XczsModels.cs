using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace BaoMing.Models
{
    /// <summary>
    /// 属性Birth,QQ的类型为int，dataTime时，会要求必填 所以 将数据类型统一改为string
    /// </summary>
    public class XczsModels
    {
        [Required]
        [DisplayName("姓名*")]
        public string Name { get; set; }

        [Required]
        [DisplayName("性别*")]
        public string Sex { get; set; }

        [Required]
        [DisplayName("年级＆专业*")]
        public string Grademajor { get; set; }

        [Required]
        [DisplayName("手机*")]
        [Phone]
        public string Phone { get; set; }

        #region 意向部门
        [DisplayName("播音部")]
        public CheckBox BoYin { get; set; }

        [DisplayName("外联部")]
        public CheckBox WaiLian { get; set; }

        [DisplayName("编辑部")]
        public CheckBox BianJi { get; set; }

        [DisplayName("宣传部")]
        public CheckBox XuanChuan { get; set; }

        [DisplayName("事务部")]
        public CheckBox ShiWu { get; set; }
        #endregion
    }

}