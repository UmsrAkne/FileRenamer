using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer.Models
{
    public class ExFileSystemInfo : BindableBase
    {

        private FileSystemInfo fileSystemInfo;
        public bool IsDirectory { get; private set; }

        public ExFileSystemInfo(string filePath)
        {

            IsDirectory = File.GetAttributes(filePath).HasFlag(FileAttributes.Directory);

            if (IsDirectory)
            {
                fileSystemInfo = new DirectoryInfo(filePath);
            }
            else
            {
                fileSystemInfo = new FileInfo(filePath);
            }

            AfterName = Name;
        }

        public string Name =>
            (IsDirectory) ? fileSystemInfo.Name : Path.GetFileNameWithoutExtension(fileSystemInfo.FullName);

        public string FullName => fileSystemInfo.FullName;

        public string Extension => (IsDirectory) ? "/" : fileSystemInfo.Extension;

        public string AfterName { get => afterName; set => SetProperty(ref afterName, value); }
        private string afterName = "";

        public string ParentDirectoryName => Directory.GetParent(fileSystemInfo.FullName).Name;

        public bool Exists => fileSystemInfo.Exists;

        public void Delete()
        {
            fileSystemInfo.Delete();
        }

        public void rename()
        {

            String basePath = Directory.GetParent(fileSystemInfo.FullName).FullName + "\\";

            if (IsDirectory)
            {
                Directory.Move(basePath + fileSystemInfo.Name, basePath + AfterName);
                fileSystemInfo = new DirectoryInfo(basePath + AfterName);
            }
            else
            {
                File.Move(basePath + fileSystemInfo.Name, basePath + AfterName + Extension);
                fileSystemInfo = new FileInfo(basePath + AfterName + Extension);
            }

            RaisePropertyChanged(nameof(Name));
            RaisePropertyChanged(nameof(AfterName));
            RaisePropertyChanged(nameof(FullName));
        }

    }
}
