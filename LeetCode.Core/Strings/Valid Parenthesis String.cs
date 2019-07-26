using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Valid_Parenthesis_String
    {
        /// <summary>
        /// /这里维护了两个变量low和high，其中low表示在有左括号的情况下，
        /// 将星号当作右括号时左括号的个数(这样做的原因是尽量不多增加右括号的个数)，
        /// 而high表示将星号当作左括号时左括号的个数。是不是很绕
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// 
/*
 * 那么当high小于0时，说明就算把星号都当作左括号了，还是不够抵消右括号，返回false。
 * 而当low大于0时，说明左括号的个数太多了，没有足够多的右括号来抵消，返回false。
 * 那么开始遍历字符串，当遇到左括号时，low和high都自增1；
 * 当遇到右括号时，只有当low大于0时，low才自减1，保证了low不会小于0，而high直接自减1；
 * 当遇到星号时，只有当low大于0时，low才自减1，保证了low不会小于0，而high直接自增1，因为high把星号当作左括号。
 * 当此时high小于0，说明右括号太多，返回false。当循环退出后，我们看low是否为0
 */
public bool CheckValidString(string s)
{
    int low = 0;
    int high = 0;
    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] == '(')
        {
            low++;
            high++;
        }
        else if (s[i] == ')')
        {
            if (low > 0)
            {
                low--;
            }
            high--;
        }
        else
        {
            if (low > 0)
            {
                low--;
            }
            high++;
        }
        if (high < 0)
        {
            return false;
        }
    }
    return low == 0;
}
}


class Valid_Parenthesis_String_Stack
{
public bool CheckValidString(string s)
{
    var left = new Stack<int>();
    var  star = new Stack<int>();
    for (int i = 0; i < s.Length; ++i)
    {
        if (s[i] == '*') star.Push(i);
        else if (s[i] == '(') left.Push(i);
        else
        {
            if (left.Count == 0 && star.Count ==0) return false;
            if (left.Count != 0) left.Pop();
            else star.Pop();
        }
    }
    while (left.Count != 0 && star.Count != 0)
    {
        if (left.Peek() > star.Peek()) return false;
        left.Pop(); star.Pop();
    }
    return left.Count == 0;
}
}

class Valid_Parenthesis_String_my
{
/// <summary>
/// backtracking
/// </summary>
/// <param name="s"></param>
/// <returns></returns>
public bool CheckValidString(string s)
{
    return Dfs(s, 0, 0, 0);
}

private bool Dfs(string s, int l, int r, int index)
{
    if (index == s.Length)
    {
        if (l == r)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    if (r > l)
    {
        return false;
    }
    if (s[index] == '(')
    {
        return Dfs(s, l + 1, r, index + 1);
    }
    else if (s[index] == ')')
    {
        return Dfs(s, l, r + 1, index + 1);
    }
    else
    {
        return Dfs(s, l + 1, r, index + 1) || Dfs(s, l, r + 1, index + 1) || Dfs(s, l, r, index + 1);
    }
}
}
}
