using System;
using System.Text;
using UrlCutterApp.Interfaces;

namespace UrlCutterApp.RandomGenerator
{
    public class Generator:IRandomGenerator
    {
        private int UrlLength = 7;

        public string GetRandomURL()
        {
            return GenerateRandomName();
        }

        private string GenerateRandomName()
        {
            const string valid = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < UrlLength--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
