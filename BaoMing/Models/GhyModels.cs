using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BaoMing.Models
{
    /// <summary>
    /// 属性Birth,QQ的类型为int，dataTime时，会要求必填 所以 将数据类型统一改为string
    /// </summary>
    public class GhyModels
    {
        [Required]
        [Display(Name = "姓名 *")]
        public string Name { get; set; }

        [Display(Name = "性别")]
        public string Sex { get; set; }

        //[Required]
        //[Display(Name = "性别")]
        //public RadioButton Sex { get; set; }

        [Display(Name = "出生年月")]
        public string Birth { get; set; }

        //[Required]
        //[Display(Name = "籍贯")]
        //public string NativePlace { get; set; }

        [Required]
        [Display(Name = "年级专业 *")]
        public string Grademajor { get; set; }

        public string QQ { get; set; }

        [Display(Name = "邮箱")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "电话号码 *")]
        [Phone]
        public string Phone { get; set; }

        [Display(Name = "设计部")]
        public CheckBox She { get; set; }

        [Display(Name = "开发部")]
        public CheckBox Kai { get; set; }

        [Display(Name = "办公室")]
        public CheckBox Ban { get; set; }

        [Display(Name = "新闻中心")]
        public CheckBox Xin { get; set; }

        [Display(Name = "音乐网")]
        public CheckBox Yin { get; set; }

        [Display(Name = "生活网")]
        public CheckBox Sheng { get; set; }

        [Display(Name = "软件园")]
        public CheckBox Ruan { get; set; }

        [Display(Name = "学苑")]
        public CheckBox Xue { get; set; }

        [Display(Name = "电影网")]
        public CheckBox Dian { get; set; }

        [Display(Name = "自媒体事业群")]
        public CheckBox Zi { get; set; }

        [Display(Name = "摄影\\视频制作")]
        public CheckBox Shi { get; set; }

        [StringLength(150)]
        public string TeChang { get; set; }
    }

}