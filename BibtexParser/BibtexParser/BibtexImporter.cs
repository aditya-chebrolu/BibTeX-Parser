using System.IO;
using System;
using System.IO.Enumeration;

namespace PDP.Aoraki.BibtexLib.bitRebels
{
    public static class BibtexImporter
    {
        public static void Main(string[] args)
        {
            string fileName = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())), "OutputFiles\\");
            using (StreamReader sr = new StreamReader(fileName))
            {
                BibTexParser test = new BibTexParser(sr, args[0]);
            }
        }
    }
}
