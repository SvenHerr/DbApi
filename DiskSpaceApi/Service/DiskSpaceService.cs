using DiskSpaceApi.Models;

namespace DiskSpaceApi.Service
{
    public class DiskSpaceService : IDiskSpaceService
    {
        public AppDbContext _context { get; set; }

        public DiskSpaceService(AppDbContext context)
        {
            _context = context;
        }
        public void AddDiskSpace(DiskSpace diskSpace)
        {
            _context.DiskSpaces.Add(diskSpace);
            _context.SaveChanges();
        }

        public IEnumerable<DiskSpace> GetAllDiskSpaces()
        {
            return _context.DiskSpaces.ToList();
        }
    }
}
