using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OIU.CorporateWebsite.Portal.Areas.webadmin.Controllers
{
    public class FilesController : BaseController
    {
        [HttpPost]
        public ActionResult Upload()
        {
            var attachdir = "/Content/img/"; // 上传文件保存路径，结尾不要带/
            var maxattachsize = 2097152; // 最大上传大小，默认是2M
            var upext = "jpg,jpeg,gif,bmp,png"; // 上传扩展名

            string err, msg;
            err = "";
            msg = "";

            HttpFileCollectionBase filecollection = Request.Files;

            // 只接收指定文件域的上传，如果需要同时接收多个文件，请通过循环方式接收
            HttpPostedFileBase postedfile = filecollection.Get("filedata");

            if (postedfile == null)
            {
                err = "无数据提交";
            }
            else
            {
                if (postedfile.ContentLength > maxattachsize)
                {
                    err = "文件大小超过" + maxattachsize + "字节";
                }
                else
                {
                    string filename, extension, target;

                    // 取上载文件后缀名
                    extension = GetFileExt(postedfile.FileName);

                    if (("," + upext + ",").IndexOf("," + extension + ",") < 0)
                    {
                        err = "上传文件扩展名必需为：" + upext;
                    }
                    else
                    {
                        // 生成随机文件名
                        Random random = new Random(DateTime.Now.Millisecond);
                        filename = DateTime.Now.ToString("yyyyMMddhhmmss") + random.Next(10000) + "." + extension;

                        target = attachdir + filename;
                        try
                        {
                            CreateFolder(Server.MapPath(attachdir));
                            postedfile.SaveAs(Server.MapPath(target));
                            msg = target;
                        }
                        catch (Exception ex)
                        {
                            err = ex.Message.ToString();
                        }
                    }
                }

            }

            postedfile = null;
            filecollection = null;

            return Content("{err:'" + jsonString(err) + "',msg:'" + jsonString(msg) + "'}");
        }

        string jsonString(string str)
        {
            str = str.Replace("\\", "\\\\");
            str = str.Replace("/", "\\/");
            str = str.Replace("'", "\\'");
            return str;
        }


        string GetFileExt(string fullPath)
        {
            if (fullPath != "")
            {
                return fullPath.Substring(fullPath.LastIndexOf('.') + 1).ToLower();
            }
            else
            {
                return "";
            }
        }

        void CreateFolder(string folderPath)
        {
            if (!System.IO.Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }
        }

    }
}
