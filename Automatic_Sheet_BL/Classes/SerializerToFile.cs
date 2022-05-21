using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Sheet_BL
{
    public class SerializerToFile : ISerializerToFile
    {
        public void SerializeToFile(string data)
        {
            using (FileStream fs = new FileStream("Данные ведомости.txt", FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.Default.GetBytes(data);
                fs.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
