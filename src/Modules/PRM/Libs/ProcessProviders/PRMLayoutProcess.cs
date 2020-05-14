//using NbSites.Common.Layouts;
//using NbSites.Common.ProcessProviders;

//namespace NbSites.Areas.Web.PRM.Libs.ProcessProviders
//{
//    public class PRMLayoutProcess : IMyProcessProvider
//    {
//        public float ProcessOrder { get; set; } = 1000; 
//        public bool ShouldProcess(object context)
//        {
//            return context is LayoutContext;
//        }
//        public void Process(object context)
//        {
//            var layoutContext = context as LayoutContext;
//            if (layoutContext == null)
//            {
//                return;
//            }
//            if (layoutContext.Config == null)
//            {
//                layoutContext.Config = new LayoutConfig();
//            }
//            layoutContext.Config.Layout = "_Layui/_Layout";
//        }
//    }
//}
