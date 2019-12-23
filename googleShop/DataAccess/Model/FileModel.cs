using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data.Model
{
    public class FileModel
    {
        public static readonly FileAccess Create;

        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }
        public DateTime DateTimeDownload { get; set; }
        public string Path { get; set; }
    }
}

