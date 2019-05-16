using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlCutterApp.Contexts;
using UrlCutterApp.Interfaces;
using UrlCutterApp.Models;

namespace UrlCutterApp.Services
{
    public class URLServices : IUrlService
    {
        URLContext db;
        public URLServices(URLContext context)
        {
            db = context;
        }

        public bool Create(URLAdress uRLAdress)
        {
            if(uRLAdress != null)
            {
                db.URLAdresses.Add(uRLAdress);
                db.SaveChanges();
                return true;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public bool Delete(int? id)
        {
            URLAdress uRLAdress;
            if (id.HasValue)
            {
                uRLAdress = new URLAdress();
                uRLAdress= db.URLAdresses.Find(id);
                db.URLAdresses.Remove(uRLAdress);
                db.SaveChanges();
                return true;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }


        public IEnumerable<URLAdress> GetAll()
        {
            IEnumerable<URLAdress> adresses = new List<URLAdress>();
            adresses = db.URLAdresses;
            return adresses;
        }

        public URLAdress GetOne(int? id)
        {
            URLAdress uRLAdress;
            if (id.HasValue)
            {
                uRLAdress = new URLAdress();
                uRLAdress = db.URLAdresses.Find(id);
                return uRLAdress;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public bool Update(URLAdress uRLAdress)
        {
            if (uRLAdress != null)
            {
                db.URLAdresses.Update(uRLAdress);
                db.SaveChanges();
                return true;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
