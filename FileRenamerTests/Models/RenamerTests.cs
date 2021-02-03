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
    public class RenamerTests {
        [TestMethod()]
        public void insertStringTest() {

            var testDirectory = new DirectoryInfo("testDirectory");
            if (testDirectory.Exists) {
                Directory.Delete("testDirectory", true);
            }

            testDirectory.Create();

            var testFile1 = new FileInfo("testDirectory/testFile1.txt");
            var testFile2 = new FileInfo("testDirectory/testFile2.txt");

            testFile1.Create().Close();
            testFile2.Create().Close();

            var files = new List<ExFileSystemInfo>();
            files.Add(new ExFileSystemInfo(testFile1.FullName));
            files.Add(new ExFileSystemInfo(testFile2.FullName));

            Renamer renamer = new Renamer(files);
            renamer.insertString(0, "insert");

            Assert.AreEqual(files[0].Name, "inserttestFile1");
            Assert.AreEqual(files[1].Name, "inserttestFile2");

            renamer.insertString(1, "i");
            Assert.AreEqual(files[0].Name, "iinserttestFile1");

            renamer.insertString(50, "x");
            Assert.AreEqual(files[0].Name, "iinserttestFile1x");
        }

        [TestMethod()]
        public void attachStringToEndTest() {

            var testDirectory = new DirectoryInfo("testDirectory");
            if (testDirectory.Exists) {
                Directory.Delete("testDirectory", true);
            }

            testDirectory.Create();

            var testFile1 = new FileInfo("testDirectory/testFile1.txt");
            var testFile2 = new FileInfo("testDirectory/testFile2.txt");

            testFile1.Create().Close();
            testFile2.Create().Close();

            var files = new List<ExFileSystemInfo>();
            files.Add(new ExFileSystemInfo(testFile1.FullName));
            files.Add(new ExFileSystemInfo(testFile2.FullName));

            Renamer renamer = new Renamer(files);
            renamer.attachStringToEnd("end");
            Assert.AreEqual(files[0].Name, "testFile1end");
        }
    }
}