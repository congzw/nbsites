using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using NbSites.Common.Contexts;

namespace NbSites.Common.Web
{
    public abstract class MyRazorPage<TModel> : RazorPage<TModel>
    {
        public override ViewContext ViewContext
        {
            get => base.ViewContext;
            set
            {
                base.ViewContext = value;
                Context.GetMyRequestContext().AppendPageInfos(base.ViewContext);
            }
        }

        //public User CurrentUser
        //{
        //    get
        //    {
        //        //todo
        //        var userService = Context.RequestServices.GetRequiredService<IFooService>();
        //    }
        //}

        //protected override IHtmlContent RenderBody()
        //{
        //    //the body page process 
        //    return base.RenderBody();
        //}
    }

    public abstract class MyRazorPage : MyRazorPage<dynamic>
    {
    }
}
