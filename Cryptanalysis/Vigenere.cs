using System;

namespace Cryptanalysis
{
public class Vigenere
{
    public const float FrenchIndexOfCoincidence = 0.0778F;
    private string key;
    public Vigenere(string key)//ok
    {
        this.key = key;
    }

    public string Encrypt(string msg)//ok
    {
        string ret = "";
        int imsg = 0;
        int lmsg = msg.Length;
        int ik = 0;
        int lk = this.key.Length;
        char test;
        while (imsg<lmsg)
        {
            int c = Tools.LetterIndex(msg[imsg]);
            if (c != -1)
            { 
                test=Tools.RotChar(msg[imsg], Tools.LetterIndex(key[ik]));
                ret += test;
                ik = Tools.Modulus(ik + 1, lk);
            }
            else
            {
                ret += msg[imsg];
            }

            imsg++;
        }

        return ret;
    }

    public string Decrypt(string cypherText)//ok
    {
        string ret = "";
        int imsg = 0;
        int lmsg = cypherText.Length;
        int ik = 0;
        int lk = this.key.Length;
        char test;
        while (imsg<lmsg)
        {
            int c = Tools.LetterIndex(cypherText[imsg]);
            if (c != -1)
            { 
                test=Tools.RotChar(cypherText[imsg], -Tools.LetterIndex(key[ik]));
                ret += test;
                ik = Tools.Modulus(ik + 1, lk);
            }
            else
            {
                ret += cypherText[imsg];
            }

            imsg++;
        }

        return ret;
    }

    public static string GuessKeyWithLength(string cypherText, int keyLength)
    {
        throw new NotImplementedException();
    }
    
    public static float IndexOfCoincidence(string str)
    {
        throw new NotImplementedException();
    }

    public static int GuessKeyLength(string cypherText)
    {
        throw new NotImplementedException();
    }
    
    public static string GuessKey(string cypherText)
    {
        throw new NotImplementedException();
    }
}
}
