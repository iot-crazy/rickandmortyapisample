using System;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public partial class DataContext : DbContext
    {

        public DataContext()
        {

        }

        public DataContext(string connectionString) : base(CreateOptions(connectionString))
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        private static DbContextOptions<DataContext> CreateOptions(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>().UseSqlServer(connectionString);
            return optionsBuilder.Options;
        }

    }
}
