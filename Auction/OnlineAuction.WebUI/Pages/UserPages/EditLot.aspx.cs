using OnlineAuction.Logic.Domains;
using OnlineAuction.Logic.Domains.Models;
using OnlineAuction.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineAuction.WebUI.Pages.UserPages
{
    public partial class EditLot : System.Web.UI.Page
    {
        protected Lot lot;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack &&
                !HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.RedirectToRoute("login");
                return;
            }
            if (!Page.IsPostBack &&
                  HttpContext.Current.User.Identity.IsAuthenticated)
            {
                MultiView.ActiveViewIndex = 0;
                int lotId;
                int.TryParse((string)Page.RouteData.Values["editlot"]
                                ?? Request.QueryString["editlot"], out lotId);
                if (lotId != 0)
                {
                    if (Security.Authorizate(HttpContext.Current.User.Identity.Name) == Security.SystemRoles.User)
                    {
                        using (AuctionEntities au = new AuctionEntities())
                        {
                            User user = au.Users
                               .First(u => u.Login == HttpContext.Current.User.Identity.Name);

                            if (!au.UserLots.Any(ul => ul.IdLot == lotId && ul.IdUser == user.Id && ul.idStatus == 1))
                            {
                                Response.RedirectToRoute("userlots");
                                return;
                            }
                        }
                    }
                    using (AuctionEntities au = new AuctionEntities())
                    {
                        lot = au.Lots.First(l => l.IdLot == lotId);
                        if (lot.Status == false)
                        {
                            Response.RedirectToRoute("lotsmng");
                        }
                        else
                        {

                            nameBox.Text = lot.Name;
                            ddlSection.SelectedValue = lot.Section.NameSection;
                            startDateBox.Text = lot.StartDate.ToString("dd.MM.yyyy, HH:mm");
                            TimeSpan dt = lot.EndDate - lot.StartDate;
                            switch (dt.Days)
                            {
                                case 1: ddlEndDate.SelectedIndex = 1; break;
                                case 7: ddlEndDate.SelectedIndex = 2; break;
                                case 30: ddlEndDate.SelectedIndex = 3; break;
                                default: ddlEndDate.SelectedIndex = 0; break;
                            }
                            startPriceBox.Enabled = false;
                            startPriceBox.Text = lot.StartPrice.ToString();
                            tickBox.Text = lot.Tick.ToString();
                            descBox.Text = lot.Description;
                        }
                    }

                }
                else
                {
                    startDateBox.Text = DateTime.Now.ToString("dd-MM-yyyy, HH:mm");
                }
                
            }

        }


        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("userlots");
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            Page.Validate();
         

            if (Page.IsValid)
            {
               
                int lotId;
                int.TryParse((string)Page.RouteData.Values["editlot"]
                                ?? Request.QueryString["editlot"], out lotId);

                if (lotId !=0)
                {
                    using (AuctionEntities au = new AuctionEntities())
                    {
                        using (var tran = au.Database.BeginTransaction())
                        {
                            try
                            {
                                lot = au.Lots.First(l => l.IdLot == lotId);
                                AddLot(lot, lot.StartDate, au);
                                au.SaveChanges();
                                tran.Commit(); 
                                lblError.Text = "Лот успешно изменен!";
                                MultiView.ActiveViewIndex = 1;
                                
                                Methods.UpdateLotsStatus();

                            }
                            catch (Exception)
                            {
                                tran.Rollback();
                            }
                        }
                    }
                }
                else
                {
                    HttpPostedFile ps = Request.Files["filefield"];
                    if ((ps != null) && (ps.ContentLength <= 0))
                    {
                        lblError.Text = "Изображение не выбрано!";
                        return;
                    }

                    using (AuctionEntities au = new AuctionEntities())
                    {
                        using (var tran = au.Database.BeginTransaction())
                        {
                            try
                            {
                                Lot newLot = new Lot();
                                newLot.StartDate = DateTime.Now;
                                newLot.StartPrice = Convert.ToDecimal(startPriceBox.Text);
                                newLot.CurrentPrice = Convert.ToDecimal(startPriceBox.Text);
                                newLot.Status = true;
                                AddLot(newLot, DateTime.Now, au);

                                int userId = au.Users
                                        .Where(u => u.Login == HttpContext.Current.User.Identity.Name)
                                        .Select(u => u.Id)
                                        .First();
                                UserLot userLot = new UserLot();
                                userLot.IdLot = newLot.IdLot;
                                userLot.IdUser = userId;
                                userLot.idStatus = 1;
                                Methods.AddUserLot(userLot, au);
                                au.SaveChanges();
                                tran.Commit();
                                lblError.Text = "Лот успешно добавлен!";
                                MultiView.ActiveViewIndex = 1;

                                Methods.UpdateLotsStatus();
                            }
                            catch (Exception)
                            {
                                tran.Rollback();
                            }
                        }
                    }
                }
            }

        }

        private void AddLot(Lot lot, DateTime date, AuctionEntities au)
        {
                Random rnd = new Random();
                lot.Name = nameBox.Text;
                lot.IdSection = au.Sections
                    .Where(s => s.NameSection == ddlSection.SelectedValue)
                    .Select(s => s.Id)
                    .First();
                lot.Description = descBox.Text;
                lot.Tick = Convert.ToDecimal(tickBox.Text);

                switch (ddlEndDate.SelectedIndex)
                {
                    case 0: lot.EndDate = date.AddHours(1); break;
                    case 1: lot.EndDate = date.AddDays(1); break;
                    case 2: lot.EndDate = date.AddDays(7); break;
                    case 3: lot.EndDate = date.AddMonths(1); break;
                }

                HttpPostedFile ps = Request.Files["filefield"];

                if ((ps != null) && (ps.ContentLength > 0))
                {

                    string fn = System.IO.Path.GetFileName(ps.FileName);
                    string fileName = rnd.Next(99999) + fn;
                    lot.Img = fileName;
                    string SaveLocation = Server.MapPath("~/DataBase/Images") + "\\" + fileName;
                    ps.SaveAs(SaveLocation);
                }

                Methods.AddLot(lot, au);
        }
    }
}