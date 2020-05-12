using System;

namespace Cryptanalysis
{
public static class Tools
{
    public static int Modulus(int a, int b)//ok
    {
        if (b < 0)
            b = -b;
        
        var mod = a % b;
        return mod < 0 ? b + mod : mod;
    }

    public static int LetterIndex(char c)//ok
    {
        if (c >= 65 && c <= 90)
        {
            return c - 65;
        }

        if (c >= 97 && c <= 122)
        {
            return c - 97;
        }
        else
        {
            return -1;
        }
    }
    
    public static char RotChar(char c, int n)//ok
    {
        if (!((c >= 97 && c <= 122) || (c >= 65 && c <= 90)))
        {
            return c;
        }
        else
        {
            if (c >= 97 && c <= 122)
            {
                return (char) (Modulus(c-97+n,26)+97);
            }
            else
            {
                return (char) (Modulus(c - 65 + n, 26) + 65);
            }
        }
    }

    public static int[] Histogram(string str)//ok
    {
        int[] hist = new int[26]; 
        int ind;
        foreach (var letter in str)
        {
            ind = LetterIndex(letter);
            if (ind != -1)
            {
                hist[ind] += 1;
            }
        }
        
        return hist;
    }
    
    public static string FilterLetters(string str)//ok
    {
        int i = 0;
        int l = str.Length;
        string ret = "";
        while (i < l)
        {
            if (LetterIndex(str[i]) != -1)
            {
                ret += str[i];
            }
            i++;
        }

        return ret;
    }

    public static string Extract(string str, int start, int step)//ok
    {
        int i = start;
        int l = str.Length;
        string ret = "";
        while (i < l)
        {
            ret += str[i];
            i += step;
        }

        return ret;
    }
}
}
