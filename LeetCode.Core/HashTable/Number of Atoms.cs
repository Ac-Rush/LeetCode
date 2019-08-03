using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Number_of_Atoms
    {
        /*
        int i;
        /// <summary>
        /// Recursion 
        /// </summary>
        /// <param name="formula"></param>
        /// <returns></returns>
        public string CountOfAtoms(string formula)
        {
            StringBuilder ans = new StringBuilder();
            i = 0;
           var count = parse(formula);
            for (String name: count.keySet())
            {
                ans.append(name);
                int multiplicity = count.get(name);
                if (multiplicity > 1) ans.append("" + multiplicity);
            }
            return new String(ans);
        }

        public Dictionary<String, int> parse(String formula)
        {
            int N = formula.Length;
            var count = new SortedDictionary<string,int>();
            while (i < N && formula[i] != ')')
            {
                if (formula[i] == '(')
                {
                    i++;
                    foreach (var key parse(formula).Keys)
                    {
                        count.put(entry.getKey(), count.getOrDefault(entry.getKey(), 0) + entry.getValue());
                    }
                }
                else
                {
                    int iStart = i++;
                    while (i < N && Character.isLowerCase(formula.charAt(i))) i++;
                    String name = formula.substring(iStart, i);
                    iStart = i;
                    while (i < N && Character.isDigit(formula.charAt(i))) i++;
                    int multiplicity = iStart < i ? Integer.parseInt(formula.substring(iStart, i)) : 1;
                    count.put(name, count.getOrDefault(name, 0) + multiplicity);
                }
            }
            int iStart = ++i;
            while (i < N && Character.isDigit(formula.charAt(i))) i++;
            if (iStart < i)
            {
                int multiplicity = Integer.parseInt(formula.substring(iStart, i));
                for (String key: count.keySet())
                {
                    count.put(key, count.get(key) * multiplicity);
                }
            }
            return count;
        }
        */
    }
}
