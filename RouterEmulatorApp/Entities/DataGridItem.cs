namespace RouterEmulatorApp.Entities
{
    public class DataGridItem
    {
        public string SubnetAndPrefix { get; }
        public string Gateway { get; }
        public DataGridItem(string subnetAndPrefix, string gateway)
        {
            SubnetAndPrefix = subnetAndPrefix;
            Gateway = gateway;
        }
        
    }
}