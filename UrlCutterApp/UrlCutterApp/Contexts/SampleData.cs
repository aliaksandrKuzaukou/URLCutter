using System;
using System.Linq;
using UrlCutterApp.Models;

namespace UrlCutterApp.Contexts
{
    public static class SampleData
    {
        public static void Initialize(URLContext context)
        {
            if (!context.URLAdresses.Any())
            {
                context.URLAdresses.AddRange(
                    new URLAdress
                    {
                        LongUrl = "https://github.com",
                        ShortUrl = " ",
                        CreationDate = DateTimeOffset.Now,
                        CountOfTransitions = 0

                    },
                    new URLAdress
                    {
                        LongUrl = "https://metanit.com/sharp/wpf/",
                        ShortUrl = " ",
                        CreationDate = DateTimeOffset.Now,
                        CountOfTransitions=0
                    });
                context.SaveChanges();
            }
        }
    }
}
