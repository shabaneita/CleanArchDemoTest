using CleanArch.Mvc.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private IHostingEnvironment _environment;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostEnvironment, IHostingEnvironment environment)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
            _environment = environment;
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


        public IActionResult Upload()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddDocument(IEnumerable<IFormFile> DocumentPhotos)
        {

            if (DocumentPhotos!= null)
            {
              
                
                foreach (var item in DocumentPhotos)
                {

                    using (MemoryStream stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        
                    }                    
                }
            }

            return View( "Inxex");
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    string folderRoot = Path.Combine(_environment.ContentRootPath, "Uploads");
                    string filePath = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    filePath = Path.Combine(folderRoot, filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                return Ok(new { success = true, message = "File Uploaded" });
            }
            catch (Exception)
            {
                return BadRequest(new { success = false, message = "Error file failed to upload" });
            }
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
