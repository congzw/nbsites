﻿using System;
using Microsoft.AspNetCore.Routing;

namespace NbSites.Common.Contexts
{
    public class MyRouteInfo
    {
        public string Route { get; set; }
        public string Site { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string User { get; set; }

    }
    
    public static class MyRouteInfoExtensions
    {
        private static string Group_RouteInfos = "RouteInfos";
        public static string GetGroupName_RouteInfos(this MyRequestContext context)
        {
            return Group_RouteInfos;
        }

        public static MyRequestContext SetRouteInfo(this MyRequestContext context, RouteData routeData)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var theGroup = context.GetOrCreate(context.GetGroupName_RouteInfos());

            foreach (var item in routeData.DataTokens)
            {
                theGroup.Items[item.Key] = item.Value?.ToString();
            }
            foreach (var item in routeData.Values)
            {
                theGroup.Items[item.Key] = item.Value?.ToString();
            }
            return context;
        }

        public static MyRouteInfo GetRouteInfo(this MyRequestContext context)
        {
            var info = new MyRouteInfo();
            var theGroup = context.GetOrCreate(context.GetGroupName_RouteInfos());
            theGroup.Items.SetProperties(info);
            return info;
        }
    }
}