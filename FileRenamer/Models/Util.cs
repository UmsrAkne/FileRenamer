using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer.Models {
    public class Util {

        /// <summary>
        /// 入力されたリスト内の重複する文字列のリストを返却します。
        /// </summary>
        /// <param name="names">全てのファイル名を含めたリストを入力します。</param>
        /// <returns>重複が存在した場合はその文字列のリストを、存在しない場合は要素０のリストを返します。</returns>
        public static List<String> findDuplicateName(List<string> names) {
            HashSet<String> nameSet = new HashSet<String>();
            var duplicates = new List<String>();
            foreach(string name in names) {
                if (nameSet.Add(name) == false) {
                    duplicates.Add(name);
                }
            }

            return duplicates;
        }
    }
}
