using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer.Models {
    public class ExFileSystemInfo {

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

        public string Name =>
            (IsDirectory) ? fileSystemInfo.Name : Path.GetFileNameWithoutExtension(fileSystemInfo.FullName);

        public string FullName => fileSystemInfo.FullName;

        public string Extension => (IsDirectory) ? "/" : fileSystemInfo.Extension;

        public bool Exists => fileSystemInfo.Exists;

        public void Delete() {
            fileSystemInfo.Delete();
        }
    }
}
