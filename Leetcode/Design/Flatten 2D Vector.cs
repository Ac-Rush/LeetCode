using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    public class Vector2D2
    {
        private List<int> List;
        private int index;
        public Vector2D2(IList<IList<int>> vec2d)
        {
            List= new List<int>();
            foreach (var l in vec2d)
            {
                List.AddRange(l);
            }
            index = 0;
        }

        public bool HasNext()
        {
            return index < List.Count;
        }

        public int Next()
        {
            return List[index++];
        }
    }

    public class Vector2D
    {
        IEnumerator<int> itr1;
        IEnumerator<IList<int>> itr2;
        public Vector2D(IList<IList<int>> vec2d)
        {
            itr1 = null;
            itr2 = vec2d.GetEnumerator();
        }

        public bool HasNext()
        {
            while (itr1 == null || !itr1.MoveNext())
            {
                if (!itr2.MoveNext())
                {
                    return false;
                }

                itr1 = itr2.Current.GetEnumerator();
            }

            return true;
        }

        public int Next()
        {
            return itr1.Current;
        }
    }
}
