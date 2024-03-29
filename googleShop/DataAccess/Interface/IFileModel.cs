﻿using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interface
{
    public interface IFileModel
    {
        IEnumerable<FileModel> AllFiles { get; }
        void AddFile(FileModel file);
    }
}
