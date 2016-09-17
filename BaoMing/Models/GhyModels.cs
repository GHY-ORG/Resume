using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace BaoMing.Models
{
    /// <summary>
    /// 属性Birth,QQ的类型为int，dataTime时，会要求必填 所以 将数据类型统一改为string
    /// </summary>
    public class GhyModels
    {
        [Required]
        [DisplayName("姓名 *")]
        public string Name { get; set; }

        [DisplayName("性别")]
        public string Sex { get; set; }

        [DisplayName("出生年月")]
        public string Birth { get; set; }

        [Required]
        [DisplayName("年级专业 *")]
        public string Grademajor { get; set; }

        [DisplayName("QQ")]
        public string QQ { get; set; }

        [DisplayName("邮箱")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DisplayName("电话号码 *")]
        [Phone]
        public string Phone { get; set; }

        [DisplayName("设计部")]
        public CheckBox She { get; set; }

        [DisplayName("开发部")]
        public CheckBox Kai { get; set; }

        [DisplayName("办公室")]
        public CheckBox Ban { get; set; }

        [DisplayName("新闻中心")]
        public CheckBox Xin { get; set; }

        [DisplayName("音乐网")]
        public CheckBox Yin { get; set; }

        [DisplayName("生活网")]
        public CheckBox Sheng { get; set; }

        [DisplayName("软件园")]
        public CheckBox Ruan { get; set; }

        [DisplayName("学苑")]
        public CheckBox Xue { get; set; }

        [DisplayName("电影网")]
        public CheckBox Dian { get; set; }

        [DisplayName("自媒体事业群")]
        public CheckBox Zi { get; set; }

        [DisplayName("摄影或视频制作")]
        public CheckBox Shi { get; set; }

        [DisplayName("加入原因")]
        [StringLength(250)]
        public string TeChang { get; set; }
    }

}