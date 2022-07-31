namespace FileRenamer.Models
{
    using System.Collections.Generic;

    public class Renamer
    {
        public Renamer(List<ExFileSystemInfo> targetFiles)
        {
            Files = targetFiles;
        }

        public List<ExFileSystemInfo> Files { get; set; }

        /// <summary>
        /// リスト内のファイルの Name プロパティに対して、引数で指定された位置に文字列を挿入します。
        /// </summary>
        /// <param name="index">文字列を挿入する位置</param>
        /// <param name="str">挿入する文字列</param>
        public void InsertString(int index, string str)
        {
            Files.ForEach(f =>
            {
                if (f.AfterName.Length > index)
                {
                    f.AfterName = f.AfterName.Insert(index, str);
                }
                else
                {
                    f.AfterName += str;
                }
            });
        }

        /// <summary>
        /// リスト内のファイルの Nameプロパティの末尾に、引数で指定した文字列を追加します。
        /// </summary>
        /// <param name="str">付与する文字列</param>
        public void AttachStringToEnd(string str)
        {
            Files.ForEach(f =>
            {
                f.AfterName += str;
            });
        }

        /// <summary>
        /// リスト内のファイルの Name プロパティの指定位置に、連番を挿入します。
        /// </summary>
        /// <param name="index">連番の挿入位置を指定します。先頭は０番です。</param>
        /// <param name="startCount">連番の開始番号を指定します。未指定の場合は０からとなります。</param>
        /// <param name="digits">連番が指定した桁数になるよう０を挿入して調節します。</param>
        public void InsertNumber(int index, int startCount = 0, int digits = 1)
        {
            Files.ForEach(f =>
            {
                string countString = string.Format("{0:D" + digits.ToString() + "}", startCount);

                if (f.AfterName.Length > index)
                {
                    f.AfterName = f.AfterName.Insert(index, countString);
                }
                else
                {
                    f.AfterName += countString;
                }

                startCount++;
            });
        }

        public void AttachNumberToEnd(int startCount = 0, int digits = 1)
        {
            InsertNumber(int.MaxValue, startCount, digits);
        }

        public void Rename()
        {
            Files.ForEach(f => f.Rename());
        }
    }
}
