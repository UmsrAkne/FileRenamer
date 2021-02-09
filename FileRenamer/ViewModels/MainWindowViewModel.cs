using FileRenamer.Models;
using Prism.Commands;
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

        private Renamer renamer;

        public RenameOption RenameOption {
            get => renameOption; set => SetProperty(ref renameOption, value); 
        }

        private RenameOption renameOption = new RenameOption();

        public MainWindowViewModel() {
            renamer = new Renamer(FileList);
        }

        public FileListColumnName SortColumnName { get => sortColumnName; set => SetProperty(ref sortColumnName, value); }
        private FileListColumnName sortColumnName = FileListColumnName.None;

        public DelegateCommand AttachNumberCommand {
            #region
            get => attachNumberCommand ?? (attachNumberCommand = new DelegateCommand(() => {
                renamer.Files = FileList;
                renamer.insertNumber(RenameOption.NumberInsertIndex, RenameOption.StartCount, RenameOption.Digits);
            }));
        }
        private DelegateCommand attachNumberCommand;
        #endregion


        public DelegateCommand AttachStringCommand {
            #region
            get => attachStringCommand ?? (attachStringCommand = new DelegateCommand(() => {
                renamer.Files = fileList;
                renamer.insertString(RenameOption.StringInsertIndex, RenameOption.AttachmentString);
            }));
        }
        private DelegateCommand attachStringCommand;
        #endregion


        public DelegateCommand RenameCommand {
            #region
            get => renameCommand ?? (renameCommand = new DelegateCommand(() => {
                renamer.Files = fileList;
                renamer.rename();
            }));
        }
        private DelegateCommand renameCommand;
        #endregion

        public enum FileListColumnName {
            ParentDirectory,
            CurrentName,
            AfterName,
            Extension,
            None
        }

    }
}
