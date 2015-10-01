using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineAuction.Logic.Domains;
using System.Web.Routing;

namespace OnlineAuction.WebUI.Models
{
    public static class UrlCreater
    {

        public static string CreateUrl(Lot lot)
        {
            return RouteTable.Routes.GetVirtualPath(null, "lot", new RouteValueDictionary()
{
                {"lot", lot.IdLot}
                }).VirtualPath;
        }

        public static string CreateUrl(Section section)
        {

            return RouteTable.Routes.GetVirtualPath(null, null,
            new RouteValueDictionary()
                {
                {"section", section.NameSection},
                {"page", "1"}
                }).VirtualPath;
        }


    }
}