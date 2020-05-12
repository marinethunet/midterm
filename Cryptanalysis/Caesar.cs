using System;
using System.Numerics;

namespace Cryptanalysis
{
public class Caesar
{
    private int key;
    public Caesar(int key)//ok
    {
        this.key = key;
    }

    public string Encrypt(string msg)//ok
    {
        string ret = "";
        int i = 0;
        int l = msg.Length;
        while (i < l)
        {
            char re=Tools.RotChar(msg[i], key);
            ret += re;
            i++;
        }
        return ret;
    }

    public string Decrypt(string cypherText)//ok
    {
        string ret = "";
        int i = 0;
        int l = cypherText.Length;
        while (i < l)
        {
            char re=Tools.RotChar(cypherText[i], -key);
            ret += re;
            i++;
        }
        return ret; 
    }
    
    public static int GuessKey(string cypherText)//passur
    {
        int[] hist=Tools.Histogram(cypherText);
        int rankmax = 0;
        int valmax = 0;
        int i= 0;
        foreach (var val in hist)
        {
            if (valmax <val)
            {
                valmax = val;
                rankmax = i;
            }
            i++;
        }

        int key = Tools.Modulus(rankmax-4, 26);
        return key;
    }
}
}