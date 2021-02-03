using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer.Models {
    public class Renamer {

        public Renamer(List<ExFileSystemInfo> targetFiles) {
            Files = targetFiles;
        }

        public List<ExFileSystemInfo> Files { get; set; }

        /// <summary>
        /// リスト内のファイルの Name プロパティに対して、引数で指定された位置に文字列を挿入します。
        /// </summary>
        /// <param name="index"></param>
        /// <param name="str"></param>
        public void insertString(int index, string str) {
            Files.ForEach(f => {
                f.AfterName = f.AfterName.Insert(index, str);
                f.rename();
            });
        } 

        /// <summary>
        /// リスト内のファイルの Nameプロパティの末尾に、引数で指定した文字列を追加します。
        /// </summary>
        /// <param name="str"></param>
        public void attachStringToEnd(string str) {
            Files.ForEach(f => {
                f.AfterName += str;
                f.rename();
            });
        }

    }
}
