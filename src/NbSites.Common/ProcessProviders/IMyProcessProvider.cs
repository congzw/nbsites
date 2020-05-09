namespace NbSites.Common.ProcessProviders
{
    public interface IMyProcessProvider
    {
        float ProcessOrder { get; set; }
        bool ShouldProcess(object context);
        void Process(object context);
    }
}