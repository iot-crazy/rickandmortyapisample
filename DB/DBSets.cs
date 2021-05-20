using Microsoft.EntityFrameworkCore;

namespace Data
{
    public partial class DataContext
    {
        public virtual DbSet<Character> Characters { get; set; }
    }
}
