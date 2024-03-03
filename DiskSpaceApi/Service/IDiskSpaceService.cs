using DiskSpaceApi.Models;

namespace DiskSpaceApi.Service
{
    public interface IDiskSpaceService
    {
        public void AddDiskSpace(DiskSpace diskSpace);
        public IEnumerable<DiskSpace> GetAllDiskSpaces();
    }
}
