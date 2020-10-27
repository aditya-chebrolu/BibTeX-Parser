using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDP.Aoraki.BibtexLib.bitRebels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PDP.Aoraki.BibtexLib.bitRebels.Tests
{
    [TestClass()]
    public class BibtexImporterTests
    {
        public string filePath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())), "BibDataFiles\\");

        [TestMethod]
        public void TestImportBibFileComments()
        {
            using (StreamReader reader = new StreamReader(filePath + "comments.bib"))
            {
                BibTexParser testParser = new BibTexParser(reader,"temp1.bib");

                Assert.AreEqual(1, testParser.BibFile.Entries.Count);
            }
        }

        [TestMethod]
        public void TestImportBibFileBibParserTest1_In()
        {
            using (StreamReader reader = new StreamReader(filePath + "BibParserTest1_In.bib"))
            {
                BibTexParser testParser = new BibTexParser(reader, "temp2.bib");

                Assert.AreEqual(3, testParser.BibFile.Entries.Count);
            }
        }

        [TestMethod]
        public void TestImportBibFileSpecialCharacters()
        {
            using (StreamReader reader = new StreamReader(filePath + "special-characters.bib"))
            {
                BibTexParser testParser = new BibTexParser(reader, "temp3.bib");

                Assert.AreEqual(5, testParser.BibFile.Entries.Count);
            }
        }

        [TestMethod]
        public void TestImportBibFileFuzzyMining()
        {
            using (StreamReader reader = new StreamReader(filePath + "FuzzyMining.bib"))
            {
                BibTexParser testParser = new BibTexParser(reader, "temp4.bib");

                Assert.AreEqual(3, testParser.BibFile.Entries.Count);
            }
        }

        [TestMethod]
        public void TestImportBibFileNpdsPlagiarizedBiogrid()
        {
            using (StreamReader reader = new StreamReader(filePath + "NpdsPlagiarizedBiogrid.bib"))
            {
                BibTexParser testParser = new BibTexParser(reader, "temp6.bib");

                Assert.AreEqual(617, testParser.BibFile.Entries.Count);
            }
        }

        [TestMethod]
        public void TestImportBibFilePdpNpdsTaswell()
        {
            using (StreamReader reader = new StreamReader(filePath + "PdpNpdsTaswell.bib"))
            {
                BibTexParser testParser = new BibTexParser(reader, "temp7.bib");

                Assert.AreEqual(36, testParser.BibFile.Entries.Count);
            }
        }

        [TestMethod]
        public void TestImportBibFileCSSEAdityaChebolu()
        {
            using (StreamReader reader = new StreamReader(filePath + "CSSE-AdityaChebrolu-20200530.bib"))
            {
                BibTexParser testParser = new BibTexParser(reader, "temp8.bib");

                Assert.AreEqual(30, testParser.BibFile.Entries.Count);
            }
        }

    }
}