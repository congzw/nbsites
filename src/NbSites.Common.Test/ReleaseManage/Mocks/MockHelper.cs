namespace NbSites.Common.ReleaseManage.Mocks
{
    public class MockHelper
    {
        public static IReleaseManager CreateReleaseManager()
        {
            var releaseRepository = new MockReleaseRepository();
            return new ReleaseManager(releaseRepository);
        }
    }
}
