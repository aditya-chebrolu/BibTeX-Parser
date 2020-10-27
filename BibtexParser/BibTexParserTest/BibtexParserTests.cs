using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDP.Aoraki.BibtexLib.bitRebels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PDP.Aoraki.BibtexLib.bitRebels.Tests
{
    [TestClass()]
    public class BibtexParserTests
    {
        //public const string filePath = "C:\\Users\\BHAVI_CyberPowerPC1\\Documents\\GitHub\\PDP-Aoraki\\PDP.Aoraki.BibtexLib.Tests\\BibDataFiles\\";

        [TestMethod]
        public void TestParseBibFile()
        {
            string test = @"@book{aaker:1912,
                                  author = {David A. Aaker}
                              }";
            //Dictionary<string, string> dict = new Dictionary<string, string> { { "author", "David A. Aaker" } };
            BibTeXEntry entry = new BibTeXEntry(test);
            Assert.AreEqual("aaker:1912", entry.Keyword);
            Assert.AreEqual("book", entry.Type);
           // Assert.AreEqual("author", entry.Fields.);
        }
    }
}