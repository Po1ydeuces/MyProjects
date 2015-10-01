using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAuction.Logic.Domains.Models
{
    public class Methods
    {

        public static void AddUserLot(UserLot userLot, AuctionEntities au)
        {
            if (userLot.Id == 0)
            {
                au.UserLots.Add(userLot);
            }
            else
            {
                UserLot dbUserLot = au.UserLots.Find(userLot.Id);
                if (dbUserLot != null)
                {
                    dbUserLot.IdUser = userLot.IdUser;
                    dbUserLot.IdLot = userLot.IdLot;
                    dbUserLot.idStatus = userLot.idStatus;
                }
            }

        }

        public static void AddLot(Lot lot, AuctionEntities au)
        {
            if (lot.IdLot == 0)
            {
                au.Lots.Add(lot);
            }
            else
            {
                Lot dbLot = au.Lots.Find(lot.IdLot);
                if (dbLot != null)
                {
                    dbLot.IdSection = lot.IdSection;
                    dbLot.Name = lot.Name;
                    dbLot.Description = lot.Description;
                    dbLot.StartDate = lot.StartDate;
                    dbLot.EndDate = lot.EndDate;
                    dbLot.StartPrice = lot.StartPrice;
                    dbLot.Tick = lot.Tick;
                    dbLot.CurrentPrice = lot.CurrentPrice;
                    dbLot.Status = lot.Status;
                    dbLot.Img = lot.Img;

                }
            }
        }

        public static void AddUser(User user)
        {
            using (AuctionEntities au = new AuctionEntities())
            {
                if (user.Id == 0)
                {
                    au.Users.Add(user);
                }
                else
                {
                    User dbUser = au.Users.Find(user.Id);
                    if (dbUser != null)
                    {
                        dbUser.IdRole = user.IdRole;
                        dbUser.Login = user.Login;
                        dbUser.Password = user.Password;
                        dbUser.Email = user.Email;
                        dbUser.Phone = user.Phone;
                        dbUser.Name = user.Name;
                        dbUser.Address = user.Address;
                    }
                }
                au.SaveChanges();
            }
        }

        public static void UpdateLotsStatus()
        {

            using (AuctionEntities au = new AuctionEntities())
            {
                IEnumerable<Lot> lots = au.Lots
                .Where(l => l.EndDate <= DateTime.Now && l.Status != false).ToList();

                if (lots.Any())
                {
                    foreach (Lot lot in lots)
                    {
                        lot.Status = false;
                        AddLot(lot, au);
                    }
                }

                IEnumerable<UserLot> userLots = au.UserLots
                .Where(ul => ul.Lot.Status == false).ToList();

                if (userLots.Any())
                {
                    foreach (UserLot userLot in userLots)
                    {
                        if (userLot.idStatus == 1)
                        {
                            userLot.idStatus = 4;
                            AddUserLot(userLot, au);
                        }
                        if (userLot.idStatus == 2)
                        {
                            userLot.idStatus = 5;
                            AddUserLot(userLot, au);
                        }
                    }
                }
                au.SaveChanges();
            }

        }

        public static void AddSection(Section section)
        {
            using (AuctionEntities au = new AuctionEntities())
            {
                if (section.Id == 0)
                {
                    au.Sections.Add(section);
                }
                else
                {
                    Section dbSection = au.Sections.Find(section.Id);
                    if (dbSection != null)
                    {
                        dbSection.NameSection = section.NameSection;

                    }
                }
                au.SaveChanges();
            }
        }



    }
}
