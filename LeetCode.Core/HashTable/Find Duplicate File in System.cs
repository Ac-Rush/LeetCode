using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Find_Duplicate_File_in_System
    {
        public IList<IList<string>> FindDuplicate(string[] paths)
        {
            var map = new Dictionary<string, List<string>>();
            foreach (var path in paths)
            {
                String[] values = path.Split(new[] {' '});
                for (int i = 1; i < values.Length; i++)
                {
                    String[] name_cont = values[i].Split('(');
                    name_cont[1] = name_cont[1].Replace(")", "");
                    List<String> list = map.ContainsKey(name_cont[1]) ? map[name_cont[1]] : new List<string>();
                    list.Add(values[0] + "/" + name_cont[0]);
                    map[name_cont[1]] = list;
                }
            }
            List<IList<String>> res = new List<IList<String>>();
            foreach (String key in map.Keys)
            {
                if (map[key].Count > 1)
                    res.Add(map[key]);
            }
            return res;
        }
    }
}
