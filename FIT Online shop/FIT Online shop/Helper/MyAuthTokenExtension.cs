using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIT_Online_shop.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Posiljka.Data.EntityModels;

namespace Posiljka.Web.Helper.webapi
{
    public static class MyAuthTokenExtension
    {

        public static KorisnickiNalog GetKorisnikOfAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.GetMyAuthToken();
            return GetKorisnikOfAuthToken(token);
        }

        public static KorisnickiNalog GetKorisnikOfAuthToken(string token)
        {
            MojDbContext db = new MojDbContext();

            KorisnickiNalog korisnickiNalog = db.AutentifikacijaToken.Where(x => token != null && x.Vrijednost == token).Select(s => s.KorisnickiNalog).SingleOrDefault();
            return korisnickiNalog;
        }

        public static string GetMyAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["MojAutentifikacijaToken"];
            return token;
        }
    }
}
