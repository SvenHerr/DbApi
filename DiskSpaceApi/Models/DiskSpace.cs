namespace DiskSpaceApi.Models
{
    public class DiskSpace
    {
        public int Id { get; set; }
        public double TotalSpaceGb { get; set; }
        public double UsedSpaceGb { get; set; }
        public double FreeSpaceGb { get; set; }
        public required string ServerName { get; set; }
        public required string Timestamp { get; set; }
    }
}
