using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Demo.Infra.SQLContexts
{
    public class SQLDemoContext : DbContext
    {
        private readonly IConfiguration _config;
        public SQLDemoContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public SQLDemoContext(DbContextOptions<SQLDemoContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            }
        }

    }
}
