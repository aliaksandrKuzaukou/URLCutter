using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrlCutterApp.Models
{
    public class URLAdress
    {
        public int Id { get; set; }

        [Required]
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public int CountOfTransitions { get; set; }
    }
}
