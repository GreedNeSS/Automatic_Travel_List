using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Sheet_BL
{
    public class ListStringGenerator : IListStringGenerator
    {
        public string CreateString(List<string> strings)
        {
            string stringList = string.Join("\n", strings);
            return stringList;
        }

        public string CreateTable(List<string> col1, List<string> col2, List<string> col3)
        {
            string table = string.Empty;

            for (int i = 0; i < col1.Count; i++)
            {
                table += $"{col1[i]},";
                table += $"\"{col2[i]}\",,";
                table += $"{col3[i]}\n";
            }

            return table;
        }
    }
}
