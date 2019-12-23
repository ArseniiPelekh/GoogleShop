using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Data.Interface;
using Data.Model;
using googleShop.ViewModes;
using Microsoft.AspNetCore.Mvc;

namespace googleShop.Controllers
{
    public class AvatarFileController : Controller
    {
        private readonly IAvatarFile _accessFile;

        public AvatarFileController(IAvatarFile repository)
        {
            _accessFile = repository;
        }

        public IActionResult AddFile()
        {
            return View(_accessFile.AllFiles);
        }

        [HttpPost]
        public IActionResult AddFile(FileViewModel fvm)
        {
            AvatarFileModel _fileModel = new AvatarFileModel { Name = fvm.Name };
            if (fvm.File != null)
            {
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(fvm.File.OpenReadStream()))
                {
                    fileData = binaryReader.ReadBytes((int)fvm.File.Length);
                }

                _fileModel.FileType = fileData;
                _accessFile.AddFiles(_fileModel);
                return RedirectToAction("AddFile");
            }

            return RedirectToAction(ErrorEventArgs.Empty.ToString());
        }
    }
}