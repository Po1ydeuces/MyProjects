using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using NHibernate;
using Domain.NHibernate;
using System.Security.Cryptography;


namespace Domain.Concrete
{
    public class FormAuthProvider: IAuthProvider
    {
        static IFurnitureRepository repository;

        public FormAuthProvider(IFurnitureRepository repo)
        {
            repository = repo;
        }

        static string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;
 
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }  

        public bool Authenticate(string username, string password)
        {

            string hashPsw = GetHashString(password);
            return repository.Users
            .Any(u => u.Login == username
            && u.Password == hashPsw);
        }

    }
}
