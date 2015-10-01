using OnlineAuction.Logic.Domains;
using OnlineAuction.Logic.Domains.Models;
using OnlineAuction.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineAuction.WebUI.Pages.Common
{
    public partial class LotPage : System.Web.UI.Page
    {
        const int buyStatus = 2;
        const int upStatus = 3;

        protected Lot Lot;
        protected UserLot UserLot;
        protected AuctionEntities au = new AuctionEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

            int lotId;
            int.TryParse((string)Page.RouteData.Values["lot"]
            ?? Request.QueryString["lot"], out lotId);

            if (au.Lots.Count(l => l.IdLot == lotId) != 0)
            {
                Lot = au.Lots.First(l => l.IdLot == lotId);
                BuyBtn.Visible = true;
                if (Lot.Status == false)
                {
                    BuyBtn.Visible = false;
                }
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    int userId = au.Users
                    .Where(u => u.Login == HttpContext.Current.User.Identity.Name)
                    .Select(u => u.Id)
                    .First();

                    if (CheckUserLot(userId, Lot.IdLot, 2))
                    {
                        ButtonCheck();
                    }
                }

            }
        }

        protected string GetSeller(int lotId)
        {
            if (au.UserLots.Count(ul => ul.IdLot == lotId) != 0)
                UserLot = au.UserLots.First(ul => ul.IdLot == lotId && (ul.idStatus == 1 || ul.idStatus == 4));
            return UserLot.User.Name;

        }
        protected bool CheckUserLot(int userId, int lotId, int statusId)
        {
            return au.UserLots.Any(ul => ul.IdUser == userId && ul.IdLot == lotId && ul.idStatus == statusId);
        }

        protected bool CheckUserLot(int lotId, int statusId)
        {
            return au.UserLots.Any(ul => ul.IdLot == lotId && ul.idStatus == statusId);
        }

        protected int FindUser(int lotId, int statusId)
        {
            UserLot = au.UserLots.First(ul => ul.IdLot == lotId && ul.idStatus == statusId);
            return UserLot.IdUser;
        }


        protected void BuyBtn_Click(object sender, EventArgs e)
        {

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                int userId = au.Users
                .Where(u => u.Login == HttpContext.Current.User.Identity.Name)
                .Select(u => u.Id)
                .First();

                if (CheckUserLot(userId, Lot.IdLot, upStatus))
                {
                    using (var tran = au.Database.BeginTransaction())
                    {
                        try
                        {
                            Lot.CurrentPrice += Lot.Tick;
                            Methods.AddLot(Lot, au);
                            UpdateUserLot(FindUser(Lot.IdLot, buyStatus), buyStatus, upStatus);
                            UpdateUserLot(userId, upStatus, buyStatus);
                            au.SaveChanges();
                            tran.Commit();
                            ButtonCheck();
                        }
                        catch (Exception)
                        {
                            tran.Rollback();
                        }
                    }
                }

                else if (!CheckUserLot(userId, Lot.IdLot, buyStatus))
                {
                    if (!CheckUserLot(Lot.IdLot, buyStatus))
                    {
                        using (var tran = au.Database.BeginTransaction())
                        {
                            try
                            {
                                Lot.CurrentPrice += Lot.Tick;
                                Methods.AddLot(Lot, au);
                                AddUserLot(userId, 2);
                                au.SaveChanges();
                                tran.Commit();
                                ButtonCheck();
                            }
                            catch (Exception)
                            {
                                tran.Rollback();
                            }
                        }
                    }
                    else
                    {
                        using (var tran = au.Database.BeginTransaction())
                        {
                            try
                            {
                                Lot.CurrentPrice += Lot.Tick;
                                Methods.AddLot(Lot, au);
                                UpdateUserLot(FindUser(Lot.IdLot, buyStatus), buyStatus, upStatus);
                                AddUserLot(userId, 2);
                                au.SaveChanges();
                                tran.Commit();
                                ButtonCheck();
                                
                            }
                            catch (Exception)
                            {
                                tran.Rollback();
                            }
                        }
                    }
                }
            }
            else
            {
                Response.RedirectToRoute("login");
                return;
            }

        }

        private void UpdateUserLot(int userId, int oldStatusId, int newStatusId)
        {
            UserLot updateLot = au.UserLots
            .First(u => u.IdLot == Lot.IdLot && u.idStatus == oldStatusId);
            if (updateLot != null)
            {
                updateLot.IdUser = userId;
                updateLot.IdLot = Lot.IdLot;
                updateLot.idStatus = newStatusId;
                Methods.AddUserLot(updateLot, au);
            }
        }

        private void AddUserLot(int userId, int statusId)
        {
            UserLot ul = new UserLot();
            ul.IdUser = userId;
            ul.IdLot = Lot.IdLot;
            ul.idStatus = statusId;
            Methods.AddUserLot(ul, au);

        }

        private void ButtonCheck()
        {
            BuyBtn.Text = "Ставка сделана";
            BuyBtn.BackColor = ColorTranslator.FromHtml("#ff784e");
        }



    }
}