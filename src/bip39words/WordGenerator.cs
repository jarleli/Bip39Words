using System;
using System.Security.Cryptography;
using freakcode.Cryptography;

namespace Bip39Words
{
    public static class WordGenerator
    {
        public static CryptoRandom Random = new CryptoRandom(true);

        public static string GetRandomWord()
        {
            return Wordlists.English[GetRandomNumber()];
        }

        public static string[] GetRandomWord(int length)
        {
            var words = new string[length];
            for (var i = 0; i < length; i++)
            {
                words[i] = Wordlists.English[GetRandomNumber()];
            }
            return words;
        }
        public static string GetRandomWordString(int length)
        {
            var words = string.Empty;
            for (var i = 0; i < length; i++)
            {
                words += Wordlists.English[GetRandomNumber()];
                words += " ";
            }

            return words.Trim();
        }


        private static int GetRandomNumber()
        {
            return Random.Next(0, 2048);
        }
    }
}
