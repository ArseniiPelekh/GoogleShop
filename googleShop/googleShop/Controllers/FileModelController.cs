using System.IO;
using Data.Interface;
using Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace googleShop.Controllers
{
    public class FileModelController : Controller
    {
        private readonly IFileModel _accessFile;
        IHostingEnvironment _appEnvironment;

        public FileModelController(IFileModel repository, IHostingEnvironment appEnvironment)
        {
            _accessFile = repository;
            _appEnvironment = appEnvironment;
        }

        public IActionResult InsertFile()
        {
            return View(_accessFile.AllFiles);
        }

        [HttpPost]
        public async Task<IActionResult> InsertFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {

                string path = "/Files/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }

                FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path, ContentType = uploadedFile.ContentType, Size = uploadedFile.Length, DateTimeDownload = DateTime.Now };

                //add database
                _accessFile.AddFile(file);

                return RedirectToAction("InsertFile");
            }

            return RedirectToAction(ErrorEventArgs.Empty.ToString());
        }
    }
}