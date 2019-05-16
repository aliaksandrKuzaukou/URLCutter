using System.Collections.Generic;
using UrlCutterApp.Models;

namespace UrlCutterApp.Interfaces
{
    public interface IUrlService
    {
        bool Create(URLAdress uRLAdress);
        bool Update(URLAdress uRLAdress);
        URLAdress GetOne(int? id);
        IEnumerable<URLAdress> GetAll();
        bool Delete(int? id);
    }
}
