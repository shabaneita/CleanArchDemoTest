using CleanArch.Mvc.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region DropZone
        /*

            public ActionResult uploade()

            {
                bool isSavedSuccessfully = true;
                string fname = "";
                try
                {
                    foreach (string filename in Request.Files)
                    {
                        HttpPostedFileBase file = Request.Files[filename];
                        fname = file.FileName;
                        if (file != null && file.ContentLength > 0)
                        {
                            var path = Path.Combine(Server.MapPath("~/uploadeimg"));
                            string pathstring = Path.Combine(path.ToString());
                            string filename1 = Guid.NewGuid() + Path.GetExtension(file.FileName);
                            bool isexist = Directory.Exists(pathstring);
                            if (!isexist)
                            {
                                Directory.CreateDirectory(pathstring);
                            }
                            string uploadpath = string.Format("{0}\\{1}", pathstring, filename1);
                            file.SaveAs(uploadpath);
                        }
                    }
                }

                catch (Exception)
                {
                    isSavedSuccessfully = false;
                }
                if (isSavedSuccessfully)
                {
                    return Json(new

                    {
                        Message = fname
                    });
                }
                else
                {
                    return Json(new
                    {
                        Message = "Error in Saving file"
                    });
                }
            }
        */
        #endregion
    }
}
