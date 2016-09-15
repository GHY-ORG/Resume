using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BaoMing.Models
{
    public class XbjztModels
    {
        [Required]
        [DisplayName("姓名 *")]
        public string Name { get; set; }

        [Required]
        [DisplayName("性别 *")]
        public string Sex { get; set; }

        [DisplayName("专业")]
        public string Department { get; set; }

        [Required]
        [DisplayName("电话 *")]
        [Phone]
        public string Phone { get; set; }

        [DisplayName("QQ")]
        public string QQ { get; set; }

        [Required]
        [DisplayName("特长 *")]
        public string TeChang { get; set; }

        #region 意向部门
        [DisplayName("文字组 ")]
        public CheckBox WenZi { get; set; }

        [DisplayName("摄影组")]
        public CheckBox SheYing { get; set; }

        [DisplayName("美编组")]
        public CheckBox MeiBian { get; set; }

        [DisplayName("网络组")]
        public CheckBox WangLuo { get; set; }
        #endregion

        [Required]
        [DisplayName("自我介绍 *")]
        [StringLength(250)]
        public string JianJie { get; set; }
    }

}