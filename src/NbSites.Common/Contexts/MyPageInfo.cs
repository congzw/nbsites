﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NbSites.Common.Contexts
{
    public class MyPageInfo
    {
        public string LayoutPath { get; set; }
        public string PagePath { get; set; }
    }

    public static class MyPageInfoExtensions
    {
        private static string Group_PageInfos = "PageInfos";
        public static string GetGroupName_PageInfos(this MyRequestContext context)
        {
            return Group_PageInfos;
        }

        public static MyRequestContext AppendPageInfos(this MyRequestContext context, ViewContext viewContext)
        {
            var theGroup = context.GetOrCreate(context.GetGroupName_PageInfos());
            var myPageInfo = viewContext.CreateMyPageInfo();
            theGroup.Items[viewContext.View.Path] = myPageInfo.ToJson(false);
            return context;
        }
        
        public static IList<MyPageInfo> GetPageInfos(this MyRequestContext context)
        {
            var myPageInfos = new List<MyPageInfo>();
            var theGroup = context.GetOrCreate(context.GetGroupName_PageInfos(), false);
            if (theGroup == null)
            {
                return myPageInfos;
            }

            var jsonList = theGroup.Items.Values.ToList();
            return jsonList.Select(x => x.FromJson<MyPageInfo>(null)).Where(x => x != null).ToList();
        }

        public static MyPageInfo CreateMyPageInfo(this ViewContext viewContext)
        {
            if (viewContext == null)
            {
                throw new ArgumentNullException(nameof(viewContext));
            }

            var myPageInfo = new MyPageInfo();
            var razorPage = ((RazorView)viewContext.View).RazorPage;
            myPageInfo.LayoutPath = razorPage.Layout;
            myPageInfo.PagePath = razorPage.Path;
            return myPageInfo;
        }
    }
}
