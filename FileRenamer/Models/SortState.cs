using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer.Models
{
    public class SortState
    {

        public FileListColumnName SortColumnName
        {
            get => sortColumnName;
            set
            {
                if (value != sortColumnName)
                {
                    sortColumnName = value;
                    sortType = SortType.ASC;
                }
                else
                {

                    switch (sortType)
                    {
                        case SortType.ASC:
                            sortType = SortType.DESC;
                            break;

                        case SortType.DESC:
                            sortType = SortType.None;
                            break;

                        case SortType.None:
                            sortType = SortType.ASC;
                            break;

                    }
                }
            }
        }

        public List<ExFileSystemInfo> sort(List<ExFileSystemInfo> list)
        {
            var l = new List<ExFileSystemInfo>();
            Func<ExFileSystemInfo, string> func; // ソートの条件を先に格納してソート処理自体は最後に行う。

            switch (SortColumnName)
            {
                case FileListColumnName.CurrentName:
                    func = new Func<ExFileSystemInfo, string>(f => f.Name);
                    break;

                case FileListColumnName.AfterName:
                    func = new Func<ExFileSystemInfo, string>(f => f.AfterName);
                    break;

                case FileListColumnName.Type:
                    func = new Func<ExFileSystemInfo, string>(f => f.Extension);
                    break;

                case FileListColumnName.ParentDirectory:
                    func = new Func<ExFileSystemInfo, string>(f => f.ParentDirectoryName);
                    break;

                default:
                    func = new Func<ExFileSystemInfo, string>(f => f.Name);
                    break;
            }

            if (sortType == SortType.ASC)
            {
                l = list.OrderBy(func).ToList<ExFileSystemInfo>();
            }

            if (sortType == SortType.DESC)
            {
                l = list.OrderByDescending(func).ToList<ExFileSystemInfo>();
            }

            if (sortType == SortType.None)
            {
                l = list.OrderBy(func).ToList<ExFileSystemInfo>();
            }

            return l;
        }

        private FileListColumnName sortColumnName;
        private SortType sortType;

        public enum FileListColumnName
        {
            ParentDirectory,
            CurrentName,
            AfterName,
            Type,
            None
        }

        private enum SortType
        {
            ASC,
            DESC,
            None,
        }
    }
}
