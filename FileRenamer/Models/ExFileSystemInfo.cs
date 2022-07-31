namespace FileRenamer.Models
{
    using System.IO;
    using Prism.Mvvm;

    public class ExFileSystemInfo : BindableBase
    {
        private FileSystemInfo fileSystemInfo;
        private string afterName = string.Empty;

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

        public bool IsDirectory { get; private set; }

        public string Name => IsDirectory ? fileSystemInfo.Name : Path.GetFileNameWithoutExtension(fileSystemInfo.FullName);

        public string FullName => fileSystemInfo.FullName;

        public string Extension => IsDirectory ? "/" : fileSystemInfo.Extension;

        public string AfterName { get => afterName; set => SetProperty(ref afterName, value); }

        public string ParentDirectoryName => Directory.GetParent(fileSystemInfo.FullName).Name;

        public bool Exists => fileSystemInfo.Exists;

        public void Delete()
        {
            fileSystemInfo.Delete();
        }

        public void Rename()
        {
            string basePath = Directory.GetParent(fileSystemInfo.FullName).FullName + "\\";

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
