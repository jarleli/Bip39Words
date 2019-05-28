using System;
using System.Diagnostics;
using dotnetstandard_bip39;
using freakcode.Cryptography;
using NUnit.Framework;

namespace Bip39Words.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateRandomNumber()
        {
            for (int i = 0; i < 20; i++)
            {
                var number = new CryptoRandom().Next(0, 3);
                Assert.GreaterOrEqual(number, 0);
                Assert.Less(number, 3);
            }
        }

        [Test]
        public void GetsAWordFromList()
        {
            var word = WordGenerator.GetRandomWord();
            Assert.IsNotNull(word);
            Assert.Greater(word.Length,0);
        }

        [Test]
        public void GetsWordsFromList()
        {
            var words = WordGenerator.GetRandomWord(24);
            Assert.IsNotNull(words);
            Assert.AreEqual(words.Length, 24);
            Assert.Greater(words[0].Length, 0);
        }


        [Test]
        public void GetsWordsString()
        {
            var words = WordGenerator.GetRandomWordString(10);
            Assert.IsNotNull(words);
            Assert.Greater(words.Length, 24);
            StringAssert.DoesNotStartWith(" ", words);
            StringAssert.DoesNotEndWith(" ", words);
        }

        [Test, Explicit]
        public void GetsManyWords()
        {
            int count = 24;
            var sw = Stopwatch.StartNew();
            var words = WordGenerator.GetRandomWordString(count);
            sw.Stop();
            Assert.IsNotNull(words);
            Console.WriteLine($"Created {count} words in {sw.Elapsed}");
            Console.WriteLine(words);

            count = 30000;
            sw.Restart();
            words = WordGenerator.GetRandomWordString(count);
            sw.Stop();
            Assert.IsNotNull(words);
            Console.WriteLine($"Created {count} words in {sw.Elapsed}");
            Console.WriteLine(words);
        }
    }
}