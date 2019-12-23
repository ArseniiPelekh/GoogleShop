using Data.Interface;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class AvatarFileRepository : IAvatarFile
    {
        private readonly AppDBContent appDBContent;

        public AvatarFileRepository(AppDBContent appDB)
        {
            this.appDBContent = appDB;
        }

        public IEnumerable<AvatarFileModel> AllFiles => appDBContent.AvatarFiles;

        public void AddFiles(AvatarFileModel file)
        {
            appDBContent.AvatarFiles.Add(file);
            appDBContent.SaveChanges();
        }
    }
}
