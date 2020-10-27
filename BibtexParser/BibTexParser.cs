using System;
using System.IO;

namespace PDP.Aoraki.BibtexLib.bitRebels
{
    public class BibTexParser
    {
        private BibTeXFile bibfile;
        string fileName;
    
        public BibTeXFile BibFile
        {
            get { return bibfile;  }
        }

        public BibTexParser(StreamReader sr, string fileName)
        {
            bibfile = new BibTeXFile();
            this.fileName = fileName;
            Parse(sr);
        }

        public void Parse(StreamReader sr)
        {
            
            string line;
            string entry = "";

            while ((line = sr.ReadLine()) != null)
            {
                if (line == String.Empty) {

                    continue;
                }

                string firstCharacter = line.TrimStart().Substring(0, 1);
                if (firstCharacter != "@" || firstCharacter == "%")
                {
                    continue;
                }

                string checkForStringCommand = line.Substring(0, line.IndexOf("{")).ToLower();

                switch (checkForStringCommand)
                {
                    case "@string":
                        bibfile.addStringAbbreviation(line);
                        break;
                    case "@comme":
                        continue;
                    default:
                        entry = line + "\n" + parseEntry(sr);
                        bibfile.addEntry(entry);
                        break;
                }
                
            }
           bibfile.serializeToFile(fileName);
        }

        public string parseEntry(StreamReader sr)
        {
            string line;
            string output = "";

            while ((line = sr.ReadLine()) != "}")
            {
                output += line + "\n";
            }
            output += "}";
            return output;
        }

    }
}