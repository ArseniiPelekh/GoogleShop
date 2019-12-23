using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interface
{
    public interface IAvatarFile
    {
        IEnumerable<AvatarFileModel> AllFiles { get; }
        void AddFiles(AvatarFileModel file);
    }
}
