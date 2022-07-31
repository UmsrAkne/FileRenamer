namespace FileRenamer.Models
{
    using System.Collections.Generic;

    public class Util
    {
        /// <summary>
        /// 入力されたリスト内の重複する文字列のリストを返却します。
        /// </summary>
        /// <param name="names">全てのファイル名を含めたリストを入力します。</param>
        /// <returns>重複が存在した場合はその文字列のリストを、存在しない場合は要素０のリストを返します。</returns>
        public static List<string> FindDuplicateName(List<string> names)
        {
            HashSet<string> nameSet = new HashSet<string>();
            var duplicates = new List<string>();
            foreach (string name in names)
            {
                if (nameSet.Add(name) == false)
                {
                    duplicates.Add(name);
                }
            }

            return duplicates;
        }
    }
}
