using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.ReadAllLines(@"E:\tool\dri\machines.csv");
            var list = File.ReadAllText(@"E:\tool\dri\list.txt");
            var set = new HashSet<string>(list.Split(new []{','}));

            using (System.IO.StreamWriter output =
            new System.IO.StreamWriter(@"E:\tool\dri\machines2.csv", true))
            {
                foreach (var line in file)
                {
                    if (!line.StartsWith("#"))
                    {
                        var seg = line.Split(new[] {','});
                        if (!set.Contains(seg[0]))
                        {
                            output.WriteLine(line);
                        }
                        else
                        {
                            seg[2] = "NU";
                            seg[3] = "0";
                            output.WriteLine(string.Join(",",seg));
                        }
                    }
                    else
                    {

                        output.WriteLine(line);
                    }

                }
            }
        }
    }
}
