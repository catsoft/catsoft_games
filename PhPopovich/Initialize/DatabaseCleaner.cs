using App.Models;

namespace App.Initialize
{
    public class DatabaseCleaner
    {
        private readonly Context _context;

        public DatabaseCleaner(Context context)
        {
            _context = context;
        }

        public void Clean()
        {
            _context.RemoveRange(_context.AdminModels);
            _context.RemoveRange(_context.CmsModels);

            _context.SaveChanges();
        }
    }
}