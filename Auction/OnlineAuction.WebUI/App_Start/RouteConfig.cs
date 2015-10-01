using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace OnlineAuction.WebUI.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapPageRoute(null, "catalog/{section}/{page}", "~/Pages/Common/Catalog.aspx");
            routes.MapPageRoute("search", "search/{search}/{page}", "~/Pages/Common/Catalog.aspx");
            routes.MapPageRoute(null, "catalog/{page}", "~/Pages/Common/Catalog.aspx");
            routes.MapPageRoute("lot", "lot/{lot}", "~/Pages/Common/LotPage.aspx");
           
            routes.MapPageRoute(null, "", "~/Pages/Common/Main.aspx");
            routes.MapPageRoute("main", "main", "~/Pages/Common/Main.aspx");
            routes.MapPageRoute("catalog", "catalog", "~/Pages/Common/Catalog.aspx");
            routes.MapPageRoute("notfound", "notfound", "~/Pages/Common/NotFound.aspx");
            routes.MapPageRoute("login", "login", "~/Pages/Common/Authentication.aspx");
            routes.MapPageRoute("cabinet", "cabinet", "~/Pages/UserPages/UserInfo.aspx");
            routes.MapPageRoute("registration", "registration", "~/Pages/Common/Registration.aspx");


            routes.MapPageRoute("editpassword", "cabinet/editpassword", "~/Pages/UserPages/EditPassword.aspx");
            routes.MapPageRoute("editinfo", "cabinet/editinfo", "~/Pages/UserPages/EditInfo.aspx");
            routes.MapPageRoute("userlots", "cabinet/userlots", "~/Pages/UserPages/UserLots.aspx");
            routes.MapPageRoute("editlot", "cabinet/editlot/{editlot}", "~/Pages/UserPages/EditLot.aspx");
            routes.MapPageRoute("lotsmng", "cabinet/lotsmng", "~/Pages/Admin/LotsMng.aspx");
            routes.MapPageRoute("usersmng", "cabinet/usersmng", "~/Pages/Admin/UsersMng.aspx");
            routes.MapPageRoute("edituser", "cabinet/edituser/{edituser}", "~/Pages/Admin/EditUser.aspx");
            routes.MapPageRoute("addlot", "cabinet/addlot", "~/Pages/UserPages/EditLot.aspx");
            routes.MapPageRoute("sectionmng", "cabinet/sectionmng", "~/Pages/Admin/SectionMng.aspx");
            routes.MapPageRoute("editsection", "cabinet/editsection/{editsection}", "~/Pages/Admin/EditSection.aspx");
            routes.MapPageRoute("addsection", "cabinet/addsection", "~/Pages/Admin/EditSection.aspx");
        }
    }
}