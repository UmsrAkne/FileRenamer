using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileRenamer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileRenamer.Models.Tests {
    [TestClass()]
    public class ExFileSystemInfoTests {
        [TestMethod()]
        public void renameTest() {
            DirectoryInfo testDirectory = new DirectoryInfo("testDirectory");
            if (testDirectory.Exists) {
                Directory.Delete(testDirectory.FullName, true);
            }

            testDirectory.Create();

            FileInfo testFile = new FileInfo(@"testDirectory\testFile.txt");
            testFile.Create().Close();

            ExFileSystemInfo directory = new ExFileSystemInfo(@"testDirectory");
            Assert.IsTrue(directory.IsDirectory);

            ExFileSystemInfo file = new ExFileSystemInfo(@"testDirectory\testFile.txt");
            Assert.IsFalse(file.IsDirectory);

            Assert.AreEqual(file.Name, "testFile");

            file.AfterName = "renamedFile";
            file.rename();

            Assert.AreEqual(file.Name, "renamedFile");
        }
    }
}