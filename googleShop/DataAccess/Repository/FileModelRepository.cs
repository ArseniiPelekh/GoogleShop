using Data.Interface;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class FileModelRepository : IFileModel
    {
        private readonly AppDBContent appDBContent;

        public FileModelRepository(AppDBContent appDB)
        {
            this.appDBContent = appDB;
        }

        public IEnumerable<FileModel> AllFiles => appDBContent.Files;

        public void AddFile(FileModel file)
        {
            appDBContent.Files.Add(file);
            appDBContent.SaveChanges();
        }
    }
}
