using BaoMing.Models;
using System.Web.Mvc;

namespace BaoMing.Controllers
{
    public class BaoMingController : Controller
    {
        // GET: BaoMing
        public ActionResult Index()
        {
            return View();
        }

        #region ghy
        // GET: ghy
        public ActionResult Ghy()
        {
            return View();
        }

        // Post: ghy
        [HttpPost]
        public ActionResult Ghy(GhyModels models)
        {
            ExcelManage eM = new ExcelManage();

            if (ModelState.IsValid)
            {
                if (Authentication.ghy_IsZhiYuan(models) == false)
                {
                    ModelState.AddModelError("ZhiYuan", "至少选择一项志愿部门/子网");
                    return View(models);
                }
                if (eM.SavetoExcel(models,"ghy_BaoMing"))
                {
                    return Content("<script>alert('报名成功');window.location.href='/';</script>");
                }
                else
                {
                    ModelState.AddModelError("execl_err", "excel操作失败");
                }
            }
            ModelState.AddModelError("", "报名失败!请按要求填写");
            return View(models);
        }
        #endregion

        #region 校报记者团
        // GET: Xbjzt
        public ActionResult Xbjzt()
        {
            return View();
        }

        // Post: Xbjzt
        [HttpPost]
        public ActionResult Xbjzt(XbjztModels models)
        {
            ExcelManage eM = new ExcelManage();

            if (ModelState.IsValid)
            {
                if (Authentication.xbjzt_IsYiXiang(models) == false)
                {
                    ModelState.AddModelError("yixiang", "至少选择一项意向组别");
                    return View(models);
                }
                if (eM.SavetoExcel(models, "xbjzt_BaoMing"))
                {
                    //return Content("<script>alert('报名成功');window.location.href='http://ghy.swufe.edu.cn/aboutus';</script>");
                    return Content("<script>alert('报名成功');window.location.href='/';</script>");
                }
            }
            ModelState.AddModelError("", "报名失败!请按要求填写");
            return View(models);
        }
        #endregion

        #region 校园文化研究社
        // GET: Xywh
        public ActionResult Xywh()
        {
            return View();
        }

        // Post: Xywh
        [HttpPost]
        public ActionResult Xywh(XywhModels models)
        {
            ExcelManage eM = new ExcelManage();

            if (ModelState.IsValid)
            {
                if (Authentication.xywh_IsYiXiang(models) == false)
                {
                    ModelState.AddModelError("yixiang", "至少选择一项意向部门");
                    return View(models);
                }
                if (eM.SavetoExcel(models, "xywh_BaoMing"))
                {
                    //return Content("<script>alert('报名成功');window.location.href='http://ghy.swufe.edu.cn/aboutus';</script>");
                    return Content("<script>alert('报名成功');window.location.href='/';</script>");
                }
            }
            ModelState.AddModelError("", "报名失败!请按要求填写");
            return View(models);
        }
        #endregion

        #region 新媒体中心
        // GET: Xmtzx
        public ActionResult Xmtzx()
        {
            return View();
        }

        // Post: Xmtzx
        [HttpPost]
        public ActionResult Xmtzx(XmtzxModels models)
        {
            ExcelManage eM = new ExcelManage();

            if (ModelState.IsValid)
            {
                if (eM.SavetoExcel(models, "xmtzx_BaoMing"))
                {
                    //return Content("<script>alert('报名成功');window.location.href='http://ghy.swufe.edu.cn/aboutus';</script>");
                    return Content("<script>alert('报名成功');window.location.href='/';</script>");
                }
            }
            ModelState.AddModelError("", "报名失败!请按要求填写");
            return View(models);
        }
        #endregion

        #region 西财之声广播站
        // GET: Xczs
        public ActionResult Xczs()
        {
            return View();
        }

        // Post: Xywh
        [HttpPost]
        public ActionResult Xczs(XczsModels models)
        {
            ExcelManage eM = new ExcelManage();

            if (ModelState.IsValid)
            {
                if (Authentication.xczs_IsYiXiang(models) == false)
                {
                    ModelState.AddModelError("yixiang", "至少选择一项意向部门");
                    return View(models);
                }
                if (eM.SavetoExcel(models, "xczs_BaoMing"))
                {
                    //return Content("<script>alert('报名成功');window.location.href='http://ghy.swufe.edu.cn/aboutus';</script>");
                    return Content("<script>alert('报名成功');window.location.href='/';</script>");
                }
            }
            ModelState.AddModelError("", "报名失败!请按要求填写");
            return View(models);
        }
        #endregion
    }
}