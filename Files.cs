using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ADOdotNETeg
{
    internal class Files
    {
        public static void Main()
        {
            FileStream fs = new FileStream("message.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            Console.Write("Enter your first name: ");
            string? firstname = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string? lastname = Console.ReadLine();
            sw.WriteLine(firstname + " " + lastname);
            sw.WriteLine(firstname + " " + lastname);
            sw.Flush();
            fs.Close();
        }
    }
}
