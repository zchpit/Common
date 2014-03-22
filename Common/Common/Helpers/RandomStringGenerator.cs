using System;
using System.Collections.Generic;
using System.Text;

namespace Zch.Common.Helpers
{
    public class RandomStringGenerator
    {
        public static string GetRandomString()
        {
            const string AllowedChars ="0123456789"; //wyrzucilem litery O0l1I
            Random rng = new Random();
            StringBuilder sb = new StringBuilder();

            foreach (var randomString in RandomStrings(AllowedChars, 6, 6, 1, rng))
            {
                sb.Append(randomString);
            }

            return sb.ToString();
        }
        private static IEnumerable<string> RandomStrings(string allowedChars, int minLength, int maxLength, int count, Random rng)
        {
            char[] chars = new char[maxLength];
            int setLength = allowedChars.Length;

            while (count-- > 0)
            {
                int length = rng.Next(minLength, maxLength + 1);

                for (int i = 0; i < length; ++i)
                {
                    chars[i] = allowedChars[rng.Next(setLength)];
                }

                yield return new string(chars, 0, length);
            }
        }
    }
}