using FileRenamer.Models;
using Prism.Mvvm;
using System.Collections.Generic;
using System.IO;

namespace FileRenamer.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private List<ExFileSystemInfo> fileList = new List<ExFileSystemInfo>();
        public List<ExFileSystemInfo> FileList { get => fileList; set => SetProperty(ref fileList, value); }

        public MainWindowViewModel() {

        }
    }
}
