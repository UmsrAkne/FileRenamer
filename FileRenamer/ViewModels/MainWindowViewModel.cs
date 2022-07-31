namespace FileRenamer.ViewModels
{
    using System.Collections.Generic;
    using FileRenamer.Models;
    using Prism.Commands;
    using Prism.Mvvm;
    using static FileRenamer.Models.SortState;

    public class MainWindowViewModel : BindableBase
    {
        private string title = "Prism Application";
        private List<ExFileSystemInfo> fileList = new List<ExFileSystemInfo>();
        private Renamer renamer;
        private SortState sortState;
        private RenameOption renameOption = new RenameOption();
        private FileListColumnName sortColumnName = FileListColumnName.None;
        private DelegateCommand attachNumberCommand;
        private DelegateCommand attachStringCommand;
        private DelegateCommand renameCommand;
        private DelegateCommand<string> sortCommand;

        public MainWindowViewModel()
        {
            renamer = new Renamer(FileList);
            sortState = new SortState();
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public List<ExFileSystemInfo> FileList { get => fileList; set => SetProperty(ref fileList, value); }

        public RenameOption RenameOption
        {
            get => renameOption; set => SetProperty(ref renameOption, value);
        }

        public FileListColumnName SortColumnName { get => sortColumnName; set => SetProperty(ref sortColumnName, value); }

        public DelegateCommand AttachNumberCommand
        {
            get => attachNumberCommand ?? (attachNumberCommand = new DelegateCommand(() =>
            {
                renamer.Files = FileList;
                renamer.InsertNumber(RenameOption.NumberInsertIndex, RenameOption.StartCount, RenameOption.Digits);
            }));
        }

        public DelegateCommand AttachStringCommand
        {
            get => attachStringCommand ?? (attachStringCommand = new DelegateCommand(() =>
            {
                renamer.Files = fileList;
                renamer.InsertString(RenameOption.StringInsertIndex, RenameOption.AttachmentString);
            }));
        }

        public DelegateCommand RenameCommand
        {
            get => renameCommand ?? (renameCommand = new DelegateCommand(() =>
            {
                renamer.Files = fileList;
                renamer.Rename();
            }));
        }

        public DelegateCommand<string> SortCommand
        {
            get => sortCommand ?? (sortCommand = new DelegateCommand<string>((string columnName) =>
            {
                FileListColumnName newName = (FileListColumnName)System.Enum.Parse(typeof(FileListColumnName), columnName);
                sortState.SortColumnName = newName;
                FileList = sortState.Sort(FileList);
            }));
        }
    }
}
