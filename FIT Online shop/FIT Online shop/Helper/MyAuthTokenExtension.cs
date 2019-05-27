using System.Linq;
using FIT_Online_shop.EF;
using FIT_Online_shop.EntityModels;
using Microsoft.AspNetCore.Http;

namespace FIT_Online_shop.Helper
{
    public static class MyAuthTokenExtension
    {

        public static KorisnickiNalog GetKorisnikOfAuthToken(string token)
        {
            MojDbContext db = new MojDbContext();

            KorisnickiNalog korisnickiNalog = db.AutentifikacijaToken.Where(x => token != null && x.Vrijednost == token).Select(s => s.KorisnickiNalog).SingleOrDefault();
            return korisnickiNalog;
        }

        public static string GetMyAuthTokenFromHeader(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["MojToken"];
            return token;
        }
    }
}
