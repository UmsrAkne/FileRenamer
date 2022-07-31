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
            renamer.InsertString(0, "insert");
            renamer.Rename();

            Assert.AreEqual(files[0].Name, "inserttestFile1");
            Assert.AreEqual(files[1].Name, "inserttestFile2");

            renamer.InsertString(1, "i");
            renamer.Rename();
            Assert.AreEqual(files[0].Name, "iinserttestFile1");

            renamer.InsertString(50, "x");
            renamer.Rename();
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
            renamer.AttachStringToEnd("end");
            renamer.Rename();
            Assert.AreEqual(files[0].Name, "testFile1end");
        }

        [TestMethod()]
        public void insertNumberTest() {
            var testDirectory = new DirectoryInfo("testDirectory");
            if (testDirectory.Exists) {
                Directory.Delete("testDirectory", true);
            }

            testDirectory.Create();
            List<FileInfo> testFiles = new List<FileInfo>();

            for(int i = 0; i < 11; i++) {
                testFiles.Add(new FileInfo($"testDirectory/testFile{i.ToString()}.txt"));
                testFiles[i].Create().Close();
            }

            var files = new List<ExFileSystemInfo>();

            for(int i = 0; i < testFiles.Count; i++) {
                files.Add(new ExFileSystemInfo(testFiles[i].FullName));
            }

            Renamer renamer = new Renamer(files);
            renamer.InsertNumber(0);
            renamer.Rename();
            Assert.AreEqual(files[0].Name, "0testFile0");
            Assert.AreEqual(files[1].Name, "1testFile1");
            Assert.AreEqual(files[10].Name, "10testFile10");

            renamer.InsertNumber(0, 1, 3);
            renamer.Rename();
            Assert.AreEqual(files[0].Name, "0010testFile0");
            Assert.AreEqual(files[10].Name, "01110testFile10");

            files[0].AfterName = "testFile";
            files[0].Rename();
            renamer.InsertNumber(1, 1, 3);
            renamer.Rename();
            Assert.AreEqual(files[0].Name, "t001estFile");

            renamer.AttachNumberToEnd(2, 3);
            renamer.Rename();
            Assert.AreEqual(files[0].Name, "t001estFile002");
        }
    }
}