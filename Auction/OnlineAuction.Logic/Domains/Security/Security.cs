using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineAuction.Logic.Domains;
using System.Web;

namespace OnlineAuction.Logic.Models
{

    public class Security
    {
        public enum SystemRoles
        {
            Admin = 1,
            Manager = 2,
            User = 3

        }

        public static bool Authenticate(string login, string password)
        {
            using (AuctionEntities au = new AuctionEntities())
            {
                return au.Users
                .Any(u => u.Login == login
                && u.Password == password);
            }
        }

        public static SystemRoles Authorizate(string login)
        {
            using (AuctionEntities au = new AuctionEntities())
            {
                int role = au.Users
                .Where(u => u.Login == login)
                .Select(u => u.IdRole)
                .FirstOrDefault();

                return (SystemRoles)role;
            }
        }

    }


}

