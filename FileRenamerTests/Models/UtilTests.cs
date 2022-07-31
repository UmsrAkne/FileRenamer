using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileRenamer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer.Models.Tests {
    [TestClass()]
    public class UtilTests {
        [TestMethod()]
        public void findDuplicateNameTest() {
            var list = new List<String>(new String[] { "a","b","c","c","d","d"});
            Assert.AreEqual(Util.FindDuplicateName(list)[0], "c");
            Assert.AreEqual(Util.FindDuplicateName(list)[1], "d");

            var listb = new List<String>(new String[] { "a", "b", "c" });
            Assert.AreEqual(Util.FindDuplicateName(listb).Count, 0);
        }
    }
}