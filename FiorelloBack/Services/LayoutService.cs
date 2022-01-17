using FiorelloBack.DAL;
using FiorelloBack.Models;
using System.Linq;

namespace FiorelloBack.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        public LayoutService(AppDbContext context)
        {
            _context = context;
        }
        public Setting GetSettingDatas()
        {
            Setting data = _context.settings.FirstOrDefault();
            return data;
        }

    }
}
