using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer.Models {
    public class ExFileSystemInfo : FileSystemInfo {

        private FileSystemInfo fileSystemInfo;
        public bool IsDirectory { get; private set; }

        public ExFileSystemInfo(string filePath) {

            IsDirectory = File.GetAttributes(filePath).HasFlag(FileAttributes.Directory);

            if (IsDirectory) {
                fileSystemInfo = new DirectoryInfo(filePath);
            }
            else {
                fileSystemInfo = new FileInfo(filePath);
            }
        }

        public override string Name =>
            (IsDirectory) ? fileSystemInfo.Name : Path.GetFileNameWithoutExtension(fileSystemInfo.FullName);

        public override string FullName => fileSystemInfo.FullName;

        public new string Extension => (IsDirectory) ? "/" : fileSystemInfo.Extension;

        public override bool Exists => fileSystemInfo.Exists;

        public override void Delete() {
            fileSystemInfo.Delete();
        }
    }
}
