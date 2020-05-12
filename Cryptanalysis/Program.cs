using System;

namespace Cryptanalysis
{
internal static class Program
{
    private static void Main()
    {
        // Put your tests here.
        Test();
        Console.WriteLine(Caesar.GuessKey("My exam is so interesting! Thanks ACDC <3"));
        string text = "La triche consiste a recevoir, en situation de concurrence," +
                      "une recompense indue grace a ses capacites a contourner ou enfreindre les" +
                      "regles juridiques ou morales (principes de vie en societe, reglementation," +
                      "conventions), ou a trouver un moyen facile de se sortir d'une situation" +
                      "desagreable par des moyens malhonnetes. Cette definition large comprend" +
                      "necessairement les actes de corruption, de copinage, de nepotisme et toute" +
                      "situation dans laquelle des individus ont la preference en utilisant des" +
                      "criteres inappropries1.Les regles enfreintes peuvent etre explicites ou" +
                      "provenir d'un code de conduite non ecrit base sur la moralite," +
                      "l'ethique ou la coutume. L'identification de la tricherie est un" +
                      "processus potentiellement subjectif.La tricherie peut faire specifiquement" +
                      "reference a l'infidelite.Une personne connue pour avoir triche est" +
                      "qualifiee de << tricheur >>. Une personne decrite comme un << tricheur >>" +
                      "ne triche pas necessairement tout le temps, mais se repose plutot sur" +
                      "une tactique trompeuse au point d'en acquerir la reputation.";
        Console.Write(Vigenere.GuessKeyWithLength( text, 3));

    }

    private static void Test()
    {
        Test_Modulus_PositivePositive();
        Test_Modulus_NegativePositive();
        Test_Modulus_PositiveNegative();
        Test_Modulus_NegativeNegative();

        Test_RotChar_LowerCase();
        Test_RotChar_UpperCase();
        Test_RotChar_PositiveWrapping();
        Test_RotChar_NegativeWrapping();
        Test_RotChar_OtherChar();
        
        Console.WriteLine("All tests passed successfully.");
    }
    private static void Test_Modulus_PositivePositive()
    {
        AssertEq(1, Tools.Modulus(4, 3));
    }
    
    private static void Test_Modulus_NegativePositive()
    {
        AssertEq(2, Tools.Modulus(-4, 3));
    }
    
    private static void Test_Modulus_PositiveNegative()
    {
        AssertEq(1, Tools.Modulus(4, -3));
    }

    private static void Test_Modulus_NegativeNegative()
    {
        AssertEq(2, Tools.Modulus(-4, -3));
    }

    private static void Test_RotChar_LowerCase()
    {
        AssertEq('k', Tools.RotChar('g', 4));
    }
    
    private static void Test_RotChar_UpperCase()
    {
        AssertEq('K', Tools.RotChar('G', 4));
    }
    
    private static void Test_RotChar_PositiveWrapping()
    {
        AssertEq('c', Tools.RotChar('x', 5));
    }
    
    private static void Test_RotChar_NegativeWrapping()
    {
        AssertEq('v', Tools.RotChar('f', -10));
    }
    
    private static void Test_RotChar_OtherChar()
    {
        AssertEq('3', Tools.RotChar('3', 4));
    }

    private static void AssertEq<T>(T expected, T actual)
    {
        if (!Equals(expected, actual))
            throw new Exception($"Test failed: expecting {expected}, got {actual}.");
    }
}
}