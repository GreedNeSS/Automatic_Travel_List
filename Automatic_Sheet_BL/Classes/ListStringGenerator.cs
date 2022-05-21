using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Sheet_BL
{
    public class ListStringGenerator : IListStringGenerator
    {
        public string CreateDataStringList(List<string> strings)
        {
            string stringList = string.Join("\n", strings);
            return stringList;
        }
    }
}
