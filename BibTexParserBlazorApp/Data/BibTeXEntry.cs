using System;
using System.Collections.Generic;

namespace BibTexParserBlazorApp.Data
{
    public class BibTeXEntry
    {
        private string type;
        private string keyword;
        private Dictionary<string, string> fields = new Dictionary<string, string>();

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Keyword
        {
            get { return keyword; }
            set { keyword = value; }
        }

        public Dictionary<string, string> Fields
        {
            get { return fields; }
            set { fields = value; }
        }

        public BibTeXEntry(string fileContents)
        {
            type = fileContents.Substring(1, fileContents.IndexOf("{") - 1).ToLower();
            int openingParenthesisIndex = fileContents.IndexOf("{");
            keyword = fileContents.Substring(openingParenthesisIndex + 1, fileContents.IndexOf(",") - openingParenthesisIndex - 1);
            string[] list = fileContents.Split('\n');

            for (int i = 1; i < list.Length - 1; i++)
            {
                string line = list[i].TrimStart();
                string fieldName = line.Substring(0, line.IndexOf("=")).Trim(' ').ToLower();
                string fieldValue = line.Substring(line.IndexOf("=") + 1).TrimStart();
                string startOfFieldValue = fieldValue.Substring(0, 1);

               //System.Console.WriteLine(line.Substring(line.Length - 2));
                switch (startOfFieldValue)
                {
                    case "{":
                        while (i < list.Length - 1 && !line.Contains("},"))
                        {
                            ++i;
                            line = list[i].TrimStart();
                            if (line == "")
                            {
                                continue;
                            }
                            fieldValue += "\n\t" + line;
                        }
                        fieldValue = fieldValue.Substring(fieldValue.IndexOf("{") + 1, fieldValue.LastIndexOf("}") - fieldValue.IndexOf("{") - 1);
                        break;

                    default:
                        fieldValue = fieldValue.Substring(fieldValue.IndexOf("=") + 1, fieldValue.LastIndexOf(",") - fieldValue.IndexOf("=") - 1);
                        break;
                }

                fields.Add(fieldName, fieldValue);
            }
        }

        public string GetBibTeXEntry()
        {
            string result = "@" + type + "{" + keyword + "," + "\n";
            foreach (KeyValuePair<string, string> item in fields)
            {
                result += "  " + item.Key + " = " + "{" + item.Value + "}" + "," + "\n";
            }
            result += "}\n";
            return result;
        }
    }
}


