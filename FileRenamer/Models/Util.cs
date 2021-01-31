using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer.Models {
    public class Util {

        /// <summary>
        /// 入力されたリスト内の重複する文字列を返却します。
        /// </summary>
        /// <param name="names"></param>
        /// <returns>重複が存在した場合はその文字列を、存在しない場合は空文字を返します。</returns>
        public string findDuplicateName(List<string> names) {
            HashSet<String> nameSet = new HashSet<String>();
            foreach(string name in names) {
                if (nameSet.Add(name) == false) {
                    return name;
                }
            }

            return "";
        }
    }
}
