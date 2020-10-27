using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;

namespace PDP.Aoraki.BibtexLib.bitRebels
{
    public class BibTeXFile
    {
        private readonly List<BibTeXEntry> entries = new List<BibTeXEntry>();
        private readonly Dictionary<string, string> stringAbbreviations = new Dictionary<string, string>();

        public BibTeXFile()
        {

        }

        public List<BibTeXEntry> Entries
        {
            get => entries;
        }

        public Dictionary<string, string> StringAbbreviations
        {
            get => stringAbbreviations;
        }

        public void addEntry(string entry)
        {
            BibTeXEntry bibentry = new BibTeXEntry(entry);
            bibentry.GetBibTeXEntry();
            replaceAbbreviations(bibentry);
            entries.Add(bibentry);
        }

        public void addStringAbbreviation(string entry)
        {
            int openingParenthesisIndex = entry.IndexOf("{");
            int equalsIndex = entry.IndexOf("=");
            int closingParanthesisIndex = entry.IndexOf("}");

            string abbrevation = entry.Substring(openingParenthesisIndex + 1, equalsIndex - openingParenthesisIndex - 1).Replace(" ", "");
            string phrase = entry.Substring(equalsIndex).Substring(openingParenthesisIndex + 1, closingParanthesisIndex - openingParenthesisIndex - 1);
            stringAbbreviations.Add(abbrevation, phrase);
        }

        public void replaceAbbreviations(BibTeXEntry entry)
        {
            foreach (KeyValuePair<string, string> field in entry.Fields)
            {
                string f = field.Value;
                if (stringAbbreviations.ContainsKey(f))
                {
                    entry.Fields[field.Key] = stringAbbreviations[f];
                    break;
                }
            }
        }

        public void serializeToFile(string fileName)
        {
            StreamWriter outputFile = new StreamWriter(Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())), "BibDataFiles\\" + fileName));
            foreach (BibTeXEntry entry in entries)
            {
                outputFile.WriteLine(entry.GetBibTeXEntry());
            }
            outputFile.Flush();
        }
    }
}
