using Reveal.Sdk;

namespace RevealSdk.Sdk
{
    public class DataSourceProvider : IRVDataSourceProvider
    {
        public Task<RVDataSourceItem> ChangeDataSourceItemAsync(IRVUserContext userContext,
            string dashboardId, RVDataSourceItem dataSourceItem)
        {
            if (dataSourceItem is RVLocalFileDataSourceItem localDsi)
            {
                if (localDsi.Id == "LocalFileDataSource")
                {
                    localDsi.Uri = "local:/NorthwindTravel.xlsx";                 
                }
            }
            return Task.FromResult(dataSourceItem);
        }
        public Task<RVDashboardDataSource> ChangeDataSourceAsync(IRVUserContext userContext, RVDashboardDataSource dataSource)
        {
            return Task.FromResult(dataSource);
        }

    }
}
